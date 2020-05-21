using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
 
{
    public class Worker
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public string Type { get; set; }

        //Relationships:

        //One to many with Internships
        public IList<Internship> Internships { get; set; } = new List<Internship>();

        //One to one with Profile
        public Profile Profile { get; set; }

        //Many to Many with Company
        public List<WorkerCompany> WorkerCompanies { get; set; }
    }
}
