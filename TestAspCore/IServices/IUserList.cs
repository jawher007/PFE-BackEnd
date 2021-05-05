using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Models;

namespace TestAspCore.IServices
{
   public interface IUserList
    {
        IEnumerable<AspNetUser> GetUserList();
        AspNetUser GetUserByUsername(string username);
      
        string DeleteUser(Guid id);
    }
}
