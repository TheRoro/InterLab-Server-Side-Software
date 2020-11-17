using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services.Communication
{
    public class CompanyResponse : BaseResponse<Company>
    {
        public CompanyResponse(Company company) : base(company) { }
        public CompanyResponse(string message) : base(message) { }
    }
}
