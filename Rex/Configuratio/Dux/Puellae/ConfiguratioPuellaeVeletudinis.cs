using UnityEngine;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeVeletudinis : IConfiguratioPuellaeVeletudinis {
        [SerializeField] private float limenExhauritaVigoris = 0f;
        [SerializeField] private float limenRefectaVigoris = 0.3f;
        [SerializeField] private float limenExhauritaPatientiae = 0.00001f;
        [SerializeField] private float limenRefectaPatientiae = 0.3f;
        [SerializeField] private float velocitasSoniMaxima = 3.0f;

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

        public float LimenExhauritaVigoris => limenExhauritaVigoris;
        public float LimenRefectaVigoris => limenRefectaVigoris;
        public float LimenExhauritaPatientiae => limenExhauritaPatientiae;
        public float LimenRefectaPatientiae => limenRefectaPatientiae;
        public float VelocitasSoniMaxima => velocitasSoniMaxima;

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
    }
}