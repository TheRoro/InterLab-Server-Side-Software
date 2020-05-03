using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Process
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        //Relation

        public IList<Role> Roles { get; set; } = new List<Role>();

    }
}
