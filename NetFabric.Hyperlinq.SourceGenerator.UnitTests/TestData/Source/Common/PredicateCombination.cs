﻿namespace NetFabric.Hyperlinq
{
    public struct PredicateCombination<TPredicate1, TPredicate2, TSource>
        : IFunction<TSource, bool>
        where TPredicate1 : struct, IFunction<TSource, bool>
        where TPredicate2 : struct, IFunction<TSource, bool>
    {
        TPredicate1 first;
        TPredicate2 second;

        public PredicateCombination(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public bool Invoke(TSource item)
            => first.Invoke(item) && second.Invoke(item);
    }
}
