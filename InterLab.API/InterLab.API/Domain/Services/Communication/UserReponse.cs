using System;
using InterLab.API.Domain.Models;

namespace InterLab.API.Domain.Services.Communication
{
    public class UserReponse : BaseResponse<User>
    {

        public UserReponse(User user) : base(user) { }

        public UserReponse(string message) : base(message) { }


    }
}
