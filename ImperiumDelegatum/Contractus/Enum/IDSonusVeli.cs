namespace Yulinti.ImperiumDelegatum.Contractus {
    public enum IDSonusVeli {
        Nihil,
        Submittere,        // Submmit
        SubmittereAdditum, // 強いSubmit
        Exire,             // キャンセルとか。
        Supervolare,       // ホバー(ナビゲート)
        Activare,          // トグルOnとか。
        Deactivare,        // トグルOffとか。
        Cursor,            // スライダーの操作音とか。
        Demittere,         // UIが開く音とか。
        Tollere,           // UIが閉じる音とか。
        Notare,            // 通知音とか。
        Error             // エラー音とか。
    }
}