using DevCourseHub.Application.Interfaces.Repository;
using DevCourseHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<IEnumerable<T>> FindAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
          _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
