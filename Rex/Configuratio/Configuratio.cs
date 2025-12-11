using UnityEngine;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class Configuratio {
        [SerializeField] private ConfiguratioCivis civis;
        [SerializeField] private ConfiguratioPuellae puellae;
        [SerializeField] private ConfiguratioExercitusPuellae exercitusPuellae;

        public ConfiguratioCivis Civis => civis;
        public ConfiguratioPuellae Puellae => puellae;
        public ConfiguratioExercitusPuellae ExercitusPuellae => exercitusPuellae;
    }
}