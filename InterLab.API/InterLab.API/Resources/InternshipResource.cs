﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Resources
{
    public class InternshipResource
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public DateTime DatePublished { get; set; } //Set is only used on creation ask Angel
        public DateTime StartingDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public double Salary { get; set; }
    }
}