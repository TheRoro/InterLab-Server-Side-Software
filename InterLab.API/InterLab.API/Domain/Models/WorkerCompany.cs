
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class WorkerCompany //Many to Many Table
    {
        //One to Many with Worker
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        //One to Many with Company
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
