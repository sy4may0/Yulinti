using System;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOstiumCivisMutabile {
        int Longitudo { get; }
        bool EstActivum(int id);

        // 実体化
        void Incarnare(int id);
        // 実体化解除
        void Spirituare(int id);

        // Schema指定生成
        void Manifestatio(IDCivisPersonae idCivisPersonae);
        // 削除
        void Deleto(int id);
    }
}