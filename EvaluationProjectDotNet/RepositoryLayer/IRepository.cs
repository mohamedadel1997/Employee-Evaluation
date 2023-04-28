using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        T Get(int id, string includeProperties = null);
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
