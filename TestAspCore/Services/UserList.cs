using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.IServices;
using TestAspCore.Models;

namespace TestAspCore.Services
{
    public class UserList : IUserList
    {
        testdbContext dbContext;

        public UserList(testdbContext _db)
        {
            dbContext = _db;
        }
        public IEnumerable<AspNetUser> GetUserList()
        {
            var aspnetusers = dbContext.AspNetUsers.ToList();
            return aspnetusers;
        }

        public string DeleteUser(Guid id)
        {
            var aspnetusers = dbContext.AspNetUsers.FirstOrDefault(x => Equals (x.Id,id));
            dbContext.Entry(aspnetusers).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return "User Deleted";
        }

        public AspNetUser GetUserByUsername(string username)
        {
            var aspnetusers = dbContext.AspNetUsers.FirstOrDefault(x => Equals(x.UserName, username));
            return aspnetusers;
        }
    }
}

