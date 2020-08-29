using Microsoft.EntityFrameworkCore;
using SinavOlusturma.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SinavOlusturma.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal ApplicationDbContext db;
        internal DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.db = context;
            this.entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public T Find(int id)
        {
            return entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition, out int records, Expression<Func<T, object>> orderCondition = null, bool desc = false, int? skip = null, int? take = null, string[] includeProperties = null)
        {
            IQueryable<T> data = entities;

            if (includeProperties != null && includeProperties.Length > 0)
            {
                data = entities.Include(includeProperties[0]);
                for (int i = 1; i < includeProperties.Length; i++)
                {
                    data = data.Include(includeProperties[i]);
                }
            }

            data = data.Where(whereCondition);

            records = data.Count();

            if (orderCondition != null)
            {
                if (desc)
                {
                    data = data.OrderByDescending(orderCondition);
                }
                else
                {
                    data = data.OrderBy(orderCondition);
                }
            }

            if (skip.HasValue)
            {
                data = data.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                data = data.Take(take.Value);
            }

            return data;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition, Expression<Func<T, object>> orderCondition = null, bool desc = false, int? skip = null, int? take = null, string[] includeProperties = null)
        {
            IQueryable<T> data = entities;
            if (includeProperties != null && includeProperties.Length > 0)
            {
                data = entities.Include(includeProperties[0]);
                for (int i = 1; i < includeProperties.Length; i++)
                {
                    data = data.Include(includeProperties[i]);
                }
            }

            data = data.Where(whereCondition);

            if (orderCondition != null)
            {
                if (desc)
                {
                    data = data.OrderByDescending(orderCondition);
                }
                else
                {
                    data = data.OrderBy(orderCondition);
                }
            }

            if (skip.HasValue)
            {
                data = data.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                data = data.Take(take.Value);
            }

            return data;
        }

        public T GetSingle(Expression<Func<T, bool>> expression, string[] includeProperties = null)
        {
            IQueryable<T> data = entities;
            if (includeProperties != null && includeProperties.Length > 0)
            {
                for (int i = 0; i < includeProperties.Length; i++)
                {
                    data = data.Include(includeProperties[i]);
                }
            }
            return data.Where(expression).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            //entitiy.UniqueId = Guid.NewGuid();
            //entities.Add(entitiy);
            entities.Attach(entity);
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}