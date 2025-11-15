using UnityEngine;

namespace Yulinti.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class FasciculusConfigurationumCamera {
        [SerializeField] private ConfiguratioCameraPrincips _configuratioCameraPrincips;

        public ConfiguratioCameraPrincips ConfiguratioCameraPrincips => _configuratioCameraPrincips;
    }
}