using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Authentication;
using TestAspCore.IServices;
using TestAspCore.Models;

namespace TestAspCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserListController : ControllerBase
    {
        private readonly IUserList UserList;
        public UserListController(IUserList userlist)
        {
            UserList = userlist;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        //    [Route("[action]")]
        [Route("GetUserList")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<AspNetUser> GetUserList()
        {
            return UserList.GetUserList();
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        //   [Route("[action]")]
        [Route("DeleteUser/{id}")]
        [EnableCors("AllowOrigin")]
        public string DeleteUser(Guid id)
        {
            string msg = "deleted";
            UserList.DeleteUser(id);
            if (this.HttpContext.Response.StatusCode == 200)
            { msg = "User deleted"; }
            return msg;

            /*
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to register new user" });

            return Ok(new Response { Status = "Success", Message = "User Created Successfully" });
         */

        }

        [HttpGet]
        //   [Authorize(Roles = UserRoles.Admin)]
        [Authorize]
        //[Route("[action]")]
        [Route("GetIdUser/{username}")]
        [EnableCors("AllowOrigin")]
        public AspNetUser GetUserByUsername(string username)
        {
            return UserList.GetUserByUsername(username);
        }
    }
}
