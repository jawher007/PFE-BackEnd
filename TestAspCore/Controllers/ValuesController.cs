using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspCore.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ValuesController : ControllerBase
    {
      
        [HttpGet]
        [Route("GetData")]
        [EnableCors("AllowOrigin")]
        public string GetData()
        {
            return "Test Web API Core 5.0";
        }
    }
}
