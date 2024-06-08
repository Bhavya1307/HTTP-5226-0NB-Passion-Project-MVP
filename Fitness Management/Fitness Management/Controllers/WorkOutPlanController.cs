using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fitness_Management.Models;

namespace Fitness_Management.Controllers
{
    public class WorkOutPlanController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkOutPlan/List
        public ActionResult List()
        {
            // Retrieve the list of workout plans from the database
            var workoutPlans = db.WorkOutPlans.ToList();

            // Pass the list of workout plans to the view
            return View(workoutPlans);
        }
    }
}
