using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Models
{
    public class Internship
    {

        public int Id { get; set; }
        
        public string State { get; set; }

        public string Description { get; set; }

        public DateTime DatePublished { get; set; } //Set is only used on creation ask Angel

        public DateTime StartingDate { get; set; }

        public DateTime FinishingDate { get; set; }

        public double Salary { get; set; }

        public int Participants { get; set; }

        //Relation
        public int EntrepreneurId { get; set; }
        public Entrepreneur Entrepreneur {get; set;}

        public IList<Request> Requests { get; set; } = new List<Request>();
    }
}
