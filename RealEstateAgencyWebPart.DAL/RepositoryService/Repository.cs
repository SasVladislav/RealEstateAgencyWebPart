using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgencyWebPart.DAL.EF;
using System.Data.Entity.Migrations;
using System.Linq.Expressions;

namespace RealEstateAgencyWebPart.DAL.RepositoryService
{
    public class Repository<TEntity> where TEntity : class
    {
        private DbContext Context;
        public Repository()
        {
            Context = new RealEstateDbContext();
        }
        public virtual TEntity Create(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Set<TEntity>().AddOrUpdate(entity);
            return entity;
        }

        public virtual void Delete(int id)
        {
            var item = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(item);
        }

        public virtual TEntity FindById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> where = null)
        {
            return Context.Set<TEntity>().FirstOrDefault(where);
        }

        public virtual ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null)
        {
            return null != where ? Context.Set<TEntity>().Where(where).ToList() : Context.Set<TEntity>().ToList();
        }

        public virtual bool SaveChanges()
        {
            return 0 < Context.SaveChanges();
        }
    }
}
