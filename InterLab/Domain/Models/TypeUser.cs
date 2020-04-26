using System;
using System.ComponentModel;


namespace InterLab.Domain.Models
{
    public enum TypeUser : byte
    {
        [Description("Student")]
        Student = 1,
        [Description("Entrepreneurs")]
        Entrepreneur = 2,
    }
}
