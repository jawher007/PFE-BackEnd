using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.IServices;
using TestAspCore.Models;

namespace TestAspCore.Services
{
    public class SessionService : ISessionService
    {

        testdbContext dbContext;

        public SessionService(testdbContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<Session> GetSession()
        {
            var session = dbContext.Sessions.ToList();
            return session;
        }

        public Session GetSessionById(int id)
        {
            var session = dbContext.Sessions.FirstOrDefault(x => x.Id == id);
            return session;
        }


        public string DeleteSession(int sessionid)
        {
            var session = dbContext.Sessions.FirstOrDefault(x => x.Sessionid == sessionid);
            dbContext.Entry(session).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return "session deleted";
        }

    }
}
