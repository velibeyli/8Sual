using System.Linq.Expressions;

namespace _8Sual.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByFilter(Expression<Func<T, bool>> filter = default);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = default);
    }
}
