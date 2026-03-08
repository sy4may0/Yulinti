namespace Yulinti.Exercitus.Contractus {
    public enum IDPuellaeAnimationisStratum {
        // ファンダメンタル層は0固定としてくれ。
        Fundamentum = 0,
        Corpus = 1,
        Pars = 2
    }

    public enum IDPuellaeAnimationis {
        Nihil,
        Desinere,

        // 基本アニメーション
        Basis,         // Idle/Walk/Runミキサー
        StasisBasis,   //Idle固定
        Incumbo,       // しゃがみ

        // ポーズアニメーション
        SpectaculumFormosa01Int,  // Formosaポーズ01-In
        SpectaculumFormosa01Tra,  // Formosaポーズ01
        SpectaculumFormosa01Exi   // Formosaポーズ01-Exit
    }
}
