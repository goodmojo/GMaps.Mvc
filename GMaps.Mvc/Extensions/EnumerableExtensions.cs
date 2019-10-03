// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace GMaps.Mvc
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    internal static class EnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> instance, Action<T> action)
        {
            foreach (T item in instance)
            {
                action(item);
            }
        }

        public static IDictionary<string, string> ToDictionary(this NameValueCollection col)
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var k in col.AllKeys)
            {
                dict.Add(k, col[k]);
            }
            return dict;
        }

        /// <summary>
        /// Merges the provided dictionaries assuming that collisions map to identical values.
        /// An error is thrown if this assumption is violated.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="me"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static T MergeCompatible<T, K, V>(this T current, IEnumerable<IDictionary<K, V>> others)
            where T : IDictionary<K, V>, new()
        {
            T newMap = new T();
            var collection = (new List<IDictionary<K, V>> { current }).Concat(others);
            foreach (var src in collection)
            {
                foreach (var p in src)
                {
                    if (newMap.TryGetValue(p.Key, out V value))
                    {
                        if (!value.Equals(p.Value))
                            throw new Exception($"Value mismatch at key '{p.Key}': {value} != {p.Value}");
                        continue;
                    }
                    newMap[p.Key] = p.Value;
                }
            }
            return newMap;
        }

        /// <summary>
        /// Merges the provided dictionaries assuming that collisions map to identical values.
        /// An error is thrown if this assumption is violated.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="me"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static T MergeCompatible<T, K, V>(this T current, params IDictionary<K, V>[] others)
            where T : IDictionary<K, V>, new()
        => current.MergeCompatible(others.AsEnumerable());

        /// <summary>
        /// Merges the provided dictionaries assuming that collisions map to identical values.
        /// An error is thrown if this assumption is violated.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="me"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static Dictionary<K,V> MergeCompatible<K, V>(this IEnumerable<IDictionary<K,V>> dicts)
        {
            var first = dicts.FirstOrDefault().ToDictionary(x => x.Key, x=> x.Value);
            if (first == null)
                return new Dictionary<K, V>();
            var others = dicts.Skip(1).ToList();
            var merged = first.MergeCompatible(others);
            return merged;
        }
    }
}
