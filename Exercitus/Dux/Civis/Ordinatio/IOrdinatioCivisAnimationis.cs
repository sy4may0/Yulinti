using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal interface IOrdinatioCivisAnimationis : IOrdinatioCivis {
        IDCivisAnimationisStratum Stratum { get; }
        IDCivisAnimationis IdAnimationis { get; }
    }
}
