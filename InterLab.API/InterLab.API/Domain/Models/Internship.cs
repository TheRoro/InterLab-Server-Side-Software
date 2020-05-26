 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Internship
    {

        public int Id { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public double Salary { get; set; }

        //Relationships:

        //One to One with Requirement
        public Requirement Requirement { get; set; }

        //One to Many with Request
        public IList<Request> Requests { get; set; } = new List<Request>();

        //One to Many with Worker
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
