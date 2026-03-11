using UnityEngine;

namespace Yulinti.Imperium.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioRadicis", menuName = "Yulinti/Rex/ConfiguratioRadicis")]
    public sealed class ConfiguratioRadicis : ScriptableObject {
        [SerializeField] private ConfiguratioCivis civis;
        [SerializeField] private ConfiguratioPuellae puellae;
        [SerializeField] private ConfiguratioPunctumViae punctumViae;
        [SerializeField] private ConfiguratioExercitusPuellae exercitusPuellae;
        [SerializeField] private ConfiguratioExercitusCivis exercitusCivis;

        public ConfiguratioCivis Civis => civis;
        public ConfiguratioPuellae Puellae => puellae;
        public ConfiguratioExercitusPuellae ExercitusPuellae => exercitusPuellae;
        public ConfiguratioExercitusCivis ExercitusCivis => exercitusCivis;
        public ConfiguratioPunctumViae PunctumViae => punctumViae;
    }
}