using System;
using System.Collections.Generic;

namespace xyj.core.Utility
{
    //var comparer1 = Comparison<Person>.CreateComparer(p => p.ID);
    public static class Comparison<T>
    {
        public static IComparer<T> CreateComparer<V>(Func<T, V> keySelector)
        {
            return new CommonComparer<V>(keySelector);
        }

        public static IComparer<T> CreateComparer<V>(Func<T, V> keySelector, IComparer<V> comparer)
        {
            return new CommonComparer<V>(keySelector, comparer);
        }

        private class CommonComparer<V> : IComparer<T>
        {
            private readonly IComparer<V> comparer;
            private readonly Func<T, V> keySelector;

            public CommonComparer(Func<T, V> keySelector, IComparer<V> comparer)
            {
                this.keySelector = keySelector;
                this.comparer = comparer;
            }

            public CommonComparer(Func<T, V> keySelector)
                : this(keySelector, Comparer<V>.Default)
            {
            }

            public int Compare(T x, T y)
            {
                return comparer.Compare(keySelector(x), keySelector(y));
            }
        }
    }

}
