using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Resources
{
    public class CompanyResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sector { get; set; }
        public string Mail { get; set; }
        public string Phone_Number { get; set; }

    }
}
