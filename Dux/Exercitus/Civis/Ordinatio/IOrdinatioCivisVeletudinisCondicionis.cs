namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatioCivisVeletudinisCondicionis : IOrdinatioCivis {
        // 検知判定
        bool? EstVigilantia { get; }
        bool? EstDetectio { get; }
        bool? EstDetectioSonora { get; }
        bool? EstSuspecta { get; }

        // 視認判定
        bool? EstSpectareNudusAnterior { get; }
        // 視認判定
        bool? EstSpectareNudusPosterior { get; }
    }
}
