﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        public static async ValueTask<bool> ContainsAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                        return true;
                }
            }
            return false;
        }

        public static ValueTask<bool> ContainsAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (Utils.UseDefault(comparer))
                return DefaultContainsAsync(source, value, cancellationToken);

            return ComparerContainsAsync(source, value, comparer, cancellationToken);

            static async ValueTask<bool> DefaultContainsAsync(TEnumerable source, TSource value, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                            return true;
                    }
                }
                return false;
            }

            static async ValueTask<bool> ComparerContainsAsync(TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer, CancellationToken cancellationToken)
            {
                comparer ??= EqualityComparer<TSource>.Default;
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (comparer.Equals(enumerator.Current, value))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}
