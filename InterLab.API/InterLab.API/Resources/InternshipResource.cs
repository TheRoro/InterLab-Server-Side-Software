using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Resources
{
    public class InternshipResource
    {

        public int Id { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string PublicationDate { get; set; }
        public string StartingDate { get; set; }
        public string FinishingDate { get; set; }
        public double Salary { get; set; }
        public string Location { get; set; }
        public string RequiredDocuments { get; set; }
        public string JobTitle { get; set; }
    }
}
