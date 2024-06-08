// Controllers/WorkOutController.cs
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using Fitness_Management.Models;

namespace Fitness_Management.Controllers
{
    public class WorkOutController : Controller
    {
        // GET: WorkOut/List
        public ActionResult List()
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44356/api/WorkOutData/ListWorkOuts";

            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<WorkOutDto> workOuts = response.Content.ReadAsAsync<IEnumerable<WorkOutDto>>().Result;
            return View(workOuts);
        }

        // GET: WorkOut/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkOut/Create
        [HttpPost]
        public ActionResult Create(WorkOutDto workOutDto)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44356/api/WorkOutData/AddWorkOut";

            HttpResponseMessage response = client.PostAsJsonAsync(url, workOutDto).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List", "Exercise");
            }

            return View(workOutDto);
        }

        public ActionResult Details(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var workout = db.WorkOuts.Find(id);
                if (workout == null)
                {
                    return HttpNotFound();
                }

                var exercises = db.WorkOutPlans.Where(wp => wp.WorkOutId == id).ToList();

                var viewModel = new WorkOutDetailsViewModel
                {
                    WorkOut = new WorkOutDto
                    {
                        WorkOutId = workout.WorkOutId,
                        Name = workout.WorkOutName
                    },
                    Exercises = exercises.Select(e => new ExerciseDto
                    {
                        ExerciseId = e.ExerciseId,
                        ExerciseName = e.ExerciseName,
                        Reps = e.Reps,
                        sets = e.sets,
                        BodyPart = e.BodyPart
                    }).ToList()
                };

                return View(viewModel);
            }
        }
    }
}
