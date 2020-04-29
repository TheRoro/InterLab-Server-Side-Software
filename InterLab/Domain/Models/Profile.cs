using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Models

{
    public class Profile
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public string Degree { get; set; }
        public string Description { get; set; }


        //RelationShips


        public IList<Student> Students { get; set; } = new List<Student>();

        public IList<Internship> Internships { get; set; } = new List<Internship>();
    }
}
