using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness_Management.Models
{
    public class WorkOutDetailsViewModel
    {
        public WorkOutDto WorkOut { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
    }
}