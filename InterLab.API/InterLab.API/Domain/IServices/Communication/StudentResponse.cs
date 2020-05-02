using System;
using Interlab.API.Domain.Models;

namespace Interlab.API.Domain.IServices.Communication
{
    public class StudentResponse : BaseResponse
    {
        public Student Student { get; private set;  }

        public StudentResponse(bool success, string message, Student student) : base(success, message)
        {
            Student = student;
        }

        public StudentResponse(Student student) : this(true, string.Empty, student) { }

        public StudentResponse(string message) : this(false, message, null) { }


    }
}
