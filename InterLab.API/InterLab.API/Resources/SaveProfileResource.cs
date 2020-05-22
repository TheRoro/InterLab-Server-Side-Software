using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Resources
{
    public class SaveProfileResource
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Field { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]

        //Only Student Properties
        public string University { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public int Semester { get; set; }
    }
}

