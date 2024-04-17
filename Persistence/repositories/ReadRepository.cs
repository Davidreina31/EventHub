using Persistence.contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly EventHubDbContext _context;

        public ReadRepository(EventHubDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
