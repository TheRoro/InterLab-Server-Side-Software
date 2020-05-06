using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
 
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //Relationships

        public int RoleId { get; set;  }
        public Role Role { get; set; }

        public int ProfileId { get; set; }

        public Profile Profile { get; set; } 

        public IList<Company> Companies { get; set; } = new List<Company>();

    }
}
