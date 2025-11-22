using Animancer;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    public interface IConfiguratioPuellaeAnimationisSectionis {
        ITransition Animatio { get; }
        float TempusEvanescentiae { get; }
        Easing.Function Lenitio { get; }
        bool EstSimultaneum { get; }
        bool EstImpeditivus { get; }
        bool EstCircularis { get; }
    }
}