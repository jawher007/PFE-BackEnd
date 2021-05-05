using System;
using System.Collections.Generic;

#nullable disable

namespace TestAspCore.Models
{
    public partial class Issue
    {
        public int Id { get; set; }
        public string Issuetext { get; set; }
        public string Tester { get; set; }
        public string Idtest { get; set; }
    }
}
