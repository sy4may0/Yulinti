using Animancer;
using Yulinti.Unity.Contractus;

using Yulinti.Exercitus.Contractus;
namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioPuellaeAnimationisUnicae {
        public IDPuellaeAnimationis Id { get; }
        // 注意: ここはnull許可。nullでレイヤー停止。
        public ITransition Animatio { get; }
        public float TempusEvanescentiae { get; }
        public Easing.Function Lenitio { get; }
        public bool EstSimultaneum { get; }
        public bool EstImpeditivus { get; }
        public bool EstCircularis { get; }
        public bool EstObsignatus { get; }
        public bool EstTerminare { get; }
    }
}
