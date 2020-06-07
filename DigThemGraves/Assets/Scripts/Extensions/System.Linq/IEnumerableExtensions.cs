using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigThemGraves
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Do<T>(this IEnumerable<T> it, Action<T> action)
        {
            foreach (var item in it)
            {
                action(item);
            }
            return it;
        }
    }
}
