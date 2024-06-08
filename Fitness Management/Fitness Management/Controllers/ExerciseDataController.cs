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

        [HttpGet]
        [Route("api/ExerciseData/ListExercises")]
        public List<ExerciseDto> ListExercises()
        {
            List<Exercise> Exercises = db.Exercises.ToList();

            List<ExerciseDto> ExerciseDtos = new List<ExerciseDto>();

            foreach (Exercise Exercise in Exercises)
            {
                ExerciseDto ExerciseDto = new ExerciseDto
                {
                    ExerciseId = Exercise.ExerciseId,
                    ExerciseName = Exercise.ExerciseName,
                    Reps = Exercise.Reps,
                    sets = Exercise.sets,
                    BodyPart = Exercise.BodyPart
                };

                ExerciseDtos.Add(ExerciseDto);
            }

            return ExerciseDtos;
        }

        [HttpGet]
        [Route("api/ExerciseData/SearchExercises")]
        public List<ExerciseDto> SearchExercises(string searchString)
        {
            var query = $"SELECT * FROM Exercises WHERE ExerciseName LIKE '%{searchString}%'";
            var exercises = db.Exercises.SqlQuery(query).ToList();

            List<ExerciseDto> ExerciseDtos = new List<ExerciseDto>();

            foreach (Exercise exercise in exercises)
            {
                ExerciseDto exerciseDto = new ExerciseDto
                {
                    ExerciseId = exercise.ExerciseId,
                    ExerciseName = exercise.ExerciseName,
                    Reps = exercise.Reps,
                    sets = exercise.sets,
                    BodyPart = exercise.BodyPart
                };

                ExerciseDtos.Add(exerciseDto);
            }

            return ExerciseDtos;
        }

        [HttpGet]
        [Route("api/ExerciseData/FindExercise/{id}")]
        public ExerciseDto FindExercise(int Id)
        {
            Exercise Exercise = db.Exercises.Find(Id);

            ExerciseDto ExerciseDto = new ExerciseDto
            {
                ExerciseId = Exercise.ExerciseId,
                ExerciseName = Exercise.ExerciseName,
                Reps = Exercise.Reps,
                sets = Exercise.sets,
                BodyPart = Exercise.BodyPart
            };

            return ExerciseDto;
        }
    }
}
