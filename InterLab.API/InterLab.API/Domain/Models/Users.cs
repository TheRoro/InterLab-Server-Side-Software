using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Users
    {

        public int Id { get; set; }  
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Type { get; set; }

        //Relationships

        public IList<UserData> UserDatas { get; set; } = new List<UserData>();

        public IList<Student> Students { get; set; } = new List<Student>();

        public IList<Worker> Workers { get; set; } = new List<Worker>();

    }
}
