using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        //Relationships
        //uno a uno con intenships
        public int InternshipId { get; set; }
        public Internship Internship { get; set; }
        //muchos a muchos con workers
        public IList<Worker> Workers { get; set; } = new List<Worker>();
        //muchos a muchos con processes
        public IList<Process> Processes { get; set; } = new List<Process>();

    }
}
