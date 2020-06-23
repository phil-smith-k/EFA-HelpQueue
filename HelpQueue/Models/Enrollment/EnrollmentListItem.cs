using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpQueue.Models.Enrollment
{
    public class EnrollmentListItem
    {
        public int CohortId { get; set; }
        public string CohortName { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public bool Enrolled { get; set; }
    }
}