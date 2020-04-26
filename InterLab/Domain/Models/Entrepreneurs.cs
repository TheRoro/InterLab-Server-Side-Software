using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Models
{
    public class Entrepreneurs
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int Id_RUC { get; set; }

        //RelationShips
        public IList<User> Users { get; set; } = new List<User>();

    }
}
