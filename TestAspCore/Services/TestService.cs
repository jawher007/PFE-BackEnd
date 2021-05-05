using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.IServices;
using TestAspCore.Models;

namespace TestAspCore.Services
{
    public class TestService : ITestService
    {
        testdbContext dbContext;

        public TestService(testdbContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<Test> GetTest()
        {
            var test = dbContext.Tests.ToList();
            return test;
        }

        public IEnumerable<Test> GetTestsByID(int id)
        {
            var test = dbContext.Tests.Where(x => x.Sessionid == id);
            return test;
        }
        public IEnumerable<Test> GetTestsByState(string status)
        {
            var test = dbContext.Tests.Where(x => Equals(x.Teststatus, status));
            return test;
        }

       public Test GetTestSession(int idsession, string rank) {
            var test = dbContext.Tests.FirstOrDefault(x => x.Sessionid == idsession && Equals(x.Testrank, rank));
            return test;

        }


        public string DeleteTestSession(int sessionid)
        {
            var test = dbContext.Tests.Where(x => x.Sessionid == sessionid);
            foreach (var t in test)
            {

                dbContext.Entry(t).State = EntityState.Deleted;

            }
            dbContext.SaveChanges();
            return "deleted";
        }
    }
}
