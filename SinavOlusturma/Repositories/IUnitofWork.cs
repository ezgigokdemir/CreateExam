using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Repositories
{
    public interface IUnitofWork
    {
        void SaveChanges();

        IRepository<TEntity> Repository<TEntity>() where TEntity : SinavOlusturma.Entities.BaseEntity;
    }
}