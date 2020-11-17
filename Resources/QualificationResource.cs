using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Resources
{
    public class QualificationResource
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }
        public string Author { get; set; }
    }
}
