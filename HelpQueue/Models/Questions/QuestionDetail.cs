using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpQueue.Models.Questions
{
    public class QuestionDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StudentName { get; set; }
        public DateTimeOffset CreationTime { get; set; }
    }
}