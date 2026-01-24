namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisCustodiae {
        // 視認度上昇倍率 (乗算値)
        float RatioVisus { get; }
        // 猜疑度値上昇倍率 (乗算値)
        float RatioSuspecta { get; }
        // 聴認度上昇倍率 (乗算値)
        float RatioAudita { get; }

        float LimenVigilantia { get; }
        float LimenDetectio { get; }
        float LimenAudivi { get; }
        float LimenSuspecta { get; }

        // 発覚状態での固定減少量
        float ConsumptioVisaeDetectioSec { get; }
        // 警戒状態/通常時の視認減少量 => シグモイド関数で算出する興味喪失度で補正される。
        float ConsumptioVisaeSec { get; }

        // 猜疑度値減少量 => シグモイド関数で算出する興味喪失度で補正される。
        float ConsumptioSuspectaSec { get; }

        // 興味を失い始める時間(Sigmoidの坂にあたるポイント)
        float TempusStudiumAmittereSec { get; }
        // 視認減少が最大化するまでの時間(Sigmoidの右端にあたるポイント)
        float TempusStudiumAmittereMaximaSec { get; }
        // 興味の減少カーブ角度
        float PraeruptioTempusAmittere { get; }

        // 視認範囲 この範囲内で計算を行う。
        float DistantiaCustodiaeActivum { get; }
    
        // 距離による視力補正設定
        float DistantiaVisaeMaxima { get; }
        float DistantiaVisaeMin { get; }
        float DistantiaVisaeMedius { get; }
        float PraeruptioDistantiaVisae { get; }

        // 距離による視野角の上昇補正
        float DistantiaAnguliVisusMaxima { get; }
        float DistantiaAnguliVisusMin { get; }
        float DistantiaAnguliVisusMedius { get; }
        float PraeruptioDistantiaAnguliVisus { get; }

        // 近距離で適用する視野角補正
        float AngulusVisus0Maxima { get; }
        float AngulusVisus0Min { get; }
        float AngulusVisus0Medius { get; }
        float PraeruptioAngulusVisus0 { get; }

        // 遠距離で適用する視野角補正
        float AngulusVisus1Maxima { get; }
        float AngulusVisus1Min { get; }
        float AngulusVisus1Medius { get; }
        float PraeruptioAngulusVisus1 { get; }

        // 聴認範囲 この範囲内で計算を行う。
        float DistantiaAuditaeActivum { get; }

        // 距離による聴覚補正。
        // PuellaeのSonus最大時、および0の時に音が届く距離を指定する。
        float DistantiaAuditaeSoniMaxima { get; }
        float DistantiaAuditaeSoniMin { get; }

        // シグモイド関数設定: 距離による聴覚補正の中間距離。
        // このレシオはSoniMaxima/SoniMinでレンジが変わるため、
        // Mediusは0~1の比率を直接指定する。
        float DistantiaAuditaeMedius { get; }
        float PraeruptioDistantiaAuditaeSoni { get; }
    }
}