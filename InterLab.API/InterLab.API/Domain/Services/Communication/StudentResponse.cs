using System;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.IServices.Communication;

namespace InterLab.API.Domain.IServices.Communication
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
