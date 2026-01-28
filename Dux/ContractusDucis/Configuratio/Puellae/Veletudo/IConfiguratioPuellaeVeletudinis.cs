namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeVeletudinis {
        float LimenExhauritaVigoris { get; }
        float LimenExhauritaPatientiae { get; }
        float LimenRefectaVigoris { get; }
        float LimenRefectaPatientiae { get; }
        float VelocitasSoniMaxima { get; }

        // Vigilantia時、Debecus0.0のVigor減少量(sec)
        float ConsumptioVigorisMinimaVigilantia { get; }
        // Vigilantia時、Debecus1.0のVigor減少量(sec)
        float ConsumptioVigorisMaximaVigilantia { get; }

        // Detectio時、Debecus0.0のVigor減少量(sec)
        float ConsumptioVigorisMinimaDetectio { get; }
        // Detectio時、Debecus1.0のVigor減少量(sec)
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
    }
}