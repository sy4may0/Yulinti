using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisCustodiaeIctuum", menuName = "Yulinti/Configuratio/Exercitus/Civis/ConfiguratioCivisCustodiaeIctuum")]
    public sealed class ConfiguratioCivisCustodiaeIctuum : ScriptableObject, IConfiguratioCivisCustodiaeIctuum {
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

        public float DistantiaCustodiaeActivum => distantiaCustodiaeActivum;

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
    }
}
