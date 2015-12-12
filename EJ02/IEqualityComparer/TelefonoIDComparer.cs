using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02.IEqualityComparers
{

    public class TelefonoIdComparer : IEqualityComparer<Telefono>
    {
        bool IEqualityComparer<Telefono>.Equals(Telefono t1, Telefono t2)
        {
            if (object.ReferenceEquals(t1, t2))
            {
                return true;
            }
            if (object.ReferenceEquals(t1, null) ||
                object.ReferenceEquals(t2, null))
            {
                return false;
            }
            return t1.TelefonoId == t2.TelefonoId;
        }

        int IEqualityComparer<Telefono>.GetHashCode(Telefono tel)
        {
            return tel == null ? 0 : tel.TelefonoId.GetHashCode();
        }
    }
}