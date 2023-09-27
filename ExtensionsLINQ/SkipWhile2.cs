using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.ExtensionsLINQ
{
  public static class LinqExtensions2

    {
        public static IEnumerable<T> SkipWhile2<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool skip = true;
            foreach (var item in source)
            {
                if (skip && predicate(item))
                {
                    continue;
                }
                skip = false;
                yield return item;
            }
        }
    }
}
