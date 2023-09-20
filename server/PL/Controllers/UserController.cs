using BL;
using BL.Auth;
using BL.BLImplements;
using BL.DTO;
using BL.Pension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserServiceBL userServiceBL;
    private readonly IPensionFactory pensionFactory;
    private readonly IJWTManagerRepository jWTManager;
    private readonly ITokenServiceBL tokenService;

    public UserController(IUserServiceBL userServiceBL, IPensionFactory pensionFactory, IJWTManagerRepository jWTManager, ITokenServiceBL tokenService)
    {
        this.userServiceBL = userServiceBL;
        this.pensionFactory = pensionFactory;
        this.jWTManager = jWTManager;
        this.tokenService = tokenService;
    }

    public UserController(IUserServiceBL userServiceBL, IJWTManagerRepository jWTManager, ITokenServiceBL tokenService)
    {
        this.userServiceBL = userServiceBL;
        this.jWTManager = jWTManager;
        this.tokenService = tokenService;
    }



    [HttpPost("GetPensionCalculates")]
    public object CreatePensionService(string pensionType, [FromBody] object employee)
    {
        try
        {
            var o = employee;
           return pensionFactory.Create(pensionType, employee);
        }
        catch (InvalidParameterException ex)
        {
            throw ex;
        }
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginWithAuthenticateAsync(string email, [FromBody] string pass)
    {
        var validUser = jWTManager.UserAuthenticate(email, pass);

        if (validUser == null)
        {
            return Unauthorized("Incorrect username or password!");
        }

        var token = jWTManager.GenerateUserToken(email);

        if (token == null)
        {
            return Unauthorized("Invalid Attempt!");
        }

        // saving refresh token to the db
        UserRefreshTokenDTO obj = new UserRefreshTokenDTO
        {
            RefreshToken = token.RefreshToken,
            UserId = validUser.Id,
            Email = validUser.Email,
        };

        await tokenService.AddUserRefreshTokens(obj);
        return Ok(new { user = validUser, token = token });
    }


    [AllowAnonymous]
    [HttpPost]
    [Route("refresh")]
    public IActionResult Refresh(Tokens token)
    {
        var principal = jWTManager.GetPrincipalFromExpiredToken(token.Token);
        var email = principal.Identity?.Name;

        //retrieve the saved refresh token from database
        var savedRefreshToken = tokenService.GetSavedRefreshTokens(email, token.RefreshToken).Result;

        if (savedRefreshToken.RefreshToken != token.RefreshToken)
        {
            return Unauthorized("Invalid attempt!");
        }

        var newJwtToken = jWTManager.GenerateUserRefreshToken(email);

        if (newJwtToken == null)
        {
            return Unauthorized("Invalid attempt!");
        }

        // saving refresh token to the db
        UserRefreshTokenDTO obj = new UserRefreshTokenDTO
        {
            RefreshToken = newJwtToken.RefreshToken,
            Email = email
        };

        tokenService.DeleteUserRefreshTokens(email, token.RefreshToken);
        tokenService.AddUserRefreshTokens(obj);

        return Ok(newJwtToken);
    }

}

