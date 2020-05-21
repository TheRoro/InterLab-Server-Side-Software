using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string State { get; set; }
        public DateTime CreationDate { get; set; }

        //Relationships:

        //One to Many with Student
        public int StudentId { get; set; }
        public Student Student { get; set; }

        //One to Many with Internship
        public int InternshipId { get; set; }
        public Internship Internship { get; set; }

        
    }
}