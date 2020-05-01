using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string University { get; set; }

        //Relationships
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public IList<Document> Documents { get; set; } = new List<Document>();
        public IList<Qualification> Qualifications { get; set; } = new List<Qualification>();
        public IList<Request> Requests { get; set; } = new List<Request>();

    }

}
