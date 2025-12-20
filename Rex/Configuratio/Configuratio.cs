using UnityEngine;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "Configuratio", menuName = "Yulinti/Rex/Configuratio")]
    public sealed class Configuratio : ScriptableObject {
        [SerializeField] private ConfiguratioCivis civis;
        [SerializeField] private ConfiguratioPuellae puellae;
        [SerializeField] private ConfiguratioPunctumViae punctumViae;
        [SerializeField] private ConfiguratioExercitusPuellae exercitusPuellae;

        public ConfiguratioCivis Civis => civis;
        public ConfiguratioPuellae Puellae => puellae;
        public ConfiguratioExercitusPuellae ExercitusPuellae => exercitusPuellae;
        public ConfiguratioPunctumViae PunctumViae => punctumViae;
    }
}