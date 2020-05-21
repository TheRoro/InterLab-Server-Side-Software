using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services.Communication
{
    public class InternshipResponse : BaseResponse<Internship>
    {

        public InternshipResponse(Internship internship) : base(internship) { }

        public InternshipResponse(string message) : base(message) { }


    }
}
