using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services.Communication
{
    public class UserCompanyResponse :  BaseResponse<UserCompany>
    {
        public UserCompanyResponse(UserCompany userCompany) : base(userCompany) { }
        public UserCompanyResponse(string message) : base(message) { }
    }
}
