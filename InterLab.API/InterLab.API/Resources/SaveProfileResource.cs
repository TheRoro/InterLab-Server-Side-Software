﻿using System;
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
        public string Role { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Field { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        //Only Student Properties
        public string University { get; set; }
        public string Degree { get; set; }
        public int Semester { get; set; }
    }
}

