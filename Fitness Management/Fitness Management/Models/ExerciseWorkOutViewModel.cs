using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness_Management.Models
{
    public class ExerciseWorkOutViewModel
    {
        public ExerciseDto Exercise { get; set; }
        public int WorkOutId { get; set; } // Add this property
        public List<SelectListItem> WorkOuts { get; set; } // For the dropdown list
    }
}
