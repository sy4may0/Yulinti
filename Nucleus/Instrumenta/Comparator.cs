using System.Collections.Generic;

namespace Yulinti.Nucleus {
    public sealed class ComparatorReferentialis<T>: IEqualityComparer<T> where T : class {
        public static readonly ComparatorReferentialis<T> Instantia = new();

        public bool Equals(T x, T y) => ReferenceEquals(x, y);
        public int GetHashCode(T obj) => System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
    }
}
