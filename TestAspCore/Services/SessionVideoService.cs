using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.IServices;
using TestAspCore.Models;

namespace TestAspCore.Services
{
    public class SessionVideoService : ISessionVideoService
    {


        testdbContext dbContext;

        public SessionVideoService(testdbContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<SessionVideo> GetSessionVideo()
        {
            var session = dbContext.SessionVideos.ToList();
            return session;
        }

        public SessionVideo GetSessionVideoById(int id)
        {
            var session = dbContext.SessionVideos.FirstOrDefault(x => x.Id == id);
            return session;
        }

        public string DeleteSessionVideoBy(int sessionid)
        {
            var sessionvideo = dbContext.SessionVideos.FirstOrDefault(x => x.Sessionid == sessionid);
            dbContext.Entry(sessionvideo).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return "sessionvideo deleted";
        }




    }
}
