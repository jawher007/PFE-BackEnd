using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.IServices;
using TestAspCore.Models;

namespace TestAspCore.Services
{
    public class IssuesService : IIssuesService
    {
       
            testdbContext dbContext;

            public IssuesService(testdbContext _db)
            {
                dbContext = _db;
            }


            public IEnumerable<Issue> GetIssues()
            {
                var issue = dbContext.Issues.ToList();
                return issue;
            }
            public Issue GetIssueById(int id)
            {
                var issue = dbContext.Issues.FirstOrDefault(x => x.Id == id);
                return issue;
            }
            public Issue AddIssue(Issue issue)
            {
                if (issue != null)
                {
                    dbContext.Issues.Add(issue);
                    dbContext.SaveChanges();
                    return issue;
                }
                return null;
            }
            public Issue UpdateIssue(Issue issue)
            {
            dbContext.Entry(issue).State = EntityState.Modified;
            dbContext.SaveChanges();
            return issue;
        }
            public string DeleteIssue(int id)
            {
                var issue = dbContext.Issues.FirstOrDefault(x => x.Id == id);
                dbContext.Entry(issue).State = EntityState.Deleted;
                dbContext.SaveChanges();
                return "feedback Deleted";
            }
        }
    }



