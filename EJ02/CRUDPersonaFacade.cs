using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    class CRUDPersonaFacade
    {
        public UnitOfWork iUnitOfWork;


        public void Create(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork.PersonaRepository.Insert(pPersona);

                foreach (Telefono tel in pPersona.Telefonos)
                {
                    this.iUnitOfWork.TelefonoRepository.Insert(tel);
                }

                this.iUnitOfWork.Save();
            }

        }

        public void Update(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork.PersonaRepository.Update(pPersona);

                foreach (Telefono tel in pPersona.Telefonos)
                {
                    this.iUnitOfWork.TelefonoRepository.Update(tel);
                }

                this.iUnitOfWork.Save();
            }
        }

        public void Delete(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {

                foreach (Telefono tel in pPersona.Telefonos)
                {
                    this.iUnitOfWork.TelefonoRepository.Delete(tel);
                }

                this.iUnitOfWork.PersonaRepository.Delete(pPersona);

                this.iUnitOfWork.Save();
            }
        }

        public List<Persona> GetAll()
        {
            //List<Persona> lListaPersonas;
            using (this.iUnitOfWork = new UnitOfWork())
            {
                /*lListaPersonas = iUnitOfWork.PersonaRepository
                   .Queryable.OfType<Persona>().ToList<Persona>();
                List<Telefono> lListaTelefonos = iUnitOfWork.TelefonoRepository
                    .Queryable.OfType<Telefono>().ToList<Telefono>();*/
                return iUnitOfWork.PersonaRepository
                                  .Queryable.OfType<Persona>().ToList<Persona>();

            }
        }

        public Persona GetById(int pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                return this.iUnitOfWork.PersonaRepository.GetByID(pPersona);
            }
        }
    }
}
