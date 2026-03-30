using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
