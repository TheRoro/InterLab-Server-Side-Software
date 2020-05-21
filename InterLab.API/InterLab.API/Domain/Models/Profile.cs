using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
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

        //Relationships:
        //One to One with Student
        public int StudentId { get; set; }
        public Student Student { get; set; }
        //One to One With Worker
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

    }
}
