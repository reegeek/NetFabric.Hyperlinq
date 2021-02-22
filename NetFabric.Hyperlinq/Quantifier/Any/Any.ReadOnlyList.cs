using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TList, TSource>(this TList source)
            where TList : struct, IReadOnlyList<TSource>
            => source.Any<TList, TSource>(0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool Any<TList, TSource>(this TList source, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => count is not 0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TList, TSource>(this TList source, Func<TSource, bool> predicate)
            where TList : struct, IReadOnlyList<TSource>
            => source.Any(predicate, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool Any<TList, TSource>(this TList source, Func<TSource, bool> predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => source.Any<TList, TSource, FunctionWrapper<TSource, bool>>(new FunctionWrapper<TSource, bool>(predicate), offset, count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TList, TSource, TPredicate>(this TList source, TPredicate predicate)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Any<TList, TSource, TPredicate>(predicate, 0, source.Count);

        static bool Any<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                    return true;
            }
            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TList, TSource>(this TList source, Func<TSource, int, bool> predicate)
            where TList : struct, IReadOnlyList<TSource>
            => source.Any(predicate, 0, source.Count);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool Any<TList, TSource>(this TList source, Func<TSource, int, bool> predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => source.AnyAt<TList, TSource, FunctionWrapper<TSource, int, bool>>(new FunctionWrapper<TSource, int, bool>(predicate),  offset, count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.AnyAt<TList, TSource, TPredicate>(predicate, 0, source.Count);

        static bool AnyAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (offset is 0)
            {
                for (var index = 0; index < count; index++)
                {
                    var item = source[index];
                    if (predicate.Invoke(item, index))
                        return true;
                }
            }
            else
            {
                for (var index = 0; index < count; index++)
                {
                    var item = source[index + offset];
                    if (predicate.Invoke(item, index))
                        return true;
                }
            }
            return false;
        }
    }
}

