using Application.Abstract;
using Microsoft.EntityFrameworkCore;
using Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DatabaseContext _context;
        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public void Delete(int id)
        {
            var user = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(user);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChangesAsync();
        }
    }
}
