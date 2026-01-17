namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioCivisVeletudinisValoris : IOrdinatioCivis {
        // 寿命
        float DtVitae { get; }
        // 視力
        float DtVisus { get; }
        // 視認判定
        float DtVisa { get; }
        // 聴覚判定
        float DtAudita { get; }
        // 疑心判定(不審者状態で上昇していく。露出状態でDtVisaに統合)
        float DtSuspecta { get; }
    }
}