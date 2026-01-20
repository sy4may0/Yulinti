using Animancer;
using Yulinti.Nucleus;

using Yulinti.Dux.ContractusDucis;
namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioCivisAnimationisUnicae {
        public IDCivisAnimationis Id { get; }
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