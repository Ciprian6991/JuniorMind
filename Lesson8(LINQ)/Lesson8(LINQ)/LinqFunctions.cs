using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8LINQ
{
    public static class LinqFunctions
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            ThrowIfNullSource(source);

            foreach (var element in source)
            {
                if (!predicate(element))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            ThrowIfNullSource(source);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            ThrowIfNullSource(source);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return element;
                }
            }

            throw new InvalidOperationException("No element has been found");
        }

        private static void ThrowIfNullSource<TSource>(IEnumerable<TSource> source)
            {
            if (source != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(source));
        }
    }
}
