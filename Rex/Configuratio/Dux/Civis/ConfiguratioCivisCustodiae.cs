using UnityEngine;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioCivisCustodiae : IConfiguratioCivisCustodiae {
        [Header("視認度上昇倍率 (乗算値)")]
        [SerializeField] private float ratioVisus = 15f;
        [Header("猜疑度値上昇倍率 (乗算値)")]
        [SerializeField] private float ratioSuspecta = 15f;
        [Header("聴認度上昇倍率 (乗算値)")]
        [SerializeField] private float ratioAudita = 15f;

        [Header("警戒状態/通常時の視認判定値")]
        [SerializeField] private float limenVigilantia = 0.5f;
        [SerializeField] private float limenDetectio = 0.9f;
        [SerializeField] private float limenDetectioSonora = 0.9f;
        [SerializeField] private float limenSuspecta = 0.35f;

        [Header("発覚状態での固定減少量")]
        [SerializeField] private float consumptioVisaeDetectioSec = -0.1f;
        [Header("警戒状態/通常時の視認減少量")]
        [SerializeField] private float consumptioVisaeSec = -0.15f;
        [Header("猜疑度値減少量")]
        [SerializeField] private float consumptioSuspectaSec = -0.15f;
        [Header("聴認減少量")]
        [SerializeField] private float consumptioAuditaeSec = -0.15f;

        [Header("興味喪失時間補正")]
        [SerializeField] private float tempusStudiumAmittereSec = 5f;
        [SerializeField] private float tempusStudiumAmittereMaximaSec = 10f;
        [SerializeField] private float praeruptioTempusAmittere = 12f;

        [Header("視認範囲")]
        [SerializeField] private float distantiaCustodiaeActivum = 32;

        [Header("距離による視認補正")]
        [SerializeField] private float distantiaVisaeMaxima = 30f;
        [SerializeField] private float distantiaVisaeMin = 3f;
        [SerializeField] private float distantiaVisaeMedius = 12f;
        [SerializeField] private float praeruptioDistantiaVisae = 10f;

        [Header("距離による視野角補正")]
        [SerializeField] private float distantiaAnguliVisusMaxima = 30f;
        [SerializeField] private float distantiaAnguliVisusMin = 3f;
        [SerializeField] private float distantiaAnguliVisusMedius = 12f;
        [SerializeField] private float praeruptioDistantiaAnguliVisus = 10f;

        [Header("近距離で適用する視野角補正")]
        [SerializeField] private float angulusVisus0Maxima = 100f;
        [SerializeField] private float angulusVisus0Min = 45f;
        [SerializeField] private float angulusVisus0Medius = 80f;
        [SerializeField] private float praeruptioAngulusVisus0 = 8f;

        [Header("遠距離で適用する視野角補正")]
        [SerializeField] private float angulusVisus1Maxima = 90f;
        [SerializeField] private float angulusVisus1Min = 0f;
        [SerializeField] private float angulusVisus1Medius = 55f;
        [SerializeField] private float praeruptioAngulusVisus1 = 8f;

        [Header("聴認範囲")]
        [SerializeField] private float distantiaAuditaeActivum = 21f;

        [Header("距離による聴覚補正")]
        [SerializeField] private float distantiaAuditaeSoniMaxima = 20f;
        [SerializeField] private float distantiaAuditaeSoniMin = 6f;

        [Header("距離による聴覚補正の中間距離(Mediusは0~1の比率を直接指定する。)")]
        [SerializeField] private float distantiaAuditaeMedius = 0.5f;
        [SerializeField] private float praeruptioDistantiaAuditaeSoni = 8f;

        [Header("聴認状態維持時間(区間ランダム)")]
        [SerializeField] private float tempusAuditaeSecMaxima = 13f;
        [SerializeField] private float tempusAuditaeSecMinima = 7f;
        [Header("聴認状態クールタイム(区間ランダム)")]
        [SerializeField] private float tempusSurdaMaxima = 19f;
        [SerializeField] private float tempusSurdaMinima = 14f;

        public float DistantiaCustodiaeActivum => distantiaCustodiaeActivum;

        public float RatioVisus => ratioVisus;
        public float RatioSuspecta => ratioSuspecta;
        public float RatioAudita => ratioAudita;

        public float LimenVigilantia => limenVigilantia;
        public float LimenDetectio => limenDetectio;
        public float LimenDetectioSonora => limenDetectioSonora;
        public float LimenSuspecta => limenSuspecta;

        public float ConsumptioVisaeDetectioSec => consumptioVisaeDetectioSec;
        public float ConsumptioVisaeSec => consumptioVisaeSec;
        public float ConsumptioSuspectaSec => consumptioSuspectaSec;
        public float ConsumptioAuditaeSec => consumptioAuditaeSec;

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

        public float DistantiaAuditaeActivum => distantiaAuditaeActivum;
        public float DistantiaAuditaeSoniMaxima => distantiaAuditaeSoniMaxima;
        public float DistantiaAuditaeSoniMin => distantiaAuditaeSoniMin;
        public float DistantiaAuditaeMedius => distantiaAuditaeMedius;
        public float PraeruptioDistantiaAuditaeSoni => praeruptioDistantiaAuditaeSoni;

        public float TempusAuditaeSecMaxima => tempusAuditaeSecMaxima;
        public float TempusAuditaeSecMinima => tempusAuditaeSecMinima;
        public float TempusSurdaMaxima => tempusSurdaMaxima;
        public float TempusSurdaMinima => tempusSurdaMinima;
    }
}
