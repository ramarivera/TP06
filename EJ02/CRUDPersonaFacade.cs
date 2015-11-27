using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    class CRUDPersonaFacade
    {
        private UnitOfWork iUnitOfWork;


        public void Create (Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork.PersonaRepository.Insert(pPersona);

                /*foreach (Telefono tel in pPersona.Telefonos)
                {
                    this.iUnitOfWork.TelefonoRepository.Insert(tel);
                }*/

                this.iUnitOfWork.Save();
            }
           
        }

        public void Update (Persona pPersona)
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

        public void Delete (Persona pPersona)
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
            List<Persona> lista = new List<Persona>();
            return lista;
        }

        public Persona GetById (int pPersona)
        { 
            return this.iUnitOfWork.PersonaRepository.GetByID(pPersona);  
        }
    }
}
