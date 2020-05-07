using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models

{
    public class UserData   
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Date_Register { get; set; }
        public string Phone_numbre  { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public bool Type { get; set; }


        //Relationships
      public int UserId { get; set; }

      public Users User { get; set; }
    }
}
