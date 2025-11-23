using UnityEngine;
using Animancer;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public class ConfiguratioPuellaeAnimationis : IConfiguratioPuellaeAnimationis {
        [Header("ConfiguratioPuellaeAnimationis/アニメーション設定")]
        [SerializeField] private AnimancerComponent _animancer;
        [SerializeField] private ConfiguratioPuellaeLuditorisFundamenti _luditorisFundamenti;
        [SerializeField] private ConfiguratioPuellaeLuditorisCorporis _luditorisCorporis;

        public NihilAut<AnimancerComponent> Animancer => new NihilAut<AnimancerComponent>(_animancer);
        public ConfiguratioPuellaeLuditorisFundamenti LuditorisFundamenti => _luditorisFundamenti;
        public ConfiguratioPuellaeLuditorisCorporis LuditorisCorporis => _luditorisCorporis;
    }
}
