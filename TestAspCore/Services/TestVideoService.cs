using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.IServices;
using TestAspCore.Models;

namespace TestAspCore.Services
{
    public class TestVideoService : ITestVideoService
    {

        testdbContext dbContext;

        public TestVideoService(testdbContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<TestVideo> GetTestVideo()
        {
            var test = dbContext.TestVideos.ToList();
            return test;
        }

        public IEnumerable<TestVideo> GetTestsVideoByID(int id)
        {
            var test = dbContext.TestVideos.Where(x => x.Sessionid == id);
            return test;
        }
        public IEnumerable<TestVideo> GetTestsVideoByState(string status)
        {
            var test = dbContext.TestVideos.Where(x => Equals(x.Teststatus, status));
            return test;
        }

        public TestVideo GetTestSessionVideo(int idsession, string rank)
        {
            var test = dbContext.TestVideos.FirstOrDefault(x => x.Sessionid == idsession && Equals(x.Testrank, rank));
            return test;

        }

        public string DeleteTestSessionVideo(int sessionid)
        {
            var test = dbContext.TestVideos.Where(x => x.Sessionid == sessionid);

            foreach (var t in test)
            {

                dbContext.Entry(t).State = EntityState.Deleted;

            }

            dbContext.SaveChanges();

            return "deleted";
        }
    }
}
