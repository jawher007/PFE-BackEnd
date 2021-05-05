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
    public class TestVideoController : ControllerBase
    {
        private readonly ITestVideoService testvideoService;
        public TestVideoController(ITestVideoService testvideo)
        {
            testvideoService = testvideo;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("GetTestsVideos")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<TestVideo> GetTestVideo()
        {
            return testvideoService.GetTestVideo();
        }


        [HttpGet]
        [Authorize]
        [Route("GetTestVideoByState/{status}")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<TestVideo> GetTestsVideoByState(string status)
        {
            return testvideoService.GetTestsVideoByState(status);
        }
        [HttpGet]
        [Authorize]
        [Route("GetIdTestVideo/{id}")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<TestVideo> GetTestsVideoByID(int id)
        {
            return testvideoService.GetTestsVideoByID(id);
        }

        [HttpGet]
        [Authorize]

        [Route("GetTestVideoSession/{idsession}/{rank}")]
        [EnableCors("AllowOrigin")]
        public TestVideo GetTestSession(int idsession, string rank)
        {
            return testvideoService.GetTestSessionVideo(idsession, rank);
        }


        [HttpDelete]
        [Authorize]
        [Route("DeleteTestVideo/{sessionid}")]
        public string DeleteTestSessionVideo(int sessionid)
        {
            return testvideoService.DeleteTestSessionVideo(sessionid);
        }
    }
}
