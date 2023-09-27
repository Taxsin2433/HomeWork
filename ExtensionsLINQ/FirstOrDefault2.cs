using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.ExtensionsLINQ
{
    public static class LinqExtensions
    {
        public static T FirstOrDefault2<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }
    }
}
