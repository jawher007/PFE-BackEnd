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
    public class SessionVideoController : ControllerBase
    {

        private readonly ISessionVideoService sessionvideoService;

        public SessionVideoController(ISessionVideoService sessionvideo)
        {
            sessionvideoService = sessionvideo;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("GetSessionsVideos")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<SessionVideo> GetSessionVideo()
        {
            return sessionvideoService.GetSessionVideo();
        }

        [HttpGet]
        [Authorize]

        [Route("GetIdSessionVideo/{id}")]
        [EnableCors("AllowOrigin")]
        public SessionVideo GetSessionVideoById(int id)
        {
            return sessionvideoService.GetSessionVideoById(id);
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteSessionVideo/{sessionid}")]
        public string DeleteSessionVideoBy(int sessionid)
        {
      
               sessionvideoService.DeleteSessionVideoBy(sessionid);

            return "Session Video Deleted";
        }
    }
}
