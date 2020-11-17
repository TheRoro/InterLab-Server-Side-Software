using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services.Communication
{
    public class RequestResponse : BaseResponse<Request>
    {
        public RequestResponse(Request request) : base(request) { }

        public RequestResponse(string message) : base(message) { }
    }
}
