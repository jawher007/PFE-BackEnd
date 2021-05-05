using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Models;

namespace TestAspCore.IServices
{
    public interface IIssuesService
    {
        IEnumerable<Issue> GetIssues();
        Issue GetIssueById(int id);
        Issue AddIssue(Issue feedback);
        Issue UpdateIssue(Issue feedback);
        string DeleteIssue(int id);
    }
}
