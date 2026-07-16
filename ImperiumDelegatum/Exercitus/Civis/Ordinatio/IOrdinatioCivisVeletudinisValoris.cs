namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioCivisVeletudinisValoris : IOrdinatioCivis {
        // 寿命
        float DtVitae { get; }
        // 視力
        float DtVisus { get; }
        // 視認判定
        float DtVisa { get; }
        // 聴力
        float DtAuditus { get; }
        // 聴覚判定
        float DtAudita { get; }
        // 疑心判定(不審者状態で上昇していく。露出状態でDtVisaに統合)
        float DtSuspecta { get; }
        // 興味度
        float DtStudium { get; }
        // 緊張度
        float DtIntentio { get; }
        // 異常耐性上限
        float DtTorelantiaAnomaliaeMaxima { get; }
        // 異常耐性下限
        float DtTorelantiaAnomaliaeMinima { get; }
    }
}
