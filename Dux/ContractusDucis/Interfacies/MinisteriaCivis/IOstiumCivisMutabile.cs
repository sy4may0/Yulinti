using System;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisMutabile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstActivum(int id);

        // 実体化
        void Incarnare(int id);
        // 実体化解除
        void Spirituare(int id);

        // 自動生成終了
        void TerminareGenerare();

        // 全員奴隷化完了フラグを立てる
        void Servare();

        // 実体化完了時に呼ばれる
        void PonoAdIncarnare(Action<int> adIncarnare);
        // 実体化解除完了時に呼ばれる
        void PonoAdSpirituare(Action<int> adSpirituare);
    }
}