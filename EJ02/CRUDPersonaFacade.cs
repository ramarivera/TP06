using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Clase Facade del ejercicio 2 TP6, abstrae implementaciones del modelo
    /// </summary>
    public class CRUDPersonaFacade
    {
        private UnitOfWork iUnitOfWork = new UnitOfWork();

        /// <summary>
        /// Agregar una <see cref="Persona"/> al repositorio correspondiente y guarda los cambios
        /// </summary>
        /// <param name="pPersona">Persona a agregar</param>
        public void Create(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                iUnitOfWork.PersonaRepository.Insert(pPersona);
                iUnitOfWork.Save();
            }

        }

        /// <summary>
        /// Modifica una <see cref="Persona"/> existente en el repositorio y guarda los cambios
        /// </summary>
        /// <param name="pPersona">Persona a modificar</param>
        public void Update(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                Persona lPersona = (from persona in iUnitOfWork.PersonaRepository.Queryable
                                    where persona.PersonaId == pPersona.PersonaId
                                    select persona).SingleOrDefault();



                foreach (Telefono lTelefono in lPersona.Telefonos.Reverse<Telefono>())
                {
                    if (! pPersona.Telefonos.Any(t => t.TelefonoId == lTelefono.TelefonoId))
                    {
                        //lPersona.Telefonos.Remove(lTelefono);
                        iUnitOfWork.TelefonoRepository.Delete(lTelefono);
                    }
                }


                foreach (var pTelefono in pPersona.Telefonos)                    // Recorro los telefonos de pPersona para Actualizar / Agregar
                {
                    if (pTelefono.TelefonoId == 0)
                    {
                        // Agregar
                        //lPersona.Telefonos.Add(telefono);
                        iUnitOfWork.TelefonoRepository.Insert(pTelefono);
                    }
                    else
                    {
                        // Actualizar
                        //lPersona.Telefonos.  
                        // lPersona.Telefonos.Remove(telefono);   lPersona.Telefonos.Add(telefono);
                        //lPersona.Telefonos[lPersona.Telefonos.IndexOf(telefono)] = telefono;
                        iUnitOfWork.TelefonoRepository.Update(pTelefono);
                    }
                }

       /*         var local = iUnitOfWork.context.Personas.Local
                                            .FirstOrDefault(f => f.PersonaId == pPersona.PersonaId);
                if (local != null)
                {
                    iUnitOfWork.context.Entry(local).State = EntityState.Detached;
                }
                */

              //  iUnitOfWork.context.Entry(lPersona).CurrentValues.SetValues(pPersona);
                iUnitOfWork.PersonaRepository.Update(pPersona);
                iUnitOfWork.Save();
            }

        }

        /// <summary>
        /// Elimina una <see cref="Persona"/> existente en el repositorio y guarda los cambios
        /// </summary>
        /// <param name="pPersona">Persona a eliminar</param>
        public void Delete(Persona pPersona)
        {
            using (this.iUnitOfWork = new UnitOfWork())
            {
                Persona mPersona = iUnitOfWork.PersonaRepository.GetByID(pPersona.PersonaId);
                iUnitOfWork.PersonaRepository.Delete(mPersona);
                iUnitOfWork.Save();
            }

        }

        /// <summary>
        /// Obtiene todas las <see cref="Persona"/> almacenadas en el repositorio
        /// </summary>
        /// <returns>Lista de las <see cref="Personas"/> en el repositorio</returns>
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

        /// <summary>
        /// Obtiene la <see cref="Persona"/> que se corresponda con el id especificado
        /// </summary>
        /// <param name="pPersonaId">id de la <see cref="Persona"/> a obtener</param>
        /// <returns><see cref="Persona"/> que se corresponde con el id indicado</returns>
        public Persona GetById(int pPersonaId)
        {
            Persona lResultado;

            using (this.iUnitOfWork = new UnitOfWork())
            {
                var query = (from persona in iUnitOfWork.PersonaRepository.Queryable.Include(p => p.Telefonos)
                             where persona.PersonaId == pPersonaId
                             select persona);

                lResultado = query.FirstOrDefault<Persona>();
            }
            return lResultado;

        }
    }
}