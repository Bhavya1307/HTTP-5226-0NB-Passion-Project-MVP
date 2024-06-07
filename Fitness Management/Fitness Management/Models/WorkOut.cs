using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Management.Models
{
    public class WorkOut
    {
        [Key]
        public int WorkOutId { get; set; }
        public string WorkOutName { get; set; }
    }

    public class WorkOutDto
    {
        public int WorkOutId { get; set; }
        public string Name { get; set; }
    }

}