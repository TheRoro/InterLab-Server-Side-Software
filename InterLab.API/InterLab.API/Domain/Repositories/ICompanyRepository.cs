﻿using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Repositories
{
    interface ICompanyRepository
    {
        Task<IEnumerable<Company>> ListAsync();
    }
}
