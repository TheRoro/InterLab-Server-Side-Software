
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class UserCompany //Many to Many Table
    {
        //One to Many with User
        public int UserId { get; set; }
        public User User { get; set; }

        //One to Many with Company
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
