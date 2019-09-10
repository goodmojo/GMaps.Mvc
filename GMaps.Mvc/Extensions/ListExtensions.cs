using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMaps.Mvc.Extensions
{
    public static class ListExtensions
    {
        public static void Prioritize<T>(this List<T> list, params Func<T,bool>[] predicates)
        {
            var parts = predicates.Select(x => new List<T>()).ToList();
            parts.Add(new List<T>());
            foreach(var item in list)
            {
                bool match = false;
                for(int i = 0; i < predicates.Length;i++)
                {
                    var predicate = predicates[i];
                    match = predicate(item);
                    if (match)
                    {
                        parts[i].Add(item);
                        break;
                    }
                }
                if(!match)
                    parts.Last().Add(item);
            }
            list.Clear();
            foreach (var part in parts)
                list.AddRange(part);
        }
    }
}
