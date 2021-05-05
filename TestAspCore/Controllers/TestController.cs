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
    public class TestController : ControllerBase
    {
        private readonly ITestService testService;
        public TestController(ITestService test)
        {
            testService = test;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("GetTests")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<Test> GetTest()
        {
            return testService.GetTest();
        }


        [HttpGet]
        [Authorize]
        [Route("GetTestByState/{status}")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<Test> GetTestsByState(string status)
        {
            return testService.GetTestsByState(status);
        }
        [HttpGet]
        [Authorize]
        [Route("GetIdTest/{id}")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<Test> GetTestsByID(int id)
        {
            return testService.GetTestsByID(id);
        }

        [HttpGet]
        [Authorize]

        [Route("GetTestSession/{idsession}/{rank}")]
        [EnableCors("AllowOrigin")]
        public Test GetTestSession(int idsession, string rank)
        {
            return testService.GetTestSession(idsession, rank);
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteTest/{sessionid}")]
        public string DeleteTestSession(int sessionid)
        {
            return testService.DeleteTestSession(sessionid);
        }
    }
}
