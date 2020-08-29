using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SinavOlusturma.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Find(int id);

        IEnumerable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition, Expression<Func<T, object>> orderCondition = null, bool desc = false, int? skip = null, int? take = null, string[] includeProperties = null);

        IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition, out int records, Expression<Func<T, object>> orderCondition = null, bool desc = false, int? skip = null, int? take = null, string[] includeProperties = null);

        T GetSingle(Expression<Func<T, bool>> expression, string[] includeProperties = null);
    }
}