using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Representa una persona de la agenda telefónica
    /// </summary>
    public class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public virtual IList<Telefono> Telefonos { get; set; }


        public Persona()
        {
            this.Telefonos = new List<Telefono>();
        }

        public override string ToString()
        {
            return String.Format("Persona, id: {0}, nombre: {1} apellido: {2}", PersonaId, Nombre, Apellido);
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(null, obj))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            Persona lPersona = obj as Persona;
            if (lPersona == null)
            {
                return false;
            }

            return (this.PersonaId == lPersona.PersonaId);
        }

        public override int GetHashCode()
        {
            return !Object.ReferenceEquals(null, this) ? this.PersonaId.GetHashCode() : 0;
        }
    }
}
