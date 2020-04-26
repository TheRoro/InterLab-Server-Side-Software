using System;
using System.Collections.Generic;

namespace InterLab.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string password { get; set; }
        public long Phone_Number { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public TypeUser typeUser { get; set; }

        //RelationShips with student
        public int Studentid{ get; set; }
        public Student Student { get; set; }
    
        //RelationShips with Entrepreneirs
        public int EntrepreneurId { get; set; }
        public Entrepreneurs Entrepreneurs { get; set; }

    }

}
