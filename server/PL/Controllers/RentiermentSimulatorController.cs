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
public class RentiermentSimulatorController : ControllerBase
{
    private readonly IUserServiceBL userServiceBL;
    private readonly IPensionFactory pensionFactory;
    private readonly IJWTManagerRepository jWTManager;
    private readonly ITokenServiceBL tokenService;

    public RentiermentSimulatorController(IUserServiceBL us, IPensionFactory pf, IJWTManagerRepository jWTManager, ITokenServiceBL ts)
    {
        userServiceBL = us;
        pensionFactory = pf;
        this.jWTManager = jWTManager;
        tokenService = ts;
    }

    [HttpGet("GetAll")]
    public List<UserDTO> GetAll()
    {
        return userServiceBL.GetAllAsync().Result;
    }

    [HttpPost("GetDetails")]
    public UserDTO GetDetails(UserDTO user)
    {
        return userServiceBL.GetAsync(user).Result;
    }

    [HttpPost("CreateUser")]
    public bool CreateUser([FromBody] UserDTO user)
    {
        try { 
        return userServiceBL.CreateAsync(user).Result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpDelete("DeleteUser")]
    public bool DeleteUser(UserDTO user)
    {
        return userServiceBL.DeleteAsync(user).Result;
    }

    [HttpPut("Update")]
    public bool UpdateUser(params UserDTO[] user)
    {
        return userServiceBL.UpdateAsync(user[0], user[1]).Result;
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

        var token = jWTManager.GenerateToken(validUser.Email);

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

        var newJwtToken = jWTManager.GenerateRefreshToken(email);

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

