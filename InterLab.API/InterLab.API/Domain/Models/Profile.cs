using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Field { get; set; }

        public int semester { get; set; }

        public string Degree { get; set; }

        public string Description { get; set; }

        //RelatiONShips

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int Intershipid { get; set; }
        public Internship Internship { get; set; }

    }
}
