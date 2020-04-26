using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //RelationShips
        public IList<User> Users { get; set; } = new List<User>();
    }

}
