using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed;

        private AgendaContext context;

        private GenericRepository<Persona> iPersonaRepository;

        private GenericRepository<Telefono> iTelefonoRepository;

        public UnitOfWork()
        {
            context = new AgendaContext();
            disposed = false;
        }

        /// <summary>
        /// Finaliza una instancia de la clase <see cref="UnitOfWork"/>.
        /// </summary>
        ~UnitOfWork()
        {
            // The object went out of scope and finalized is called
            // Lets call dispose in to release unmanaged resources 
            // the managed resources will anyways be released when GC 
            // runs the next time.
            Dispose(false);
        }


        public virtual GenericRepository<Persona> PersonaRepository
        {
            get
            {
                if (this.iPersonaRepository == null)
                {
                    this.iPersonaRepository = new GenericRepository<Persona>(context);
                    //{ context = this.context, dbset = this.context.Set<Persona>() };
                }
                return this.iPersonaRepository;
            }
        }

        public virtual GenericRepository<Telefono> TelefonoRepository
        {
            get
            {
                if (this.iTelefonoRepository == null)
                {
                    this.iTelefonoRepository = new GenericRepository<Telefono>(context);
                    //{ context = this.context, dbset = this.context.Set<Telefono>() };
                }
                return this.iTelefonoRepository;
            }
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //someone want the deterministic release of all resources
                //Let us release all the managed resources

                this.iPersonaRepository = null;
                this.iTelefonoRepository = null;
            }
            else
            {
                // Do nothing, no one asked a dispose, the object went out of
                // scope and finalized is called so lets next round of GC 
                // release these resources
            }

            // Release the unmanaged resource in any case as they will not be 
            // released by GC
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
            this.disposed = true;
        }

        public virtual void Dispose()
        {
            // If this function is being called the user wants to release the
            // resources. lets call the Dispose which will do this for us.
            Dispose(true);

            // Now since we have done the cleanup already there is nothing left
            // for the Finalizer to do. So lets tell the GC not to call it later.
            GC.SuppressFinalize(this);
        }


    }
}
