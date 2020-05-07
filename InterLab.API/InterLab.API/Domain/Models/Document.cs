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
        //public fileclass Document { get; set; }
        //ask data type for document: byte?

        //Relationships
        public int UserId { get; set; } 
        public Student Student { get; set; }

    }
}
