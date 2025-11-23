using Animancer;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeAnimationisSectionis {
        NihilAut<ITransition> Animatio { get; }
        float TempusEvanescentiae { get; }
        Easing.Function Lenitio { get; }
        bool EstSimultaneum { get; }
        bool EstImpeditivus { get; }
        bool EstCircularis { get; }
    }
}
