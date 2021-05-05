using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Models;

namespace TestAspCore.IServices
{
  public  interface ITestVideoService
    {

        IEnumerable<TestVideo> GetTestVideo();

        IEnumerable<TestVideo> GetTestsVideoByID(int id);
        IEnumerable<TestVideo> GetTestsVideoByState(string status);

        TestVideo GetTestSessionVideo(int idsession, string rank);

        string DeleteTestSessionVideo(int sessionid);
    }
}
