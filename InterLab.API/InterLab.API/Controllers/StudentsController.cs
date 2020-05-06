using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Services;
using InterLab.API.Controllers;
using AutoMapper;
using InterLab.API.Persistence.Repositories;
using InterLab.API.Resources;

namespace InterLab.API.Controllers
{
    [Route("/api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;   
        private readonly IMapper _mapper; 


        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentResource>> GetAllAsync()
        {
            var students = await _studentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResource>>(students);
            return resources;
        }


    }

}
