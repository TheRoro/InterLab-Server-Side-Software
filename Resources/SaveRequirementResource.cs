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
        public int Semester { get; set; }
    }


}