﻿using HelpQueue.Models;
using HelpQueue.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelpQueue.Services
{
    public class QuestionService
    {
        private readonly ApplicationDbContext _context;
        public QuestionService()
        {
            _context = new ApplicationDbContext();
        }

        // Get Questions by Cohort Id
        public async Task<List<QuestionDetail>> GetQuestionsByCohortId(int cohortId)
        {
            var cohort = await _context.Cohorts.FindAsync(cohortId);
            if (cohort == null)
                return null;

            return cohort.Questions.Select(q => new QuestionDetail
            {
                Id = q.Id,
                Title = q.Title,
                Description = q.Description,
                CreationTime = q.CreationTime,
                StudentName = q.Student.FullName
            }).ToList();
        }
    }
}