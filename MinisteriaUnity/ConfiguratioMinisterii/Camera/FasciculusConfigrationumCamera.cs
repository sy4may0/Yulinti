using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class FasciculusConfigurationumCamera {
        [SerializeField] private ConfiguratioCameraPrincips _configuratioCameraPrincips;

        public ConfiguratioCameraPrincips ConfiguratioCameraPrincips => _configuratioCameraPrincips;
    }
}