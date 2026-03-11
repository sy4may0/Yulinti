using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioExercitus {
        [SerializeField] private ConfiguratioExercitusCivis exercitusCivis;
        [SerializeField] private ConfiguratioExercitusPuellae exercitusPuellae;

        public IConfiguratioExercitusCivis ExercitusCivis => exercitusCivis;
        public IConfiguratioExercitusPuellae ExercitusPuellae => exercitusPuellae;
    }
}