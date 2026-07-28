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

        [Header("Vigilantia時、Dedecus0.0のVigor減少量(sec)")]
        [SerializeField] private float consumptioVigorisMinimaVigilantia = -0.033f;
        [Header("Vigilantia時、Dedecus1.0のVigor減少量(sec)")]
        [SerializeField] private float consumptioVigorisMaximaVigilantia = -0.1f;
        [Header("Detectio時、Dedecus0.0のVigor減少量(sec)")]
        [SerializeField] private float consumptioVigorisMinimaDetectio = -0.067f;
        [Header("Detectio時、Dedecus1.0のVigor減少量(sec)")]
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

        [Header("Dedecus増加量の距離補正")]
        [SerializeField] private float distantiaDedecorisMaxima = 30f;
        [SerializeField] private float distantiaDedecorisMedia = 12f;
        [SerializeField] private float distantiaDedecorisMinima = 3f;
        [SerializeField] private float praeruptioDistantiaDedecoris = 10f;

        [Header("Anomalia超過補正最大倍率")]
        [SerializeField] private float ratioDedecorisAnomaliaeExcessusMaxima = 5f;
        [Header("Anomalia超過補正最小倍率")]
        [SerializeField] private float ratioDedecorisAnomaliaeExcessusMinima = 1.5f;
        [Header("最大Anomalia超過値")]
        [SerializeField] private float limenAnomaliaeExcessusMaxima = 400f;

        [Header("Attendens時のDedecus増加補正")]
        [SerializeField] private float ratioDedecorisAttendens = 0.3f;
        [Header("Vigilantia/Intuitus時のDedecus増加補正")]
        [SerializeField] private float ratioDedecorisVigilantia = 1.2f;
        [Header("Discedens時のDedecus増加補正")]
        [SerializeField] private float ratioDedecorisDiscedens = 0.9f;


        [Header("最小ダメージ(sec)")]
        [SerializeField] private float consumptioVigorisMinimaSec = 1f;
        [Header("最大ダメージ(sec)")]
        [SerializeField] private float consumptioVigorisMaximaSec = 1000f;
        [Header("ダメージ最大化Dedecus値")]
        [SerializeField] private float dedecusMaximaConsumptioVigoris = 2000f;
        [Header("回復レシオ量(sec)")]
        [SerializeField] private float ratioRepletioVigoris = 0.143f;
        [Header("回復時間シグモイド設定")]
        [SerializeField] private float tempusRepletioVigorisMaximaSec = 7f;
        [SerializeField] private float tempusRepletioVigorisMediaSec = 5f;
        [SerializeField] private float tempusRepletioVigorisMinimaSec = 0f;
        [SerializeField] private float praeruptioRepletioVigoris = 16f;

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

        public float DistantiaDedecorisMaxima => distantiaDedecorisMaxima;
        public float DistantiaDedecorisMedia => distantiaDedecorisMedia;
        public float DistantiaDedecorisMinima => distantiaDedecorisMinima;
        public float PraeruptioDistantiaDedecoris => praeruptioDistantiaDedecoris;

        public float RatioDedecorisAnomaliaeExcessusMaxima => ratioDedecorisAnomaliaeExcessusMaxima;
        public float RatioDedecorisAnomaliaeExcessusMinima => ratioDedecorisAnomaliaeExcessusMinima;
        public float LimenAnomaliaeExcessusMaxima => limenAnomaliaeExcessusMaxima;

        public float RatioDedecorisAttendens => ratioDedecorisAttendens;
        public float RatioDedecorisVigilantia => ratioDedecorisVigilantia;
        public float RatioDedecorisDiscedens => ratioDedecorisDiscedens;

        public float ConsumptioVigorisMinimaSec => consumptioVigorisMinimaSec;
        public float ConsumptioVigorisMaximaSec => consumptioVigorisMaximaSec;
        public float DedecusMaximaConsumptioVigoris => dedecusMaximaConsumptioVigoris;
        public float RatioRepletioVigoris => ratioRepletioVigoris;
        public float TempusRepletioVigorisMaximaSec => tempusRepletioVigorisMaximaSec;
        public float TempusRepletioVigorisMediaSec => tempusRepletioVigorisMediaSec;
        public float TempusRepletioVigorisMinimaSec => tempusRepletioVigorisMinimaSec;
        public float PraeruptioRepletioVigoris => praeruptioRepletioVigoris;
    }
}