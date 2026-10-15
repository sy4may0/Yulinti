using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisCustodiaeStatuum", menuName = "Yulinti/Configuratio/Exercitus/Civis/ConfiguratioCivisCustodiaeStatuum")]
    public sealed class ConfiguratioCivisCustodiaeStatuum : ScriptableObject, IConfiguratioCivisCustodiaeStatuum {
        [Header("Suspecta計算")]
        [SerializeField] private float incrementumSuspectaeBasis = 1f;
        [SerializeField] private float consumptioSuspectaeBasis = 0.1f;
        [SerializeField] private float limenAnomaliaeSuspectaeNonNudus = 200f;

        [Header("Suspecta制限")]
        [SerializeField] private float limitatioSuspectaeAuditae = 0.5f;
        [SerializeField] private float limitatioSuspectaeNonNudus = 0.9f;

        [Header("Intentio計算")]
        [SerializeField] private float incrementumIntentionisBasis = 0.1f;
        [SerializeField] private float consumptioIntentionisDefectusAnomaliaeBasis = 0.1f;
        [SerializeField] private float consumptioIntentionisExcessusAnomaliaeBasis = 1f / 3f;
        [SerializeField] private float margoTorelantiaeAnomaliae = 100f;

        [Header("減少ブロック時間")]
        [SerializeField] private float tempusProhibitioConsumptioSuspectae = 3f;
        [SerializeField] private float tempusProhibitioConsumptioIntentio = 3f;

        [Header("Vigilantia維持時間")]
        [SerializeField] private float tempusConservationisVigilantiaeMaxima = 6f;
        [SerializeField] private float tempusConservationisVigilantiaeMinima = 4f;

        [Header("Spectans維持時間: 視認無し")]
        [SerializeField] private float tempusConservationisSpectansInVisusMaxima = 4f;
        [SerializeField] private float tempusConservationisSpectansInVisusMinima = 2f;

        [Header("Spectans維持時間: Intentio 0")]
        [SerializeField] private float tempusConservationisSpectansIntentioZeroMaxima = 20f;
        [SerializeField] private float tempusConservationisSpectansIntentioZeroMinima = 10f;

        [Header("Sequens維持時間: 視認無し")]
        [SerializeField] private float tempusConservationisSequensInVisusMaxima = 6f;
        [SerializeField] private float tempusConservationisSequensInVisusMinima = 3f;

        [Header("Sequens維持時間: Intentio 0")]
        [SerializeField] private float tempusConservationisSequensIntentioZeroMaxima = 20f;
        [SerializeField] private float tempusConservationisSequensIntentioZeroMinima = 10f;

        [Header("Quaerens維持時間")]
        [SerializeField] private float tempusConservationisQuaerensMaxima = 10f;
        [SerializeField] private float tempusConservationisQuaerensMinima = 5f;

        [Header("Refrigeratio維持時間")]
        [SerializeField] private float tempusConservationisRefrigeratioMaxima = 60f;
        [SerializeField] private float tempusConservationisRefrigeratioMinima = 30f;

        public float IncrementumSuspectaeBasis => incrementumSuspectaeBasis;
        public float ConsumptioSuspectaeBasis => consumptioSuspectaeBasis;
        public float LimenAnomaliaeSuspectaeNonNudus => limenAnomaliaeSuspectaeNonNudus;

        public float LimitatioSuspectaeAuditae => limitatioSuspectaeAuditae;
        public float LimitatioSuspectaeNonNudus => limitatioSuspectaeNonNudus;

        public float IncrementumIntentionisBasis => incrementumIntentionisBasis;
        public float ConsumptioIntentionisDefectusAnomaliaeBasis => consumptioIntentionisDefectusAnomaliaeBasis;
        public float ConsumptioIntentionisExcessusAnomaliaeBasis => consumptioIntentionisExcessusAnomaliaeBasis;
        public float MargoTorelantiaeAnomaliae => margoTorelantiaeAnomaliae;

        public float TempusProhibitioConsumptioSuspectae => tempusProhibitioConsumptioSuspectae;
        public float TempusProhibitioConsumptioIntentio => tempusProhibitioConsumptioIntentio;

        public float TempusConservationisVigilantiaeMaxima => tempusConservationisVigilantiaeMaxima;
        public float TempusConservationisVigilantiaeMinima => tempusConservationisVigilantiaeMinima;

        public float TempusConservationisSpectansInVisusMaxima => tempusConservationisSpectansInVisusMaxima;
        public float TempusConservationisSpectansInVisusMinima => tempusConservationisSpectansInVisusMinima;

        public float TempusConservationisSpectansIntentioZeroMaxima => tempusConservationisSpectansIntentioZeroMaxima;
        public float TempusConservationisSpectansIntentioZeroMinima => tempusConservationisSpectansIntentioZeroMinima;

        public float TempusConservationisSequensInVisusMaxima => tempusConservationisSequensInVisusMaxima;
        public float TempusConservationisSequensInVisusMinima => tempusConservationisSequensInVisusMinima;

        public float TempusConservationisSequensIntentioZeroMaxima => tempusConservationisSequensIntentioZeroMaxima;
        public float TempusConservationisSequensIntentioZeroMinima => tempusConservationisSequensIntentioZeroMinima;

        public float TempusConservationisQuaerensMaxima => tempusConservationisQuaerensMaxima;
        public float TempusConservationisQuaerensMinima => tempusConservationisQuaerensMinima;

        public float TempusConservationisRefrigeratioMaxima => tempusConservationisRefrigeratioMaxima;
        public float TempusConservationisRefrigeratioMinima => tempusConservationisRefrigeratioMinima;
    }
}
