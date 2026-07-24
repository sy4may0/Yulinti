using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeVeletudinis", menuName = "Yulinti/Configuratio/Exercitus/Puella/ConfiguratioPuellaeVeletudinis")]
    public sealed class ConfiguratioPuellaeVeletudinis : ScriptableObject, IConfiguratioPuellaeVeletudinis {
        [SerializeField] private float limenExhauritaVigoris = 0f;
        [SerializeField] private float limenRefectaVigoris = 0.3f;
        [SerializeField] private float limenExhauritaPatientiae = 0.00001f;
        [SerializeField] private float limenRefectaPatientiae = 0.3f;
        [SerializeField] private float velocitasSoniMaxima = 3.0f;

        [Header("Anomalia基準値")]
        [SerializeField] private float anomaliaBasis = 0f;
        [Header("AnomaliaNudus基準値")]
        [SerializeField] private float anomaliaNudusBasis = 100f;

        [Header("Vigilantia時、Debecus0.0のVigor減少量(sec)")]
        [SerializeField] private float consumptioVigorisMinimaVigilantia = -0.033f;
        [Header("Vigilantia時、Debecus1.0のVigor減少量(sec)")]
        [SerializeField] private float consumptioVigorisMaximaVigilantia = -0.1f;
        [Header("Detectio時、Debecus0.0のVigor減少量(sec)")]
        [SerializeField] private float consumptioVigorisMinimaDetectio = -0.067f;
        [Header("Detectio時、Debecus1.0のVigor減少量(sec)")]
        [SerializeField] private float consumptioVigorisMaximaDetectio = -0.2f;
        [Header("低レベル時のDetectio時Vigor減少倍率")]
        [SerializeField] private float ratioConsumptioVigorisDetectio = 30f;
        [Header("RatioConsumptioVigorisDetectioを解除するExhibitusレベル")]
        [SerializeField] private int limenRemissioExhibitus = 5;
        [Header("視認人数による最大倍率")]
        [SerializeField] private float ratioNumerusCustodiaeMaxima = 3f;

        [Header("回復量(sec)")]
        [SerializeField] private float recuperatioVigorisSec = 0.15f;
        [Header("回復開始時間(Sigmoidの坂にあたるポイント)")]
        [SerializeField] private float tempusRecuperationisVigorisSec = 5f;
        [Header("回復が最大化するまでの時間(Sigmoidの右端にあたるポイント)")]
        [SerializeField] private float tempusRecuperationisVigorisMaximaSec = 10f;
        [Header("回復カーブ角度")]
        [SerializeField] private float praeruptioTempusRecuperationisVigoris = 12f;

        [Header("Dedecus人数倍率の最大人数")]
        [SerializeField] private int numerusIctuumDedecorisMaxima = 10;
        [Header("Anomaliaに対する最大Dedecus人数倍率")]
        [SerializeField] private float ratioDedecorisMaximaAnomaliae = 10f;
        [Header("非Vigilantia時のDedecus補正値")]
        [SerializeField] private float ratioDedecorisAttendens = 0.3f;
        [Header("視認距離によるDedecus倍率補正")]
        [SerializeField] private float distantiaDedecorisMaximaMaxima = 30f;
        [SerializeField] private float distantiaDedecorisMaximaMin = 3f;
        [SerializeField] private float distantiaDedecorisMaximaMedius = 12f;
        [SerializeField] private float praeruptioDistantiaDedecorisMaxima = 8f;

        public float LimenExhauritaVigoris => limenExhauritaVigoris;
        public float LimenRefectaVigoris => limenRefectaVigoris;
        public float LimenExhauritaPatientiae => limenExhauritaPatientiae;
        public float LimenRefectaPatientiae => limenRefectaPatientiae;
        public float VelocitasSoniMaxima => velocitasSoniMaxima;

        public float AnomaliaBasis => anomaliaBasis;
        public float AnomaliaNudusBasis => anomaliaNudusBasis;

        public float ConsumptioVigorisMinimaVigilantia => consumptioVigorisMinimaVigilantia;
        public float ConsumptioVigorisMaximaVigilantia => consumptioVigorisMaximaVigilantia;
        public float ConsumptioVigorisMinimaDetectio => consumptioVigorisMinimaDetectio;
        public float ConsumptioVigorisMaximaDetectio => consumptioVigorisMaximaDetectio;
        public float RatioConsumptioVigorisDetectio => ratioConsumptioVigorisDetectio;
        public int LimenRemissioExhibitus => limenRemissioExhibitus;
        public float RatioNumerusCustodiaeMaxima => ratioNumerusCustodiaeMaxima;
        public float RecuperatioVigorisSec => recuperatioVigorisSec;
        public float TempusRecuperationisVigorisSec => tempusRecuperationisVigorisSec;
        public float TempusRecuperationisVigorisMaximaSec => tempusRecuperationisVigorisMaximaSec;
        public float PraeruptioTempusRecuperationisVigoris => praeruptioTempusRecuperationisVigoris;

        public int NumerusIctuumDedecorisMaxima => numerusIctuumDedecorisMaxima;
        public float RatioDedecorisMaximaAnomaliae => ratioDedecorisMaximaAnomaliae;
        public float RatioDedecorisAttendens => ratioDedecorisAttendens;
        public float DistantiaDedecorisMaximaMaxima => distantiaDedecorisMaximaMaxima;
        public float DistantiaDedecorisMaximaMin => distantiaDedecorisMaximaMin;
        public float DistantiaDedecorisMaximaMedius => distantiaDedecorisMaximaMedius;
        public float PraeruptioDistantiaDedecorisMaxima => praeruptioDistantiaDedecorisMaxima;
    }
}