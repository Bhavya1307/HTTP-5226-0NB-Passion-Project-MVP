using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fitness_Management.Models;

namespace Fitness_Management.Controllers
{
    public class ExerciseDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Returns a list of exercises
        /// </summary>
        /// <returns>An array of exercises</returns>
        /// <example>
        /// //GET: /api/ExerciseData/ListExercises -> [{"ExerciseId":1,"ExerciseName":"Ab Crunch","Reps":10,"sets":3,"BodyPart":"Abs"},{"ExerciseId":2,"ExerciseName":"Ab Roll Outs","Reps":12,"sets":3,"BodyPart":"Abs"}]
        /// </example>
        [HttpGet]
        [Route("api/ExerciseData/ListExercises")]
        public List<ExerciseDto> ListExercises()
        {
            List<Exercise> Exercises = db.Exercises.ToList();

            List<ExerciseDto> ExerciseDtos = new List<ExerciseDto>();

            foreach(Exercise Exercise in Exercises)
            {
                ExerciseDto ExerciseDto = new ExerciseDto();
                ExerciseDto.ExerciseId = Exercise.ExerciseId;
                ExerciseDto.ExerciseName = Exercise.ExerciseName;
                ExerciseDto.Reps = Exercise.Reps;
                ExerciseDto.sets = Exercise.sets;
                ExerciseDto.BodyPart = Exercise.BodyPart;

                ExerciseDtos.Add(ExerciseDto);
            }

            return ExerciseDtos;
        }
        [HttpGet]
        [Route("api/ExerciseData/FindExercise/{id}")]
        public ExerciseDto FindExercise(int Id)
        {
            Exercise Exercise = db.Exercises.Find(Id);


            ExerciseDto ExerciseDto = new ExerciseDto();
            ExerciseDto.ExerciseId = Exercise.ExerciseId;
            ExerciseDto.ExerciseName = Exercise.ExerciseName;
            ExerciseDto.Reps = Exercise.Reps;
            ExerciseDto.sets = Exercise.sets;
            ExerciseDto.BodyPart = Exercise.BodyPart;



            return ExerciseDto;
        }
    }
}
