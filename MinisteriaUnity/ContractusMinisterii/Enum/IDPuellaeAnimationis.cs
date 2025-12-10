namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public enum IDPuellaeAnimationisStratum {
        // ファンダメンタル層は0固定としてくれ。
        Fundamentum = 0,
        Corpus = 1,
        Pars = 2
    }

    // これはUnicaeに対応する。
    // 1Clip = 1ID
    public enum IDPuellaeAnimationis {
        None,
        NihilCorporis,
        NihilPartis,
        StandardBase,
        Crouch,
    }

    // これはContinuataに対応する。
    public enum IDPuellaeAnimationisContinuata {
        None,
        StandardBase,
        Crouch
    }
}
