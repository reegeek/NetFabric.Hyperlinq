using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueReadOnlyCollectionWrapper<T> AsValueReadOnlyCollection<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                _ => new ValueReadOnlyCollectionWrapper<T>(source)
            };

        public readonly struct ValueReadOnlyCollectionWrapper<T> 
            : IValueReadOnlyCollection<T, Enumerator<T>>
        {
            readonly T[] source;

            internal ValueReadOnlyCollectionWrapper(T[] source)
                => this.source = source;

            public readonly int Count 
                => source.Length;

            public readonly Enumerator<T> GetEnumerator() 
                => new(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator()
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator<T>(source);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyCollectionExtensions.ValueEnumerable<ValueReadOnlyCollectionWrapper<T>, Enumerator<T>, Enumerator<T>, T, GetEnumeratorFunction, GetEnumeratorFunction> AsValueEnumerable()
                => ReadOnlyCollectionExtensions.AsValueEnumerable<ValueReadOnlyCollectionWrapper<T>, Enumerator<T>, T, GetEnumeratorFunction>(this);
            
            public readonly struct GetEnumeratorFunction
                : IFunction<ValueReadOnlyCollectionWrapper<T>, Enumerator<T>>
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public Enumerator<T> Invoke(ValueReadOnlyCollectionWrapper<T> enumerable) 
                    => enumerable.GetEnumerator();
            }
        }
    }
}