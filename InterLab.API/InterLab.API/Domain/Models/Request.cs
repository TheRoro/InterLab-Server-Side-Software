using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Request
    {

        //Relationships:

        //One to Many with Student
        public int UserId { get; set; }
        public User User { get; set; }

        //One to Many with Internship
        public int InternshipId { get; set; }
        public Internship Internship { get; set; }

        
    }
}