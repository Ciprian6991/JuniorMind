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
            ThrowIfNullSource(first);
            ThrowIfNullSource(second);

            var shortestLength = first.Count() < second.Count() ? first.Count() : second.Count();

            for (int i = 0; i < shortestLength; i++)
            {
                yield return resultSelector(first.ElementAt(i), second.ElementAt(i));
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            ThrowIfNullSource(source);

            TAccumulate result = seed;

            foreach (var element in source)
            {
                result = func(result, element);
            }

            return result;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
                                                                                this IEnumerable<TOuter> outer,
                                                                                IEnumerable<TInner> inner,
                                                                                Func<TOuter, TKey> outerKeySelector,
                                                                                Func<TInner, TKey> innerKeySelector,
                                                                                Func<TOuter, TInner, TResult> resultSelector)
        {
            ThrowIfNullSource(outer);
            ThrowIfNullSource(inner);
            ThrowIfNullSelector(outerKeySelector);
            ThrowIfNullSelector(innerKeySelector);

            if (resultSelector == null)
            {
                throw ArgumentNullException(nameof(resultSelector));
            }

            foreach (var outerVar in outer)
            {
                var outerKey = outerKeySelector(outerVar);

                foreach (var innerVar in inner)
                {
                    var innerKey = innerKeySelector(innerVar);

                    if (innerKey.Equals(outerKey))
                    {
                        yield return resultSelector(outerVar, innerVar);
                    }
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            ThrowIfNullSource(source);

            return new HashSet<TSource>(source, comparer);
        }

        public static IEnumerable<TSource> Union<TSource>(
                                                            this IEnumerable<TSource> first,
                                                            IEnumerable<TSource> second,
                                                            IEqualityComparer<TSource> comparer)
        {
            ThrowIfNullSource(first);
            ThrowIfNullSource(second);

            var result = new HashSet<TSource>(first, comparer);

            result.UnionWith(second);

            return result;
        }

        public static IEnumerable<TSource> Intersect<TSource>(
                                                                this IEnumerable<TSource> first,
                                                                IEnumerable<TSource> second,
                                                                IEqualityComparer<TSource> comparer)
        {
            ThrowIfNullSource(first);
            ThrowIfNullSource(second);

            var result = new HashSet<TSource>(first, comparer);

            result.IntersectWith(second);

            return result;
        }

        public static IEnumerable<TSource> Except<TSource>(
                                                            this IEnumerable<TSource> first,
                                                            IEnumerable<TSource> second,
                                                            IEqualityComparer<TSource> comparer)
        {
            ThrowIfNullSource(first);
            ThrowIfNullSource(second);

            var result = new HashSet<TSource>(first, comparer);

            var intersect = Intersect(first, second, comparer);

            result.ExceptWith(intersect);

            return result;
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
