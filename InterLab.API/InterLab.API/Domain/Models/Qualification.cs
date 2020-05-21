using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public double Score { get; set; }


        //Relationhips
        public int StudentId { get; set; } 
        public Student Student { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
