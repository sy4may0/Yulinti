using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisCustodiaeStatusCommunis",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/CustodiaeStatus/Communis")]
    public sealed class ConfiguratioCivisCustodiaeStatusCommunis : ScriptableObject, IConfiguratioCivisCustodiaeStatusCommunis {
        [Header("Suspecta: 興味あり(Habere)の時間補正")]
        [SerializeField] private float tempusSuspectaeStudiumHabereMaxima = 10f;
        [SerializeField] private float tempusSuspectaeStudiumHabereMedia = 5f;
        [SerializeField] private float tempusSuspectaeStudiumHabereMinima = 0f;
        [SerializeField] private float praeruptioSuspectaeTempusStudiumHabere = 12f;

        [Header("Suspecta: 興味喪失(Amittere)の時間補正")]
        [SerializeField] private float tempusSuspectaeStudiumAmittereMaxima = 10f;
        [SerializeField] private float tempusSuspectaeStudiumAmittereMedia = 5f;
        [SerializeField] private float tempusSuspectaeStudiumAmittereMinima = 0f;
        [SerializeField] private float praeruptioSuspectaeTempusStudiumAmittere = 12f;

        [Header("Studium: 興味あり(Habere)の時間補正")]
        [SerializeField] private float tempusStudiiStudiumHabereMaxima = 10f;
        [SerializeField] private float tempusStudiiStudiumHabereMedia = 5f;
        [SerializeField] private float tempusStudiiStudiumHabereMinima = 0f;
        [SerializeField] private float praeruptioStudiiTempusStudiumHabere = 12f;

        [Header("Studium: 興味喪失(Amittere)の時間補正")]
        [SerializeField] private float tempusStudiiStudiumAmittereMaxima = 10f;
        [SerializeField] private float tempusStudiiStudiumAmittereMedia = 5f;
        [SerializeField] private float tempusStudiiStudiumAmittereMinima = 0f;
        [SerializeField] private float praeruptioStudiiTempusStudiumAmittere = 12f;

        [Header("Intentio: 興味あり(Habere)の時間補正")]
        [SerializeField] private float tempusIntentionisStudiumHabereMaxima = 10f;
        [SerializeField] private float tempusIntentionisStudiumHabereMedia = 5f;
        [SerializeField] private float tempusIntentionisStudiumHabereMinima = 0f;
        [SerializeField] private float praeruptioIntentionisTempusStudiumHabere = 12f;

        [Header("Intentio: 興味喪失(Amittere)の時間補正")]
        [SerializeField] private float tempusIntentionisStudiumAmittereMaxima = 10f;
        [SerializeField] private float tempusIntentionisStudiumAmittereMedia = 5f;
        [SerializeField] private float tempusIntentionisStudiumAmittereMinima = 0f;
        [SerializeField] private float praeruptioIntentionisTempusStudiumAmittere = 12f;

        [Header("増加<->減少転換時のシグモイド曲線維持時間")]
        [SerializeField] private float tempusSuspectaeConservandi = 0.5f;
        [SerializeField] private float tempusStudiiConservandi = 0.5f;
        [SerializeField] private float tempusIntentionisConservandi = 0.5f;

        public float TempusSuspectaeStudiumHabereMaxima => tempusSuspectaeStudiumHabereMaxima;
        public float TempusSuspectaeStudiumHabereMedia => tempusSuspectaeStudiumHabereMedia;
        public float TempusSuspectaeStudiumHabereMinima => tempusSuspectaeStudiumHabereMinima;
        public float PraeruptioSuspectaeTempusStudiumHabere => praeruptioSuspectaeTempusStudiumHabere;

        public float TempusSuspectaeStudiumAmittereMaxima => tempusSuspectaeStudiumAmittereMaxima;
        public float TempusSuspectaeStudiumAmittereMedia => tempusSuspectaeStudiumAmittereMedia;
        public float TempusSuspectaeStudiumAmittereMinima => tempusSuspectaeStudiumAmittereMinima;
        public float PraeruptioSuspectaeTempusStudiumAmittere => praeruptioSuspectaeTempusStudiumAmittere;

        public float TempusStudiiStudiumHabereMaxima => tempusStudiiStudiumHabereMaxima;
        public float TempusStudiiStudiumHabereMedia => tempusStudiiStudiumHabereMedia;
        public float TempusStudiiStudiumHabereMinima => tempusStudiiStudiumHabereMinima;
        public float PraeruptioStudiiTempusStudiumHabere => praeruptioStudiiTempusStudiumHabere;

        public float TempusStudiiStudiumAmittereMaxima => tempusStudiiStudiumAmittereMaxima;
        public float TempusStudiiStudiumAmittereMedia => tempusStudiiStudiumAmittereMedia;
        public float TempusStudiiStudiumAmittereMinima => tempusStudiiStudiumAmittereMinima;
        public float PraeruptioStudiiTempusStudiumAmittere => praeruptioStudiiTempusStudiumAmittere;

        public float TempusIntentionisStudiumHabereMaxima => tempusIntentionisStudiumHabereMaxima;
        public float TempusIntentionisStudiumHabereMedia => tempusIntentionisStudiumHabereMedia;
        public float TempusIntentionisStudiumHabereMinima => tempusIntentionisStudiumHabereMinima;
        public float PraeruptioIntentionisTempusStudiumHabere => praeruptioIntentionisTempusStudiumHabere;

        public float TempusIntentionisStudiumAmittereMaxima => tempusIntentionisStudiumAmittereMaxima;
        public float TempusIntentionisStudiumAmittereMedia => tempusIntentionisStudiumAmittereMedia;
        public float TempusIntentionisStudiumAmittereMinima => tempusIntentionisStudiumAmittereMinima;
        public float PraeruptioIntentionisTempusStudiumAmittere => praeruptioIntentionisTempusStudiumAmittere;

        public float TempusSuspectaeConservandi => tempusSuspectaeConservandi;
        public float TempusStudiiConservandi => tempusStudiiConservandi;
        public float TempusIntentionisConservandi => tempusIntentionisConservandi;
    }
}
