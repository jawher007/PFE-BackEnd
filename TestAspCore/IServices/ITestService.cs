using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Models;

namespace TestAspCore.IServices
{
    public interface ITestService
    {
        IEnumerable<Test> GetTest();

        IEnumerable<Test> GetTestsByID(int id);
        IEnumerable<Test> GetTestsByState(string status);

       Test GetTestSession(int idsession, string rank);

        string DeleteTestSession(int sessionid);

    }
}
