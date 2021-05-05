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
    public class SessionController : ControllerBase
    {

        private readonly ISessionService sessionService;

        public SessionController(ISessionService session)
        {
            sessionService = session;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("GetSessions")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<Session> GetSession()
        {
            return sessionService.GetSession();
        }

        [HttpGet]
        [Authorize]
      
        [Route("GetIdSession/{id}")]
        [EnableCors("AllowOrigin")]
        public Session GetSessionById(int id)
        {
            return sessionService.GetSessionById(id);
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteSession/{sessionid}")]
        public string DeleteSession(int sessionid)
        {
            return sessionService.DeleteSession(sessionid);
        }
    }
}
