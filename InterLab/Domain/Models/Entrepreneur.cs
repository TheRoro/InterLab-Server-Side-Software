using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Models
 
{
    public class Entrepreneur
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Id_RUC { get; set; }

        //RelationShips

        public IList<Internship> Internships { get; set; } = new List<Internship>();
    }
}
