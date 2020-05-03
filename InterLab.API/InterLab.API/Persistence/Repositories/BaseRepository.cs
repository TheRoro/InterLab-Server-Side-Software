using System;
using InterLab.API.Persistence.Contexts;

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
