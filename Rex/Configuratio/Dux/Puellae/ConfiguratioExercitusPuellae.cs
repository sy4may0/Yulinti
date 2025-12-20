using UnityEngine;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioExercitusPuellae", menuName = "Yulinti/Rex/ConfiguratioExercitusPuellae")]
    public sealed class ConfiguratioExercitusPuellae : ScriptableObject, IConfiguratioExercitusPuellae {
        [SerializeField] private ConfiguratioPuellaeStatuum statuum;
        [SerializeField] private ConfiguratioPuellaeActionisSecundarius actionisSecundarius;

        public IConfiguratioPuellaeStatuum Statuum => statuum;
        public IConfiguratioPuellaeActionisSecundarius ActionisSecundarius => actionisSecundarius;
    }
}