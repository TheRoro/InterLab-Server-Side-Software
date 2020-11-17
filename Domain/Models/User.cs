using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string DateCreated { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Token { get; set; }

        //Relations Student

        //One to many with Document
        public IList<Document> Documents { get; set; } = new List<Document>();

        //One to many with Request
        public IList<Request> Requests { get; set; } = new List<Request>();

        //One to many with Qualification
        public IList<Qualification> Qualifications { get; set; } = new List<Qualification>();

        //One to one with Profile
        public Profile Profile { get; set; }

        //Relations Worker

        //Many to Many with Company
        public List<UserCompany> UserCompanies { get; set; }

    }
}
