namespace Yulinti.Exercitus.Contractus {
    public interface ITurrisIntroductionis {
        //// Motus ////
        // 移動入力
        System.Numerics.Vector2 LegoMotus { get; }
        // 走行入力
        bool LegoCursus { get; }
        // しゃがみ入力 
        bool LegoIncumbo { get; }

        //// Velum ////
        // クリック入力
        bool LegoClick { get; }
        // 右クリック入力
        bool LegoClickRight { get; }
        // サブミット入力
        bool LegoSubmit { get; }
        // キャンセル入力
        bool LegoCancel { get; }
        // ナビゲーション入力
        bool LegoNavigate { get; }

        // Action //
        // エモートアクション入力
        bool LegoSpectaculumCorporis { get; }

        void DebugEnabled();
    }
}