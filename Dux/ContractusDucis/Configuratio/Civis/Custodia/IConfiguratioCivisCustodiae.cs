namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisCustodiae {
        // 視認開始距離
        float DistantiaCustodiae { get; }
        // 視認上昇が最大になる距離
        float DistantiaCustodiaeMaxima { get; }
        // 視認上昇が上がり始める距離
        float DistantiaCustodiaeAscensus { get; }
        // 距離による視認上昇のカーブ角度
        float PrecalculusDistantiaAscensus { get; }
        // 視認度上昇倍率 (乗算値)
        float RatioVisus { get; }

        float LimenVigilantia { get; }
        float LimenDetectio { get; }

        // 発覚状態での固定減少量
        float ConsumptioVisaeDetectioSec { get; }
        // 警戒状態/通常時の視認減少量 => シグモイド関数で算出する興味喪失度で補正される。
        float ConsumptioVisaeSec { get; }

        // 興味を失い始める時間(Sigmoidの坂にあたるポイント)
        float TempusStudiumAmittereSec { get; }
        // 視認減少が最大化するまでの時間(Sigmoidの右端にあたるポイント)
        float TempusStudiumAmittereMaximaSec { get; }
        // 興味の減少カーブ角度
        float PraeruptioTempusAmittere { get; }
    }
}