using HelpQueue.Models;
using HelpQueue.Models.Cohort;
using HelpQueue.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelpQueue.Services
{
    public class CohortService
    {
        private readonly ApplicationDbContext _context;
        public CohortService()
        {
            _context = new ApplicationDbContext();
        }

        // Get Cohort By User ID
        public async Task<CohortDetail> GetUserCohortDetailAsync(string userId)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var enrollment = userEntity.Enrollments.FirstOrDefault();
            return await GetCohortById(enrollment.CohortId);
        }

        // Create Class
        public async Task<bool> CreateCohortAsync(CohortCreate model)
        {
            var existingCohort = await _context.Cohorts.FirstOrDefaultAsync(c => c.Name == model.Name);
            if (existingCohort != null)
                return false;

            var entity = new CohortEntity { Name = model.Name };
            _context.Cohorts.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        // Get List of Classes
        public async Task<List<CohortListItem>> GetCohortListAsync()
        {
            var cohorts = await _context.Cohorts.ToListAsync();
            return cohorts.Select(c => new CohortListItem
            {
                Id = c.Id,
                Name = c.Name,
                StudentCount = c.Enrollments.Where(e => e.Enabled).Count(),
                QuestionCount = c.Questions.Count
            }).ToList();
        }

        // Get Cohort
        public async Task<CohortDetail> GetCohortById(int cohortId)
        {
            var cohortEntity = await _context.Cohorts.FindAsync(cohortId);
            if (cohortEntity == null)
                return null;

            var cohortDetail = new CohortDetail
            {
                CohortId = cohortEntity.Id,
                CohortName = cohortEntity.Name
            };

            cohortDetail.Students = await new EnrollmentService().GetEnrollmentByCohortIdAsync(cohortId);
            cohortDetail.Questions = await new QuestionService().GetQuestionsByCohortId(cohortId);

            return cohortDetail;
        }
    }
}