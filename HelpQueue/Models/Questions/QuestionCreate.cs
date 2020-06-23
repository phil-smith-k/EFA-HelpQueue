using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpQueue.Models.Questions
{
    public class QuestionCreate
    {
        [Required]
        [Range(1, 1150)]
        public int CohortId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string StudentId { get; set; }
    }
}