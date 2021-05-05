using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Models;
namespace TestAspCore.IServices
{
  public  interface ISessionVideoService
    {
        IEnumerable<SessionVideo> GetSessionVideo();
        SessionVideo GetSessionVideoById(int id);

        string DeleteSessionVideoBy(int sessionid);
    }
}
