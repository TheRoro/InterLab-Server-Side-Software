using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Models

{
    public class Profile
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public string Degree { get; set; }
        public string Description { get; set; }


        //Relationships
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int InternshipId { get; set; }
        public Internship Internship { get; set; }
    }
}
