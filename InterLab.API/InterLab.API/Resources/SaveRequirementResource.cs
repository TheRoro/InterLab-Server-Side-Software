using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InterLab.API.Resources
{
    public class SaveRequirementResource
    {
        [Required]
        [MaxLength(30)]
        public string Field { get; set; }
        [MaxLength(10)]
        public int Semester { get; set; }
        [MaxLength(30)]
        public string Degree { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
