using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.IServices;
using InterLab.API.Controllers;


namespace InterLab.API.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
    }

}
