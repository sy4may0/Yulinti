using Animancer;
namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeAnimationis {
        AnimancerComponent Animancer { get; }
        ConfiguratioPuellaeLuditorisFundamenti LuditorisFundamenti { get; }
        ConfiguratioPuellaeLuditorisCorporis LuditorisCorporis { get; }
    }
}