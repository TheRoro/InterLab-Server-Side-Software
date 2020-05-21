using InterLab.API.Domain.Persistence.Contexts;
using InterLab.API.Domain.Repositories;
using System.Threading.Tasks;

namespace InterLab.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        } 
    }
}
