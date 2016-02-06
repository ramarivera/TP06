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
    /// <summary>
    /// Funciona como intermediario entre la lógica de negocio y la lógica de acceso a base de datos
    /// </summary>
    /// <typeparam name="TEntity">Tipo del contenido del repositorio</typeparam>
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal AgendaContext context;
        internal DbSet<TEntity> dbSet;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(AgendaContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Devuelve una coleccion <see cref="IQueryable"/>
        /// </summary>
        public IQueryable<TEntity> Queryable
        {
            get
            {
                return dbSet.AsNoTracking<TEntity>();
            }
        }

        /// <summary>
        /// Obtiene una entidad de la base de datos que se corresponda con el id especificado
        /// </summary>
        /// <param name="id">id de la entidad a obtener</param>
        /// <returns>entidad que se corresponde con el id especificado</returns>
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Inserta una entidad en la base de datos
        /// </summary>
        /// <param name="entity">Entidad a insertar</param>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Elimina la entidad que se corresponda con el id especificado
        /// </summary>
        /// <param name="id">id de la entidad a eliminar</param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Elimina una entidad especificada de la base de datos
        /// </summary>
        /// <param name="entityToDelete">entidad de eliminar</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Modifica una entidad de la base de datos
        /// </summary>
        /// <param name="entityToUpdate">entidad a modificar</param>
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
