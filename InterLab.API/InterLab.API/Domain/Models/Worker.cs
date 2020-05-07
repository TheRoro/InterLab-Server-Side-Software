using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
 
{
    public class Worker
    {
        //Relationships

        public int Userid { get; set; }

        public Users Users { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public IList<Role> Roles { get; set; } = new List<Role>();

        public IList<Profile> Profile { get; set; } = new List<Profile>();

    }
}
