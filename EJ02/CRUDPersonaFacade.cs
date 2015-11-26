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

                foreach (Telefono tel in pPersona.Telefonos)
                {
                    this.iUnitOfWork.TelefonoRepository.Insert(tel);
                }

                this.iUnitOfWork.Save();
            }
           
        }

        public void Update (Persona pPersona)
        {
           
        }

        public void Delete (Persona pPersona)
        {

        }

        public List<Persona> GetAll()
        {
            List<Persona> lista = new List<Persona>();
            return lista;
        }

        public Persona GetById (int pPersona)
        {
            Persona pers = new Persona();
            return pers;
        }
    }
}
