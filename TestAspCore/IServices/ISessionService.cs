using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Models;

namespace TestAspCore.IServices
{
   public interface ISessionService
    {
        IEnumerable<Session> GetSession();
        Session GetSessionById(int id);

        string DeleteSession(int sessionid);
    }
}
