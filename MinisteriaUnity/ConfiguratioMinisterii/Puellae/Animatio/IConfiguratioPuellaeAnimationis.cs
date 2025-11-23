using Animancer;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeAnimationis {
        NihilAut<AnimancerComponent> Animancer { get; }
        ConfiguratioPuellaeLuditorisFundamenti LuditorisFundamenti { get; }
        ConfiguratioPuellaeLuditorisCorporis LuditorisCorporis { get; }
    }
}
