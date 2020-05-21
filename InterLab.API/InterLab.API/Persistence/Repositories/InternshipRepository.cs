﻿using InterLab.API.Domain.Models;
using InterLab.API.Domain.Repositories;
using InterLab.API.Domain.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Persistence.Repositories
{
    public class InternshipRepository : BaseRepository, IInternshipRepository
    {
        InternshipRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Internship>> ListAsync()
        {
            return await _context.Internships.ToListAsync();
        }
    }
}