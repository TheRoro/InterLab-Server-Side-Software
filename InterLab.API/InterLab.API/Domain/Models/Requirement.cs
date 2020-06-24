using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public int Semester { get; set; }

        //Relationships:

        //One to One with Internship
        public int InternshipId { get; set; }
        public Internship Internship { get; set; }


    }
}
