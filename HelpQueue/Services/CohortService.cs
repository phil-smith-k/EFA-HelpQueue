using HelpQueue.Models;
using HelpQueue.Models.Cohort;
using HelpQueue.Models.Responses;
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

        // Create Class
        public async Task<Response> CreateCohortAsync(CohortCreate model)
        {
            throw new NotImplementedException();
        }

        // Get List of Classes
        public async Task<IEnumerable<CohortListItem>> GetCohortListAsync()
        {
            var cohorts = await _context.Cohorts.ToListAsync();
            return cohorts.Select(c => new CohortListItem { Id = c.Id, Name = c.Name });
        }

        // Join Class

        // Enroll in class

        // Leave Class

        // Conclude Class
    }
}