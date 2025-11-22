using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class FasciculusConfigurationumPuellaeCrinis {
        [SerializeField] Transform _osCapitis;
        [SerializeField] private ConfiguratioPuellaeCrinis _resiliens;

        public Transform OsCapitis => _osCapitis;
        public ConfiguratioPuellaeCrinis Resiliens => _resiliens;
    }
}