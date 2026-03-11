using Animancer;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioPuellaeAnimationis {
        public IDPuellaeAnimationis Id { get; }
        public ITransition Animatio { get; }
        public float TempusEvanescentiae { get; }
        public Easing.Function Lenitio { get; }
        public bool EstSimulataneum { get; }
        public bool EstIterans { get; }
    }
}