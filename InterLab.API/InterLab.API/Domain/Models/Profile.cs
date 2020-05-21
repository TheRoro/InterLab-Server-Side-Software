using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Field { get; set; }

        public int Semester { get; set; } 

        public string Degree { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; } 

        public string City { get; set; }

        //RelatiONShips

       // public int UserId { get; set; }
        //public Users User { get; set; }


    }
}
