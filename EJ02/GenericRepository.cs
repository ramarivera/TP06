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
    public class GenericRepository<TEntity> where TEntity:class
    {
        internal DbSet dbset;
        internal AgendaContext context;
        // public GenericRepository() { }

        public GenericRepository(AgendaContext context)
        {
            this.context = context;
            this.dbset = context.Set<TEntity>();
        }

        public TEntity GetByID(object id)
        {
            return (TEntity)this.dbset.Find(id);
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
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbset.Attach(entityToDelete);
            }
            dbset.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbset.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
