using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Reprenseta una lista de objetos afectados por una transacion de negocios
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        private AgendaContext context = new AgendaContext();
        private GenericRepository<Persona> iPersonaRepository;
        private GenericRepository<Telefono> iTelefonoRepository;

        /// <summary>
        /// Obtiene el Repositorio Persona
        /// </summary>
        public GenericRepository<Persona> PersonaRepository
        {
            get
            {
                if (this.iPersonaRepository == null)
                {
                    this.iPersonaRepository = new GenericRepository<Persona>(context);
                }
                return this.iPersonaRepository;
            }
        }

        /// <summary>
        /// Obtiene el Repositorio Telefono
        /// </summary>
        public GenericRepository<Telefono> TelefonoRepository
        {
            get
            {
                if (this.iTelefonoRepository == null)
                {
                    this.iTelefonoRepository = new GenericRepository<Telefono>(context);
                }
                return this.iTelefonoRepository;
            }
        }

        /// <summary>
        /// Guarda los cambios correspondientes a la transaccion de negocios
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        /// <summary>
        /// Libera los recursos utilizados por <see cref="UnitOfWork"/>
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Libera los recursos utilizados por <see cref="UnitOfWork"/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
