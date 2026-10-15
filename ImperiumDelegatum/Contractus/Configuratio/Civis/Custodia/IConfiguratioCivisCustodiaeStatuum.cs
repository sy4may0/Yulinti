namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioCivisCustodiaeStatuum {
        //////////////////////////////
        //  Suspecta計算
        //////////////////////////////
        // 基礎Suspecta増加量(0~1レシオ毎秒) 1/1ぐらい。 
        float IncrementumSuspectaeBasis { get; }
        // 基礎Suspecta消費量(0~1レシオ毎秒) 1/10ぐらい。 
        float ConsumptioSuspectaeBasis { get; }
        // 非Nudus時、Suspectaが増加するAnomaliaの最小値
        float LimenAnomaliaeSuspectaeNonNudus { get; }

        //////////////////////////////
        //  Suspecta制限
        //////////////////////////////
        // 非視認で聴覚のみ有効な際のSuspecta上限値(0~1レシオ) 0.5ぐらい
        float LimitatioSuspectaeAuditae { get; }
        // Nudus非視認時のSuspecta上限値(0~1レシオ) 0.9ぐらい
        float LimitatioSuspectaeNonNudus { get; }

        //////////////////////////////
        //  Intentio計算
        //////////////////////////////
        // 基礎Intentio増加量(0~1レシオ毎秒) 1/10ぐらい。 
        float IncrementumIntentionisBasis { get; }
        // Anomalia不足時のIntentio消費量(0~1レシオ毎秒) 1/10ぐらい。 
        float ConsumptioIntentionisDefectusAnomaliaeBasis { get; }
        // Anomalia超過時のIntentio消費量(0~1レシオ毎秒) 1/3ぐらい。 
        float ConsumptioIntentionisExcessusAnomaliaeBasis { get; }
        // Anomalia減少のマージン(Anomalia最大は999とか。100ぐらい。)
        float MargoTorelantiaeAnomaliae { get; }

        //////////////////////////////
        //  Holorogium
        //////////////////////////////
        // Suspecta減少ブロック時間(増加-減少切替時に一定時間のSuspecta減少ブロックを設ける) 3秒くらい
        float TempusProhibitioConsumptioSuspectae { get; }

        // Intentio減少ブロック時間(増加-減少切替時に一定時間のIntentio減少ブロックを設ける) 3秒くらい
        float TempusProhibitioConsumptioIntentio { get; }

        // Vigilantiaステート時間(temere, 4~6秒くらい)
        float TempusConservationisVigilantiaeMaxima { get; }
        float TempusConservationisVigilantiaeMinima { get; }

        // Spectans抜け時間: 視認無しになってからのSpectans維持時間(temere, 2~4秒くらい)
        float TempusConservationisSpectansInVisusMaxima { get; }
        float TempusConservationisSpectansInVisusMinima { get; }

        // Spectans抜け時間: Intentioが0になってからのSpectans維持時間(temere, 10~20秒くらい)
        float TempusConservationisSpectansIntentioZeroMaxima { get; }
        float TempusConservationisSpectansIntentioZeroMinima { get; }

        // Sequens抜け時間: 視認無しになってからのSequens維持時間(temere, 3~6秒くらい)
        // 逃げる際のチューニング項目。角曲がって見えなくなってからどれだけ追いかけるか。
        float TempusConservationisSequensInVisusMaxima { get; }
        float TempusConservationisSequensInVisusMinima { get; }

        // Sequens抜け時間: Intentioが0になってからのSequens維持時間(temere, 10~20秒くらい)
        float TempusConservationisSequensIntentioZeroMaxima { get; }
        float TempusConservationisSequensIntentioZeroMinima { get; }

        // Quaerens維持時間: どれだけ探索状態を維持するか。(temere, 5~10秒くらい)
        float TempusConservationisQuaerensMaxima { get; }
        float TempusConservationisQuaerensMinima { get; }

        // Refrigeratio維持時間: どれだけクールダウン状態を維持するか。(temere, 30~60秒くらい)
        float TempusConservationisRefrigeratioMaxima { get; }
        float TempusConservationisRefrigeratioMinima { get; }
    }
}