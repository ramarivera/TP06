using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            using (this.iUnitOfWork = new UnitOfWork())
            {
                iUnitOfWork.PersonaRepository.Insert(pPersona);
                iUnitOfWork.Save();
            }

        }

        public void Update(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                iUnitOfWork.PersonaRepository.Update(pPersona);
                iUnitOfWork.Save();
            }

        }

        public void Delete(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                Persona mPersona = iUnitOfWork.PersonaRepository.GetByID(pPersona.PersonaId);
                iUnitOfWork.PersonaRepository.Delete(mPersona);
                iUnitOfWork.Save();
            }

        }

        public List<Persona> GetAll()
        {
            List<Persona> lResultado = new List<Persona>();
            using (this.iUnitOfWork = new UnitOfWork())
            {
                var query = this.iUnitOfWork.PersonaRepository.Queryable.Include(p => p.Telefonos);
                lResultado = query.ToList<Persona>();
            }
            return lResultado;

        }

        public Persona GetById(int pPersonaId)
        {
            Persona lResultado;

            using (this.iUnitOfWork = new UnitOfWork())
            {
                var query = (from persona in this.iUnitOfWork.PersonaRepository.Queryable.Include(p => p.Telefonos)//;.AsNoTracking()
                             where persona.PersonaId == pPersonaId
                             select persona);

                lResultado = query.FirstOrDefault<Persona>();
            }
            return lResultado;

        }


    }
}