using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Representa el teléfono de una persona de la agenda telefónica
    /// </summary>
    public class Telefono
    {
        public int TelefonoId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }

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

            Telefono lTelefono = obj as Telefono;
            if (lTelefono == null)
            {
                return false;
            }

            return (this.TelefonoId == lTelefono.TelefonoId);
        }

        public override int GetHashCode()
        {
            return !Object.ReferenceEquals(null, this) ? this.TelefonoId.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return String.Format("Telefono, id: {0}, numero: [1], tipo: {2}", TelefonoId, Numero, Tipo);
        }

    }
}
