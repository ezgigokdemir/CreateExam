using SinavOlusturma.Data;
using SinavOlusturma.Entities;
using SinavOlusturma.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext db;

        public UnitofWork(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            return new Repository<TEntity>(db);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}