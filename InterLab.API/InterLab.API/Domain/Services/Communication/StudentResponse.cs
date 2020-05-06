using System;
using InterLab.API.Domain.Models;

namespace InterLab.API.Domain.Services.Communication
{
    public class StudentResponse : BaseResponse
    {
        public Student Student { get; private set; }

        public StudentResponse(bool success, string message, Student student) : base(success, message)
        {
            Student = student;
        }

        public StudentResponse(Student student) : this(true, string.Empty, student) { }

        public StudentResponse(string message) : this(false, message, null) { }


    }
}
