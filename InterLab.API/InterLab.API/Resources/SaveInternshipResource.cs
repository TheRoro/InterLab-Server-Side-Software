﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Resources
{
    public class SaveInternshipResource
    {
        [Required]
        public string State { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
        [Required]
        public DateTime StartingDate { get; set; }
        [Required]
        public DateTime FinishingDate { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string RequiredDocuments { get; set; }
        [Required]
        public string JobTitle { get; set; }
    }
}
