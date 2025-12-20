namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLegibile {
        // 全ID
        int[] IDs { get; }
        // 総数
        int Longitudo { get; }
        // Dux管理化に登録されているか
        bool EstServam(int id);
        // 非実体化IDを取得
        int LegoIDIntactus();
        // 実体化しているか。
        bool EstActivum(int id);
    }
}