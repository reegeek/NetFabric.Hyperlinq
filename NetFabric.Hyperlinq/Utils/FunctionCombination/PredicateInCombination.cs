﻿using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public struct PredicatePredicateCombinationIn<TPredicate1, TPredicate2, TSource>
        : IFunctionIn<TSource, bool>
        where TPredicate1 : struct, IFunctionIn<TSource, bool>
        where TPredicate2 : struct, IFunctionIn<TSource, bool>
    {
        TPredicate1 first;
        TPredicate2 second;

        public PredicatePredicateCombinationIn(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public bool Invoke(in TSource item)
            => first.Invoke(in item) && second.Invoke(in item);
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct PredicatePredicateAtCombinationIn<TPredicate1, TPredicate2, TSource>
        : IFunctionIn<TSource, int, bool>
        where TPredicate1 : struct, IFunctionIn<TSource, bool>
        where TPredicate2 : struct, IFunctionIn<TSource, int, bool>
    {
        TPredicate1 first;
        TPredicate2 second;

        public PredicatePredicateAtCombinationIn(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public bool Invoke(in TSource item, int index)
            => first.Invoke(in item) && second.Invoke(in item, index);
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct PredicateAtPredicateAtCombinationIn<TPredicate1, TPredicate2, TSource>
        : IFunctionIn<TSource, int, bool>
        where TPredicate1 : struct, IFunctionIn<TSource, int, bool>
        where TPredicate2 : struct, IFunctionIn<TSource, int, bool>
    {
        TPredicate1 first;
        TPredicate2 second;

        public PredicateAtPredicateAtCombinationIn(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public bool Invoke(in TSource item, int index)
            => first.Invoke(in item, index) && second.Invoke(in item, index);
    }
}
