using InterLab.API.Domain.IServices.InterfaceServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsServices _studentsServices;
    }

    public StudentsController(IStudentsServices studentsServices)
    {
        _studentsServices = studentsServices;
    }
}
