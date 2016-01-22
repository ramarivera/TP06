using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    public class UnitOfWork : IDisposable
    {
        private AgendaContext context = new AgendaContext();
        private GenericRepository<Persona> iPersonaRepository;
        private GenericRepository<Telefono> iTelefonoRepository;

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

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
