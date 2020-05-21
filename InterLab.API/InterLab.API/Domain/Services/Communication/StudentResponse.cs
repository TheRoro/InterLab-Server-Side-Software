using System;
using InterLab.API.Domain.Models;

namespace InterLab.API.Domain.Services.Communication
{
    public class StudentResponse : BaseResponse<Student>
    {

        public StudentResponse(Student student) : base(student) { }

        public StudentResponse(string message) : base(message) { }


    }
}
