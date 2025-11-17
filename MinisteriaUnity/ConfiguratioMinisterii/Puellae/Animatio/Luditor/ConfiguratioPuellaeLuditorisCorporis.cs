using UnityEngine;
namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public class ConfiguratioPuellaeLuditorisCorporis {
        [Header("ConfiguratioPuellaeLuditorisCorporis/LuditorisCorporisレイヤー")]
        [SerializeField] private ConfiguratioPuellaeAnimationisIncubitus _incubitus;

        public ConfiguratioPuellaeAnimationisIncubitus Incubitus => _incubitus;
    }
}