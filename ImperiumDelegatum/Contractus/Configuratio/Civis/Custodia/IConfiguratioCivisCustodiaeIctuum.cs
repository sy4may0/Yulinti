namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioCivisCustodiaeIctuum {
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
