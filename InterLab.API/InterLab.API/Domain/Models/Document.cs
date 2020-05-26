using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace InterLab.API.Domain.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        //Relationships:

        //Many to one with Student
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
