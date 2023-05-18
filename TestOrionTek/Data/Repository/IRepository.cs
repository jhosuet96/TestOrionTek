using System.Linq.Expressions;

namespace TestOrionTek.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        T GetById(int id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate);
        IEnumerable<T> IncludesAll(string[] includes);
        void Delete(T entity);
        void Update(T entity);
    }
}