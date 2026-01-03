using UnityEngine;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioExercitusCivis", menuName = "Yulinti/Rex/ConfiguratioExercitusCivis")]
    public sealed class ConfiguratioExercitusCivis : ScriptableObject, IConfiguratioExercitusCivis {
        [SerializeField] private ConfiguratioCivisStatuum statuum;

        public IConfiguratioCivisStatuum Statuum => statuum;
    }
}