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

 
    public class IssuesController : ControllerBase
    {
        private readonly IIssuesService iissuesService;
        public IssuesController(IIssuesService issuesService)
        {
            iissuesService = issuesService;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("GetIssue")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<Issue> GetIssues()
        {
            return iissuesService.GetIssues();
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("AddIssue")]
        [EnableCors("AllowOrigin")]
        public Issue AddIssue(Issue issue)
        {
            return iissuesService.AddIssue(issue);
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("EditIssue")]
        [EnableCors("AllowOrigin")]
        public Issue UpdateIssue(Issue issue)
        {
            return iissuesService.UpdateIssue(issue);
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("DeleteIssue/{id}")]
        [EnableCors("AllowOrigin")]
        public string DeleteFeedback(int id)
        {
            string msg = "deleted";
            iissuesService.DeleteIssue(id);
            if (this.HttpContext.Response.StatusCode == 200)
            { msg = "Issue deleted"; }
            return msg;
        }

        [HttpGet]
        [Authorize]
        //[Route("[action]")]
        [Route("GetIdIssue/{id}")]
        [EnableCors("AllowOrigin")]
        public Issue GetIssueById(int id)
        {
            return iissuesService.GetIssueById(id);
        }
    }
}
