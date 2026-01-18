namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioCivisVeletudinisSpectare : IOrdinatioCivis {
        // 視認判定
        bool EstSpectareNudusAnterior { get; }
        // 視認判定
        bool EstSpectareNudusPosterior { get; }
    }
}