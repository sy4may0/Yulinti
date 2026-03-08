using Animancer;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioCivisAnimationis {
        IDCivisAnimationis Id { get; }
        ITransition Animatio { get; }
        float TempusEvanescentiae { get; }
        Easing.Function Lenitio { get; }
        bool EstSimulataneum { get; }
        bool EstIterans { get; }
    }
}
