namespace Yulinti.Exercitus.Contractus {
    public enum IDPuellaeAnimationisStratum {
        // ファンダメンタル層は0固定としてくれ。
        Fundamentum = 0,
        Corpus = 1,
        Pars = 2
    }

    // これはContinuataに対応する。
    public enum IDPuellaeAnimationisContinuata {
        None,
        // Fundamenti
        StandardBase,

        // Corpus
        NihilCorporis,
        Crouch,

        // Pars
        NihilPartis

    }

    public enum IDPuellaeAnimationis {
        Nihil,
        Basis,
        StasisBasis,
        Incumbo,
    }
}
