using Animancer;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Contractus {
    public interface NewIConfiguratioPuellaeAnimationis {
        public NewIDPuellaeAnimationis Id { get; }
        public IDPuellaeAnimationisStratum Stratum { get; }
        public ITransition Animatio { get; }
        public float TempusEvanescentiae { get; }
        public Easing.Function Lenitio { get; }
        public bool EstSimulataneum { get; }
        public bool EstIterans { get; }
    }
}