namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLegibile {
        // 全ID
        int[] IDs { get; }
        // 総数
        int Longitudo { get; }
        // 実体化している総数
        int LongitudoActivum { get; }
        // 非実体化IDを取得
        int LegoIDIntactus();
        // 実体化しているか。
        bool EstActivum(int id);
        // 全員奴隷化完了フラグ
        bool EstServam { get; }
    }
}