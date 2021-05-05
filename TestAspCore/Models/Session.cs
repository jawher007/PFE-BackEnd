using System;
using System.Collections.Generic;

#nullable disable

namespace TestAspCore.Models
{
    public partial class Session
    {
        public int Id { get; set; }
        public int Sessionid { get; set; }
        public string Username { get; set; }
        public string Browsername { get; set; }
        public string Os { get; set; }
        public string Cap1 { get; set; }
        public string Cap2 { get; set; }
        public string Cap3 { get; set; }
        public string Cap4 { get; set; }
        public string Cap5 { get; set; }
        public string Cap6 { get; set; }
        public string Cap7 { get; set; }
        public string Cap8 { get; set; }
        public string Cap9 { get; set; }
        public string Cap10 { get; set; }
        public string Durationsec { get; set; }
        public string Durationmin { get; set; }
        public string Testcount { get; set; }
        public string Testpassed { get; set; }
        public string Testfailed { get; set; }
        public string StartedAt { get; set; }
        public string Browserversion { get; set; }
        public string Sessiontitle { get; set; }
    }
}
