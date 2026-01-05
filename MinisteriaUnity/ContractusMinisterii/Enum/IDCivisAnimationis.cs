namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public enum IDCivisAnimationisStratum {
        // ファンダメンタル層は0固定としてくれ。
        Fundamentum = 0,
        Corpus = 1,
        Pars = 2
    }

    public enum IDCivisAnimationis {
        None,
        NihilCorporis,
        NihilPartis,
        StandardBase
    }

    public enum IDCivisAnimationisContinuata {
        None,
        // Fundamenti
        StandardBase,

        // Corpus
        NihilCorporis,

        // Pars
        NihilPartis
    }
}