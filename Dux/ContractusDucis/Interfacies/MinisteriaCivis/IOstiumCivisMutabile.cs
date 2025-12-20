namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisMutabile {
        int[] IDs { get; }
        int Longitudo { get; }
        bool EstActivum(int id);
        // Dux管理化へ登録
        void Dominare(int id);
        // Dux管理化から削除
        void Liberare(int id);

        // 実体化
        void Incarnare(int id);
        // 実体化解除
        void Spirituare(int id);

        // 自動生成終了
        void TerminareGenerare();
    }
}