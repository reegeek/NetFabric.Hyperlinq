using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SumRange(int start, int count)
            => count * (start + start + count) / 2;
        
#if NET5_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult SumRange<TResult, TVectorSelector, TSelector>(int start, int count, TVectorSelector vectorSelector, TSelector selector)
            where TVectorSelector : struct, IFunction<Vector<int>, Vector<TResult>>
            where TSelector : struct, IFunction<int, TResult>
            where TResult : struct
        {
            var sum = default(TResult);

            var index = 0;

            if (Vector.IsHardwareAccelerated && count >= Vector<TResult>.Count) // use SIMD
            {
                Span<int> seed = stackalloc int[Vector<TResult>.Count]; 
                if (start is 0)
                {
                    for (; index < seed.Length; index++)
                        seed[index] = index;
                }
                else
                {
                    for (; index < seed.Length; index++)
                        seed[index] = index + start;
                }

                var vector = new Vector<int>(seed);
                var vectorIncrement = new Vector<int>(Vector<TResult>.Count);
                var vectorSum = Vector<TResult>.Zero;
                for (; index <= count - Vector<TResult>.Count; index += Vector<TResult>.Count)
                {
                    vectorSum += vectorSelector.Invoke(vector);
                    vector += vectorIncrement;
                }

                for (index = 0; index < Vector<TResult>.Count; index++)
                    sum = GenericsOperator.Add(vectorSum[index], sum);
            }

            if (start is 0)
            {
                for (; index < count; index++)
                    sum = GenericsOperator.Add(selector.Invoke(index), sum);
            }
            else
            {
                for (; index < count; index++)
                    sum = GenericsOperator.Add(selector.Invoke(index + start), sum);
            }

            return sum;
        }
#endif
    }
}
