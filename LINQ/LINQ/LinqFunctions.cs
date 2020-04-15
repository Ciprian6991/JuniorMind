using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
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

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            ThrowIfNullSource(source);
            ThrowIfNullSelector(selector);

            foreach (var element in source)
            {
                yield return selector(element);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            ThrowIfNullSource(source);
            ThrowIfNullSelector(selector);

            foreach (var root in source)
            {
                foreach (var child in selector(root))
                {
                    yield return child;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            ThrowIfNullSource(source);
            ThrowIfNullSelector(predicate);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            ThrowIfNullSource(source);
            ThrowIfNullSelector(keySelector);
            ThrowIfNullSelector(elementSelector);

            Dictionary<TKey, TElement> dictionar = new Dictionary<TKey, TElement>();

            foreach (var element in source)
            {
                dictionar.Add(keySelector(element), elementSelector(element));
            }

            return dictionar;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            var shortestLength = first.Count() < second.Count() ? first.Count() : second.Count();

            for (int i = 0; i < shortestLength; i++)
            {
                yield return resultSelector(first.ElementAt(i), second.ElementAt(i));
            }
        }

        private static Exception ArgumentNullException(string msg)
        {
            throw new ArgumentNullException(msg);
        }

        private static void ThrowIfNullSelector<TSource, TResult>(Func<TSource, TResult> selector)
        {
            if (selector != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(selector));
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
