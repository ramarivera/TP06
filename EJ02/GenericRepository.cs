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
            this.dbset.Load();
        }

       /* public IQueryable Queryable
        {
            get
            {
                IQueryable lAlgo = this.dbset.AsQueryable();


                return lAlgo;


               // this.context.Entry<TEntity>()
            }
        }*/

         public IQueryable<TEntity> Queryable
        {
            get
            {
                IQueryable<TEntity> lAlgo = (IQueryable <TEntity>) this.dbset.AsQueryable();


               /* foreach (TEntity item in lAlgo)
                {
                    this.context.Entry(item)
                }*/
                

                return lAlgo;


               // this.context.Entry<TEntity>()
            }
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
            /* object buscado = this.dbset.Find(entityToDelete);
             if (buscado == null)
             {

             }
             if (context.Personas.Where(per => per == entityToDelete).SingleOrDefault<Persona>() == null)
             {

             }
             dbset.Remove(entityToDelete);*/
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbset.Attach(entityToDelete);
            }

            Persona temp = entityToDelete as Persona;

            if (temp !=  null)
            {
                foreach (var tel in temp.Telefonos)
                {
                    Console.WriteLine("Estado: {0}",context.Entry(tel).State.ToString());
                }
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
