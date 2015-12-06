using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EJ02
{
    class CRUDPersonaFacade
    {
        //public UnitOfWork iUnitOfWork;


        public void Create(Persona pPersona)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.PersonaRepository.Insert(pPersona);
                /*foreach (var item in pPersona.Telefonos)
                {
                    uow.TelefonoRepository.Insert(item);
                }*/
                uow.Save();
            }
          
        }

        public void Update(Persona pPersona)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {

                uow.Save();
            }
        }

        public void Delete(Persona pPersona)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {

                uow.Save();
            }
        }

        public List<Persona> GetAll()
        {
            List<Persona> lResultado = new List<Persona>();
            using (UnitOfWork uow = new UnitOfWork())
            {
                var query = uow.PersonaRepository.Queryable.Include(p => p.Telefonos).Select(p => p);
                // var query = (new AgendaContext()).Set<Persona>().Include(p => p.Telefonos);
                query.Load();
                lResultado = query.ToList<Persona>();
            }
            return lResultado;
        }

        public Persona GetById(int pPersona)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.PersonaRepository.GetByID(pPersona);
            }
        }
    }
}
