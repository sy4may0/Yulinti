using UnityEngine;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioCivisCustodiae : IConfiguratioCivisCustodiae {
        //この４つは消せる。
        [SerializeField] private float distantiaCustodiae = 25f;
        [SerializeField] private float distantiaCustodiaeMaxima = 3f;
        [SerializeField] private float distantiaCustodiaeAscensus = 12f;
        [SerializeField] private float precalculusDistantiaAscensus = 10f;

        [Header("視認度上昇倍率 (乗算値)")]
        [SerializeField] private float ratioVisus = 15f;
        [Header("猜疑度値上昇倍率 (乗算値)")]
        [SerializeField] private float ratioSuspecta = 15f;

        [Header("警戒状態/通常時の視認判定値")]
        [SerializeField] private float limenVigilantia = 0.5f;
        [SerializeField] private float limenDetectio = 0.9f;

        [Header("発覚状態での固定減少量")]
        [SerializeField] private float consumptioVisaeDetectioSec = -0.1f;
        [Header("警戒状態/通常時の視認減少量")]
        [SerializeField] private float consumptioVisaeSec = -0.15f;
        [Header("猜疑度値減少量")]
        [SerializeField] private float consumptioSuspectaSec = -0.15f;

        [Header("興味喪失時間補正")]
        [SerializeField] private float tempusStudiumAmittereSec = 5f;
        [SerializeField] private float tempusStudiumAmittereMaximaSec = 10f;
        [SerializeField] private float praeruptioTempusAmittere = 12f;

        [Header("視認範囲")]
        [SerializeField] private float distantiaCustodiaeActivum = 10f;

        [Header("距離による視認補正")]
        [SerializeField] private float distantiaVisaeMaxima = 30f;
        [SerializeField] private float distantiaVisaeMin = 3f;
        [SerializeField] private float distantiaVisaeMedius = 12f;
        [SerializeField] private float praeruptioDistantiaVisae = 12f;

        [Header("距離による視野角補正")]
        [SerializeField] private float distantiaAnguliVisusMaxima = 30f;
        [SerializeField] private float distantiaAnguliVisusMin = 3f;
        [SerializeField] private float distantiaAnguliVisusMedius = 12f;
        [SerializeField] private float praeruptioDistantiaAnguliVisus = 18f;

        [Header("近距離で適用する視野角補正")]
        [SerializeField] private float angulusVisus0Maxima = 100f;
        [SerializeField] private float angulusVisus0Min = 45f;
        [SerializeField] private float angulusVisus0Medius = 70f;
        [SerializeField] private float praeruptioAngulusVisus0 = 12f;

        [Header("遠距離で適用する視野角補正")]
        [SerializeField] private float angulusVisus1Maxima = 90f;
        [SerializeField] private float angulusVisus1Min = 0f;
        [SerializeField] private float angulusVisus1Medius = 45f;
        [SerializeField] private float praeruptioAngulusVisus1 = 12f;

        public float DistantiaCustodiaeActivum => distantiaCustodiaeActivum;
        public float DistantiaCustodiae => distantiaCustodiae;
        public float DistantiaCustodiaeMaxima => distantiaCustodiaeMaxima;
        public float DistantiaCustodiaeAscensus => distantiaCustodiaeAscensus;
        public float PrecalculusDistantiaAscensus => precalculusDistantiaAscensus;
        public float RatioVisus => ratioVisus;
        public float RatioSuspecta => ratioSuspecta;
        public float LimenVigilantia => limenVigilantia;
        public float LimenDetectio => limenDetectio;
        public float ConsumptioVisaeDetectioSec => consumptioVisaeDetectioSec;
        public float ConsumptioVisaeSec => consumptioVisaeSec;
        public float TempusStudiumAmittereSec => tempusStudiumAmittereSec;
        public float TempusStudiumAmittereMaximaSec => tempusStudiumAmittereMaximaSec;
        public float PraeruptioTempusAmittere => praeruptioTempusAmittere;

        public float DistantiaVisaeMaxima => distantiaVisaeMaxima;
        public float DistantiaVisaeMin => distantiaVisaeMin;
        public float DistantiaVisaeMedius => distantiaVisaeMedius;
        public float PraeruptioDistantiaVisae => praeruptioDistantiaVisae;

        public float DistantiaAnguliVisusMaxima => distantiaAnguliVisusMaxima;
        public float DistantiaAnguliVisusMin => distantiaAnguliVisusMin;
        public float DistantiaAnguliVisusMedius => distantiaAnguliVisusMedius;
        public float PraeruptioDistantiaAnguliVisus => praeruptioDistantiaAnguliVisus;

        public float AngulusVisus0Maxima => angulusVisus0Maxima;
        public float AngulusVisus0Min => angulusVisus0Min;
        public float AngulusVisus0Medius => angulusVisus0Medius;
        public float PraeruptioAngulusVisus0 => praeruptioAngulusVisus0;
        
        public float AngulusVisus1Maxima => angulusVisus1Maxima;
        public float AngulusVisus1Min => angulusVisus1Min;
        public float AngulusVisus1Medius => angulusVisus1Medius;
        public float PraeruptioAngulusVisus1 => praeruptioAngulusVisus1;
    }
}
