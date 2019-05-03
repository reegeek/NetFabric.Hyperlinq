using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class SortedSetBindings
    {
        public static int Count<TSource>(this SortedSet<TSource> source)
            => source.Count;

        public static int Count<TSource>(this SortedSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.Count<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource> Skip<TSource>(this SortedSet<TSource> source, int count)
            => ReadOnlyCollection.Skip<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource> Take<TSource>(this SortedSet<TSource> source, int count)
            => ReadOnlyCollection.Take<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static bool All<TSource>(this SortedSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.All<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Any<TSource>(this SortedSet<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this SortedSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.Any<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Contains<TSource>(this SortedSet<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this SortedSet<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyCollection.Contains<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this SortedSet<TSource> source,
            Func<TSource, long, TResult> selector) 
            => ReadOnlyCollection.Select<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        public static Enumerable.SelectManyEnumerable<ValueWrapper<TSource>,  SortedSet<TSource>.Enumerator,  TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedSet<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => Enumerable.SelectMany<ValueWrapper<TSource>,  SortedSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        public static Enumerable.WhereEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource> Where<TSource>(
            this SortedSet<TSource> source,
            Func<TSource, long, bool> predicate) 
            => Enumerable.Where<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource First<TSource, TValue>(this SortedSet<TSource> source)
            => ReadOnlyCollection.First<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource First<TSource, TValue>(this SortedSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.First<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource FirstOrDefault<TSource, TValue>(this SortedSet<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource FirstOrDefault<TSource, TValue>(this SortedSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource? FirstOrNull<TSource, TValue>(this SortedSet<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource? FirstOrNull<TSource, TValue>(this SortedSet<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource Single<TSource, TValue>(this SortedSet<TSource> source)
            => ReadOnlyCollection.Single<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource Single<TSource, TValue>(this SortedSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.Single<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource SingleOrDefault<TSource, TValue>(this SortedSet<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource SingleOrDefault<TSource, TValue>(this SortedSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource? SingleOrNull<TSource, TValue>(this SortedSet<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource? SingleOrNull<TSource, TValue>(this SortedSet<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static IReadOnlyCollection<TSource> AsEnumerable<TSource>(this SortedSet<TSource> source)
            => source;

        public static ReadOnlyCollection.AsValueEnumerableEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this SortedSet<TSource> source)
            => ReadOnlyCollection.AsValueEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource[] ToArray<TSource>(this SortedSet<TSource> source)
            => ReadOnlyCollection.ToArray<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static List<TSource> ToList<TSource>(this SortedSet<TSource> source)
            => ReadOnlyCollection.ToList<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
            
        public readonly struct ValueWrapper<TSource> : IReadOnlyCollection<TSource>
        {
            readonly SortedSet<TSource> source;

            public ValueWrapper(SortedSet<TSource> source)
            {
                this.source = source;
            }

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            int IReadOnlyCollection<TSource>.Count => source.Count;
        }      
    }
}