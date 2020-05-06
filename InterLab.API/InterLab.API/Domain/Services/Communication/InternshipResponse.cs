using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services.Communication
{
    public class InternshipResponse : BaseResponse
    {
        public Internship Internship { get; private set; }

        public InternshipResponse(bool success, string message, Internship internship) : base(success, message)
        {
            Internship = internship;
        }

        public InternshipResponse(Internship internship) : this(true, string.Empty, internship) { }

        public InternshipResponse(string message) : this(false, message, null) { }


    }
}
