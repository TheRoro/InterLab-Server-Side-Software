using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Models
{
    public class Proces
    {
        public int Id { get; set; }

        public string Description { get; set; }

        //Relation
    
        public int Rolid { get; set; }

        public Role Role { get; set; }
    
    }
}
