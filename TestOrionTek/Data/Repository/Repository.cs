using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TestOrionTek.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public TestOrionTek_apiContext _ApiContext { get; set; }
        private DbSet<T> entities;
        public Repository(TestOrionTek_apiContext ApiContext )
        {
            _ApiContext = ApiContext;
            entities = _ApiContext.Set<T>();
        }

        public void Add(T entity)
        {
           _ApiContext.Set<T>().Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _ApiContext.Set<T>().AsNoTracking();    
            return query;
        }

        public T GetById(int id)
        {
            var value = _ApiContext.Set<T>().Find(id);
            return value ?? throw new ArgumentNullException(nameof(value));
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate)
        {
            var query = _ApiContext.Set<T>().Where(predicate);
            return query;
        }

        public IEnumerable<T> IncludesAll(string[] includes)
        {
            if (includes.Length > 0)
            {
                foreach (string include in includes)
                {
                    entities.Include(include);
                }
                return entities;
            }
            else throw new Exception("Debe incluir una o mas tablas al parametro includes[]!!!");
        }
        public void Delete(T entity)
        {
            //var data = _context.Set<T>().Find(id);
            _ApiContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _ApiContext.Entry(entity).State = EntityState.Modified;
        }

    }
}
