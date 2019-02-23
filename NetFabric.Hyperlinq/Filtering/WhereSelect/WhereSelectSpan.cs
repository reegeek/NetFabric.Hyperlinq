﻿using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        internal static WhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this Span<TSource> source, 
            Func<TSource, bool> predicate, 
            Func<TSource, TResult> selector) 
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new WhereSelectEnumerable<TSource, TResult>(source, predicate, selector);
        }

        public readonly ref struct WhereSelectEnumerable<TSource, TResult>
        {
            readonly Span<TSource> source;
            readonly Func<TSource, bool> predicate;
            readonly Func<TSource, TResult> selector;

            internal WhereSelectEnumerable(Span<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator
            {
                readonly Span<TSource> source;
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public TResult Current => selector(source[index]);

                public bool MoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                            return true;

                        index++;
                    }
                    return false;
                }
            }

            public int Count()
                => source.Count(predicate);

            public TResult First()
                => selector(source.First(predicate));

            public TResult FirstOrDefault()
                => selector(source.FirstOrDefault(predicate));

            public TResult Single()
                => selector(source.Single(predicate));

            public TResult SingleOrDefault()
                => selector(source.SingleOrDefault(predicate));
        }
    }
}

