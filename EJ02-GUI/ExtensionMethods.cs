using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02.UI
{
    public static class Extension
    {
        public static BindingList<T> ToBindingList<T>(this IList<T> source)
        {
            return new BindingList<T>(source);
        }
    }
}
