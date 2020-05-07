using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }


        //Relationships
        public int UserId { get; set; }

        public Users Users { get; set; }



        public IList<Document> Documents { get; set; } = new List<Document>();
        public IList<Qualification> Qualifications { get; set; } = new List<Qualification>();
        public IList<Request> Requests { get; set; } = new List<Request>();
        public IList<Profile> Profile { get; set; } = new List<Profile>();

    }

}
