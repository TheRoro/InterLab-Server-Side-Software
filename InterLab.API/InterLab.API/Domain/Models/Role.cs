using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        //Relationships

        public int WorkerId { get; set; } 
        public Worker Worker { get; set; }

        
        //muchos a muchos con processes
        //public IList<Roles_Processes> Roles_Processes { get; set; } = new List<Roles_Processes>();


    }
}
