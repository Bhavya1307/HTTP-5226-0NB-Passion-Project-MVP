/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Fitness_Management.Models;

namespace Fitness_Management.Controllers
{
    public class ExerciseController : Controller
    {
        // GET: Exercise/List
        public ActionResult List()
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44356/api/exercisedata/listexercises";

            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<ExerciseDto> Exercises = response.Content.ReadAsAsync < IEnumerable<ExerciseDto>>().Result;
            return View(Exercises);
        }

        // GET: Exercise/Show/{id}
        public ActionResult Show(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44356/api/exercisedata/findexercise/"+id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            ExerciseDto Exercise = response.Content.ReadAsAsync<ExerciseDto>().Result;
            return View(Exercise);
        }
    }
}*/

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
            string url = "https://localhost:44356/api/ExerciseData/ListExercises";

            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<ExerciseDto> exercises = response.Content.ReadAsAsync<IEnumerable<ExerciseDto>>().Result;

            if (!string.IsNullOrEmpty(searchString))
            {
                exercises = exercises.Where(e => e.ExerciseName.Contains(searchString));
            }

            return View(exercises);
        }

        // GET: Exercise/Show/{id}
        public ActionResult Show(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44356/api/ExerciseData/FindExercise/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            ExerciseDto exercise = response.Content.ReadAsAsync<ExerciseDto>().Result;
            return View(exercise);
        }
    }
}
