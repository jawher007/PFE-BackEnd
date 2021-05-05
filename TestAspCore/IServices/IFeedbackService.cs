using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Models;


namespace TestAspCore.IServices
{
  public interface IFeedbackService
    {
        IEnumerable<Feedback> GetFeedback();
        Feedback GetFeedbackById(int id);
        Feedback AddFeedback(Feedback feedback);
        Feedback UpdateFeedback(Feedback feedback);
        string DeleteFeedback(int id);
    }
}
