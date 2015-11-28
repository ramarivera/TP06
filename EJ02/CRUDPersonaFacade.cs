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

                /*foreach (Telefono tel in pPersona.Telefonos)
                {
                    this.iUnitOfWork.TelefonoRepository.Insert(tel);
                }*/

                this.iUnitOfWork.Save();
            }

        }

        public void Update(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork.PersonaRepository.Update(pPersona);

               /* foreach (Telefono tel in pPersona.Telefonos)
                {
                    this.iUnitOfWork.TelefonoRepository.Update(tel);
                }*/

                this.iUnitOfWork.Save();
            }
        }

        public void Delete(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {

               /* foreach (Telefono tel in pPersona.Telefonos)
                {
                    this.iUnitOfWork.TelefonoRepository.Delete(tel);
                }*/

                this.iUnitOfWork.PersonaRepository.Delete(pPersona);

                this.iUnitOfWork.Save();
            }
        }

        public List<Persona> GetAll()
        {
            IQueryable<Persona> lListaPersonas;
            IQueryable<Telefono> lListaTelefonos;
            using (this.iUnitOfWork = new UnitOfWork())
            {
                // IQueryable<Persona> lCosa =  iUnitOfWork.PersonaRepository.Queryable;//.OfType<Persona>()
                //lListaPersonas = iUnitOfWork.PersonaRepository.Queryable.OfType<Persona>().ToList<Persona>();

                lListaPersonas = iUnitOfWork.PersonaRepository.Queryable;
                lListaTelefonos = iUnitOfWork.TelefonoRepository.Queryable;


                /*foreach (var item in lListaPersonas)
                {
                    item.Telefonos.AddRange(lListaTelefonos.Where(t => t.id))
                }*/



                /*foreach (var item in lListaPersonas)
                {
                    item.
                    item.Telefonos.Load();
                }*/
                /*List<Telefono> lListaTelefonos = iUnitOfWork.TelefonoRepository
                    .Queryable.OfType<Telefono>().ToList<Telefono>();
                 iUnitOfWork.PersonaRepository
                                  .Queryable.OfType<Persona>().ToList<Persona>();*/
                return lListaPersonas.ToList<Persona>();

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
