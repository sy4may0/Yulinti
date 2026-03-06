using Animancer;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioPuellaeAnimationis {
        public IDPuellaeAnimationis Id { get; }
        public ITransition Animatio { get; }
        public float TempusEvanescentiae { get; }
        public Easing.Function Lenitio { get; }
        public bool EstSimulataneum { get; }
        public bool EstIterans { get; }
    }
}