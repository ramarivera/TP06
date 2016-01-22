using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    public class CRUDPersonaFacade
    {
        private UnitOfWork iUnitOfWork = new UnitOfWork();

        public void Create(Persona pPersona)
        {
            iUnitOfWork.PersonaRepository.Insert(pPersona);
            iUnitOfWork.Save();
        }

        public void Update(Persona pPersona)
        {
            iUnitOfWork.PersonaRepository.Update(pPersona);
            iUnitOfWork.Save();
        }

        public void Delete(Persona pPersona)
        {
            Persona mPersona = iUnitOfWork.PersonaRepository.GetByID(pPersona.PersonaId);
            iUnitOfWork.PersonaRepository.Delete(mPersona);
            iUnitOfWork.Save();
        }

        public List<Persona> GetAll()
        {
            return iUnitOfWork.PersonaRepository.Queryable.ToList();
        }

        public Persona GetById(int pPersonaId)
        {
            return iUnitOfWork.PersonaRepository.GetByID(pPersonaId); ;
        }




    }
}
