using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public class ConfiguratioPuellaeLuditorisFundamenti {
        [Header("ConfiguratioPuellaeLuditorisFundamenti/LuditorisFundamentiレイヤー")]
        [SerializeField] private ConfiguratioPuellaeAnimationisBasisOrdinariae _basisOrdinariae;

        public ConfiguratioPuellaeAnimationisBasisOrdinariae BasisOrdinariae => _basisOrdinariae;
    }
}