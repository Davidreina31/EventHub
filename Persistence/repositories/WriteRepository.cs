using Application.contracts;
using Persistence.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly EventHubDbContext _context;

        public WriteRepository(EventHubDbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Guid id)
        {
            var objectToRemove = await _context.Set<T>().FindAsync(id);

            if (objectToRemove != null)
            {
                _context.Set<T>().Remove(objectToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
