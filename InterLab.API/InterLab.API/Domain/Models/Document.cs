using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.Domain.Models
{
    public class Document
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //ask data type for document: byte?

        //Relation
        public int StuedntId { get; set; }
        public Student Student { get; set; }
    }
}
