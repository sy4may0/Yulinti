using System;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOstiumCivisMutabile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstActivum(int id);

        // 実体化
        void Incarnare(int id);
        // 実体化解除
        void Spirituare(int id);
    }
}