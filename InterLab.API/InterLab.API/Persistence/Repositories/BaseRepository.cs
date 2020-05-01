using InterLab.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Persistence.Repositories
{

    public abstract class BaseRepository
    {

        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
            {
            _context = context;
            }
    }
}
