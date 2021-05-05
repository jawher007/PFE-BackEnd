using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.IServices;
using TestAspCore.Models;

namespace TestAspCore.Services
{
    public class FeedbackService : IFeedbackService
    {
        testdbContext dbContext;

        public FeedbackService(testdbContext _db)
        {
            dbContext = _db;
        }


        public IEnumerable<Feedback> GetFeedback() {
            var feedback = dbContext.Feedbacks.ToList();
            return feedback;
        }
        public Feedback GetFeedbackById(int id) {
            var feedback = dbContext.Feedbacks.FirstOrDefault(x => x.Id == id);
            return feedback;
        }
        public Feedback AddFeedback(Feedback feedback) {
            if (feedback != null)
            {
                dbContext.Feedbacks.Add(feedback);
                dbContext.SaveChanges();
                return feedback;
            }
            return null;
        }
        public Feedback UpdateFeedback(Feedback feedback) {
            dbContext.Entry(feedback).State = EntityState.Modified;
            dbContext.SaveChanges();
            return feedback;
        }
        public string DeleteFeedback(int id) {
            var feedback = dbContext.Feedbacks.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(feedback).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return "feedback Deleted";
        }
    }
}
