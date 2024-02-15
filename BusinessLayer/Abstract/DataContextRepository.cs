using BusinessLayer.Repository;
using DataAccessLayer;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public class DataContextRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _db;

        public DataContextRepository(DataContext db)
        {
            _db = db;
        }

        public void Delete(T entity)
        {
            _db.Remove(entity); 
            _db.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression);
        }

        public T GetBy(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().FirstOrDefault(expression);
        }

        public void Insert(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
        }
    }
}
