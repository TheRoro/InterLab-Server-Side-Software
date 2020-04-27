using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Models
{
    public class University
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }


        public IList<Student> Students { get; set; } = new List<Student>();
    }
}