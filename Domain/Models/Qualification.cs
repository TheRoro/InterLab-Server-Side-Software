using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }
        public string Author { get; set; }


        //Relationhips
        public int UserId { get; set; } 
        public User User { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
