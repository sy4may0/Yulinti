using UnityEngine;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioExercitusPuellae : IConfiguratioExercitusPuellae {
        [SerializeField] private ConfiguratioPuellaeStatuum statuum;
        [SerializeField] private ConfiguratioPuellaeActionisSecundarius actionisSecundarius;

        public IConfiguratioPuellaeStatuum Statuum => statuum;
        public IConfiguratioPuellaeActionisSecundarius ActionisSecundarius => actionisSecundarius;
    }
}