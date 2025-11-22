using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class FasciculusConfigurationumInput {
        [SerializeField] private ConfiguratioInputMotus _confInputMotus;

        public ConfiguratioInputMotus Motus => _confInputMotus;
    }
}