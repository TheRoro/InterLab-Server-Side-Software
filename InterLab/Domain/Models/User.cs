using Microsoft.AspNetCore.SignalR;
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
        public string Password { get; set; }
        public long Phone_Number { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public TypeUser TypeUser { get; set; }

        //Muestra lista
        public IList<Student> Student = new List<Student>();

        public IList<Entrepreneur> Entrepreneurs = new List<Entrepreneur>();


    }

}
