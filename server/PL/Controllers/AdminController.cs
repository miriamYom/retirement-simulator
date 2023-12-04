using BL.Auth;
using BL.BLImplements;
using BL.DTO;
using BL.Pension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserServiceBL userServiceBL;
        private readonly IJWTManagerRepository jWTManager;
        private readonly ITokenServiceBL tokenService;



        public AdminController(IUserServiceBL userServiceBL, IJWTManagerRepository jWTManager, ITokenServiceBL tokenService) 
        {
            this.userServiceBL = userServiceBL;
            this.jWTManager = jWTManager;
            this.tokenService = tokenService;
        }

    

        [HttpGet("GetAll")]

        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]
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


        //[AllowAnonymous]
        [HttpPost("CreateUser")]
        public bool CreateUser([FromBody] UserDTO user)
        {
            try
            {
                return userServiceBL.CreateAsync(user).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //[AllowAnonymous]
        [HttpDelete("DeleteUser")]
        public bool DeleteUser(UserDTO user)
        {
            return userServiceBL.DeleteAsync(user).Result;
        }

        //[AllowAnonymous]
        [HttpPut("Update")]
        public bool UpdateUser(params UserDTO[] user)
        {
            return userServiceBL.UpdateAsync(user[0], user[1]).Result;
        }
    }
}
