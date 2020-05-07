using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string State { get; set; }
        public DateTime DateSend { get; set; } 


        //Relation con internship y con student
        public int UserId { get; set; } 
        public Student Student { get; set; }

        public int InternshipId { get; set; }
        public Internship Internship { get; set; }

        
    }
}