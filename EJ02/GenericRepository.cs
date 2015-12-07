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
        internal DbSet<TEntity> dbset;
        internal AgendaContext context;


        public GenericRepository() { }

        public GenericRepository(AgendaContext context)
        {
            this.context = context;
            //DbSet<TEntity> set = context.Set<TEntity>();
            //this.dbset = context.Set(typeof(TEntity));
            this.dbset = context.Set<TEntity>();
            //this.dbset.Load();
        }


        public IQueryable<TEntity> Queryable
        {
            get
            {
                return (IQueryable <TEntity>) this.dbset.AsQueryable();
            }
        }

        public TEntity GetByID(object id)
        {
            return (TEntity) this.dbset.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbset.Add(entity);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = this.GetByID(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            
        }

        public void Update(TEntity entityToUpdate)
        {
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
