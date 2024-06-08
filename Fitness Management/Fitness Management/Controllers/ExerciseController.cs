using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using Fitness_Management.Models;

namespace Fitness_Management.Controllers
{
    public class ExerciseController : Controller
    {
        // GET: Exercise/List
        public ActionResult List(string searchString)
        {
            HttpClient client = new HttpClient();
            string url;

            if (string.IsNullOrEmpty(searchString))
            {
                url = "https://localhost:44356/api/exercisedata/listexercises";
            }
            else
            {
                url = $"https://localhost:44356/api/exercisedata/searchexercises?searchString={searchString}";
            }

            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<ExerciseDto> Exercises = response.Content.ReadAsAsync<IEnumerable<ExerciseDto>>().Result;

            ViewBag.search = searchString;
            return View(Exercises);
        }

        // GET: Exercise/Show/{id}
        public ActionResult Show(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44356/api/exercisedata/findexercise/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            ExerciseDto Exercise = response.Content.ReadAsAsync<ExerciseDto>().Result;

            // Fetch all workouts to display in the dropdown
            string workoutsUrl = "https://localhost:44356/api/workoutdata/listworkouts";
            HttpResponseMessage workoutsResponse = client.GetAsync(workoutsUrl).Result;
            IEnumerable<WorkOutDto> WorkOuts = workoutsResponse.Content.ReadAsAsync<IEnumerable<WorkOutDto>>().Result;

            var viewModel = new ExerciseWorkOutViewModel
            {
                Exercise = Exercise,
                WorkOuts = WorkOuts.Select(w => new SelectListItem
                {
                    Value = w.WorkOutId.ToString(),
                    Text = w.Name
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddToWorkoutPlan(ExerciseWorkOutViewModel model)
        {
            // Create a new instance of WorkOutPlan
            WorkOutPlan workoutPlan = new WorkOutPlan
            {
                ExerciseId = model.Exercise.ExerciseId,
                ExerciseName = model.Exercise.ExerciseName,
                Reps = model.Exercise.Reps,
                sets = model.Exercise.sets,
                BodyPart = model.Exercise.BodyPart,
                WorkOutId = model.WorkOutId // Set the foreign key
            };

            // Add the new workout plan to the database
            using (var db = new ApplicationDbContext())
            {
                db.WorkOutPlans.Add(workoutPlan);
                db.SaveChanges();
            }

            // Redirect to the list of workout plans
            return RedirectToAction("List", "Exercise");
        }
    }
}
