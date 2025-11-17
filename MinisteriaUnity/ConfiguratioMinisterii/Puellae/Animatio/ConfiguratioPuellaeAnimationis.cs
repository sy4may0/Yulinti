using UnityEngine;
using Animancer;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public class ConfiguratioPuellaeAnimationis : IConfiguratioPuellaeAnimationis {
        [Header("ConfiguratioPuellaeAnimationis/アニメーション設定")]
        [SerializeField] private AnimancerComponent _animancer;
        [SerializeField] private ConfiguratioPuellaeLuditorisFundamenti _luditorisFundamenti;
        [SerializeField] private ConfiguratioPuellaeLuditorisCorporis _luditorisCorporis;

        public AnimancerComponent Animancer => _animancer;
        public ConfiguratioPuellaeLuditorisFundamenti LuditorisFundamenti => _luditorisFundamenti;
        public ConfiguratioPuellaeLuditorisCorporis LuditorisCorporis => _luditorisCorporis;
    }
}