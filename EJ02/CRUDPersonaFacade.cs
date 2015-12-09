using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EJ02
{
    public class CRUDPersonaFacade
    {
        public UnitOfWork iUnitOfWork;

        public virtual void Create(Persona pPersona)
        {
            using (iUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork.PersonaRepository.Insert(pPersona);
                /*foreach (var item in pPersona.Telefonos)
                {
                    this.iUnitOfWork.TelefonoRepository.Insert(item);
                }*/
                this.iUnitOfWork.Save();
            }

        }

        public virtual void Update(Persona pPersona)
        {
            using (iUnitOfWork = new UnitOfWork())
            {
                Persona lPersonaOriginal = this.iUnitOfWork.PersonaRepository.GetByID(pPersona.PersonaId);

                if (lPersonaOriginal != null)
                {
                    // Entry<TEntity>(original).CurrentValues.SetValues(current)


                    foreach (var telefono in pPersona.Telefonos)                    // Recorro los telefonos de pPersona para Actualizar / Agregar
                    {
                        // if (lTemp.Telefonos.FirstOrDefault(t => t.TelefonoId == telefono.TelefonoId) == null)
                        if (telefono.TelefonoId == 0)
                        {
                            // Agregar
                            this.iUnitOfWork.TelefonoRepository.Insert(telefono);
                        }
                        else
                        {
                            // Actualizar
                            this.iUnitOfWork.TelefonoRepository.Update(telefono);
                        }
                    }
                    /*
                    foreach (var telefono in lTemp.Telefonos)                       // Recorro los telefonos de lTemp par eliminar los que no esten en pPersona
                    {
                        if (pPersona.Telefonos.FirstOrDefault(t => t.TelefonoId == telefono.TelefonoId) == null)
                        {
                            this.iUnitOfWork.TelefonoRepository.Delete(telefono);
                        }
                    }
                    */

                    /*this.iUnitOfWork.PersonaRepository.context.Entry<Persona>(lPersonaOriginal).CurrentValues.SetValues(pPersona);
                    this.iUnitOfWork.PersonaRepository.Update(lPersonaOriginal);*/

                    this.iUnitOfWork.PersonaRepository.Update(pPersona);
                    this.iUnitOfWork.Save();
                }
                else
                {
                    // Si lTemp es nulo singifica  que la persona no esta cargada y por lo tanto hubo un error
                }


            }
        }

        public virtual void Delete(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork.PersonaRepository.Delete(pPersona.PersonaId);
                this.iUnitOfWork.Save();
            }
        }

        public virtual List<Persona> GetAll()
        {
            List<Persona> lResultado = new List<Persona>();
            using (iUnitOfWork = new UnitOfWork())
            {
                var query = this.iUnitOfWork.PersonaRepository.Queryable.Include(p => p.Telefonos).AsNoTracking();//.Select(p => p);
                // var query = (new AgendaContext()).Set<Persona>().Include(p => p.Telefonos);
                //query.Load();
                lResultado = query.ToList<Persona>();
            }
            return lResultado;
        }

        public virtual Persona GetById(int pPersona)
        {
            Persona lResultado;
            using (iUnitOfWork = new UnitOfWork())
            {
                var query = (from persona in this.iUnitOfWork.PersonaRepository.Queryable.Include(p => p.Telefonos).AsNoTracking()
                             where persona.PersonaId == pPersona
                             select persona);

                lResultado = query.FirstOrDefault<Persona>();
            }
            return lResultado;
        }
    }
}
