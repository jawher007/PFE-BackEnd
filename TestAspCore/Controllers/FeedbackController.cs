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

    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;
        public FeedbackController(IFeedbackService feedback)
        {
            feedbackService = feedback;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("GetFeedbacks")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<Feedback> GetFeedback()
        {
            return feedbackService.GetFeedback();
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("AddFeedback")]
        [EnableCors("AllowOrigin")]
        public Feedback AddFeedback(Feedback feedback)
        {
            return feedbackService.AddFeedback(feedback);
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("EditFeedback")]
        [EnableCors("AllowOrigin")]
        public Feedback UpdateFeedback(Feedback feedback)
        {
            return feedbackService.UpdateFeedback(feedback);
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("DeleteFeedback/{id}")]
        [EnableCors("AllowOrigin")]
        public string DeleteFeedback(int id)
        {
            string msg = "deleted";
            feedbackService.DeleteFeedback(id);
            if (this.HttpContext.Response.StatusCode == 200)
            { msg = "User deleted"; }
            return msg;
        }

        [HttpGet]
        [Authorize]
        //[Route("[action]")]
        [Route("GetIdFeedback/{id}")]
        [EnableCors("AllowOrigin")]
        public Feedback GetFeedbackById(int id)
        {
            return feedbackService.GetFeedbackById(id);
        }
    }
}