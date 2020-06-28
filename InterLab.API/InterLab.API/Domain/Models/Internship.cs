 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Internship
    {

        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string PublicationDate { get; set; }
        public string StartingDate { get; set; }
        public string FinishingDate { get; set; }
        public double Salary { get; set; }
        public string RequiredDocuments { get; set; }

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
