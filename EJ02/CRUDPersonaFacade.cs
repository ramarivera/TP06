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
            iUnitOfWork.PersonaRepository.Insert(pPersona);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Modifica una <see cref="Persona"/> existente en el repositorio y guarda los cambios
        /// </summary>
        /// <param name="pPersona">Persona a modificar</param>
        public void Update(Persona pPersona)
        {
            iUnitOfWork.PersonaRepository.Update(pPersona);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Elimina una <see cref="Persona"/> existente en el repositorio y guarda los cambios
        /// </summary>
        /// <param name="pPersona">Persona a eliminar</param>
        public void Delete(Persona pPersona)
        {
            Persona mPersona = iUnitOfWork.PersonaRepository.GetByID(pPersona.PersonaId);
            iUnitOfWork.PersonaRepository.Delete(mPersona);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Obtiene todas las <see cref="Persona"/> almacenadas en el repositorio
        /// </summary>
        /// <returns>Lista de las <see cref="Personas"/> en el repositorio</returns>
        public List<Persona> GetAll()
        {
            List<Persona> lResultado = new List<Persona>();
            var query = this.iUnitOfWork.PersonaRepository.Queryable.Include(p => p.Telefonos);
            lResultado = query.ToList<Persona>();
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
            var query = (from persona in this.iUnitOfWork.PersonaRepository.Queryable.Include(p => p.Telefonos)//;.AsNoTracking()
                        where persona.PersonaId == pPersonaId
                        select persona);

            lResultado = query.FirstOrDefault<Persona>();
            return lResultado;

        }
    }
}