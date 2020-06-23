using HelpQueue.Models.Enrollment;
using HelpQueue.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpQueue.Models.Cohort
{
    public class CohortDetail
    {
        public int CohortId { get; set; }
        public string CohortName { get; set; }
        public List<EnrollmentListItem> Students { get; set; }
        public List<QuestionDetail> Questions { get; set; }
    }
}