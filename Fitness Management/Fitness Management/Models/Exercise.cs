using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Fitness_Management.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int Reps { get; set; }
        public int sets { get; set; }
        public string BodyPart { get; set; }
    }

    public class ExerciseDto
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int Reps { get; set; }
        public int sets { get; set; }
        public string BodyPart { get; set; }
    }
}

