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
        public string Mail { get; set; }
        public string Phone_Number { get; set; }

        //Puede ser servicio google maps
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        //Relation
        public IList<Worker> Workers { get; set; } = new List<Worker>();

        public IList<Qualification> Qualifications { get; set; } = new List<Qualification>();
    }
}
