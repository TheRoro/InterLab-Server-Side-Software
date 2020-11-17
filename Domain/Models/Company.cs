using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Sector { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //Puede ser servicio google maps
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        //Relationships:

        //One to many with Qualifications
        public IList<Qualification> Qualifications { get; set; } = new List<Qualification>();

        //Many to Many with User
        public List<UserCompany> UserCompanies { get; set; }

        //One To Many with Internship
        public IList<Internship> Internships { get; set; } = new List<Internship>();
    }
}
