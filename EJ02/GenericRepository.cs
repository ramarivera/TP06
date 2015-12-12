using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;

namespace EJ02
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        //internal DbSet<TEntity> dbset;
        internal DbContext context;


        public GenericRepository() { }

        public GenericRepository(DbContext context)
        {
            this.context = context;
            //DbSet<TEntity> set = context.Set<TEntity>();
            //this.dbset = context.Set(typeof(TEntity));
            //this.dbset = context.Set<TEntity>();
            //this.dbset.Load();
        }


        public virtual IQueryable<TEntity> Queryable
        {
            get
            {
                return (IQueryable <TEntity>) this.context.Set<TEntity>().AsQueryable();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return (TEntity) this.context.Set<TEntity>().Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = this.GetByID(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry<TEntity>(entityToDelete).State == EntityState.Detached)
            {
                context.Set<TEntity>().Attach(entityToDelete);
            }
            context.Entry<TEntity>(entityToDelete).State = EntityState.Deleted;
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            //this.dbset.Add(entityToUpdate);

            context.Entry<TEntity>(entityToUpdate).State = EntityState.Modified;
        }
    }
}
