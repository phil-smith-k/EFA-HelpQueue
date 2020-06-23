using HelpQueue.Models.Cohort;
using HelpQueue.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HelpQueue.Controllers
{
    [Authorize]
    public class HelpQueueController : Controller
    {
        private readonly CohortService _cohortService = new CohortService();

        // GET: HelpQueue
        public async Task<ActionResult> Index()
        {
            if (User.IsInRole("Student"))
                return RedirectToAction(nameof(HelpQueue));

            var cohorts = await _cohortService.GetCohortListAsync();

            return View(cohorts);
        }

        // GET: HelpQueue/HelpQueue/{id?}
        public async Task<ActionResult> Queue(int? id)
        {
            CohortDetail model = null;
            if (User.IsInRole("Student"))
                model = await _cohortService.GetUserCohortDetailAsync(User.Identity.GetUserId());
            else if (id.HasValue)
                model = await _cohortService.GetCohortById(id.Value);

            if(model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}