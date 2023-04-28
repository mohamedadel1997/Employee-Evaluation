using DomainLayer;
using DomainLayer.MigrationFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entities;
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();

        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = _applicationDbContext.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query;
        }
        public T Get(int id, string includeProperties = null)
        {
            T query = null;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = entities.Include(includeProperty).SingleOrDefault(e => e.Id == id);
                }
            }
            else
            {
                query = entities.SingleOrDefault(e => e.Id == id);
            }
            return query;
        }
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
            return entity;
        }
        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _applicationDbContext.SaveChanges();
            return entity;
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }        
        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        
    }
}
