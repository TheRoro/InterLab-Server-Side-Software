using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services.Communication
{
    public class QualificationResponse : BaseResponse<Qualification>
    {
        public QualificationResponse(Qualification qualification) : base(qualification) { }
        public QualificationResponse(string message) : base(message) { }
    }
}
