using Animancer;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioPuellaeAnimationisPartis {
        public IDPuellaeAnimationisPartis Id { get; }
        public NihilAut<ITransition> Animatio { get; }
        public float TempusEvanescentiae { get; }
        public Easing.Function Lenitio { get; }
        public bool EstSimultaneum { get; }
        public bool EstImpeditivus { get; }
        public bool EstCircularis { get; }
        public bool EstObsignatus { get; }
    }
}
