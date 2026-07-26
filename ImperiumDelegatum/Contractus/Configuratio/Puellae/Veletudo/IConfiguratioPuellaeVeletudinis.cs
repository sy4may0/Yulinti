namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioPuellaeVeletudinis {
        float LimenExhauritaVigoris { get; }
        float LimenExhauritaPatientiae { get; }
        float LimenRefectaVigoris { get; }
        float LimenRefectaPatientiae { get; }
        float VelocitasSoniMaxima { get; }

        float AnomaliaBasis { get; }
        float AnomaliaNudusBasis { get; }

        // Vigilantia時、Dedecus0.0のVigor減少量(sec)
        float ConsumptioVigorisMinimaVigilantia { get; }
        // Vigilantia時、Dedecus1.0のVigor減少量(sec)
        float ConsumptioVigorisMaximaVigilantia { get; }

        // Detectio時、Dedecus0.0のVigor減少量(sec)
        float ConsumptioVigorisMinimaDetectio { get; }
        // Detectio時、Dedecus1.0のVigor減少量(sec)
        float ConsumptioVigorisMaximaDetectio { get; }

        // 低レベル時のDetectio時Vigor減少倍率
        float RatioConsumptioVigorisDetectio { get; }
        // RatioConsumptioVigorisDetectioを解除するExhibitusレベル
        int LimenRemissioExhibitus { get; }
        // 視認人数による最大倍率
        float RatioNumerusCustodiaeMaxima { get; }

        // 回復量(sec)
        float RecuperatioVigorisSec { get; }
        // 回復開始時間(Sigmoidの坂にあたるポイント)
        float TempusRecuperationisVigorisSec { get; }
        // 回復が最大化するまでの時間(Sigmoidの右端にあたるポイント)
        float TempusRecuperationisVigorisMaximaSec { get; }
        // 回復カーブ角度
        float PraeruptioTempusRecuperationisVigoris { get; }

        // Dedecus増加量の距離補正
        float DistantiaDedecorisMaxima { get; }
        float DistantiaDedecorisMedia { get; }
        float DistantiaDedecorisMinima { get; }
        float PraeruptioDistantiaDedecoris { get; }

        // Anomalia超過補正最大倍率
        float RatioDedecorisAnomaliaeExcessusMaxima { get; }
        // Anomalia超過補正最小倍率
        float RatioDedecorisAnomaliaeExcessusMinima { get; }
        // 最大Anomalia超過値
        float LimenAnomaliaeExcessusMaxima { get; }

        // Attendens時のDedecus増加補正
        float RatioDedecorisAttendens { get; }

        // Vigilantia/Intuitus時のDedecus増加補正
        float RatioDedecorisVigilantia { get; }

        // Discedens時のDedecus増加補正
        float RatioDedecorisDiscedens { get; }

        // 最小ダメージ(sec)
        float ConsumptioVigorisMinimaSec { get; }
        // 最大ダメージ(sec)
        float ConsumptioVigorisMaximaSec { get; }
        // ダメージ最大化Dedecus値
        float DedecusMaximaConsumptioVigoris { get; }

        // 回復レシオ量(sec) ※回復はVigor実値ではなく、Maxima換算の割合
        float RatioRepletioVigoris { get; }

        // 回復時間シグモイド設定
        float TempusRepletioVigorisMaximaSec { get; }
        float TempusRepletioVigorisMediaSec { get; }
        float TempusRepletioVigorisMinimaSec { get; }
        float PraeruptioRepletioVigoris { get; }
    }
}