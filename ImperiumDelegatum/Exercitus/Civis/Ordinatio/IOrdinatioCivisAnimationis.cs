using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioCivisAnimationis : IOrdinatioCivis {
        IDCivisAnimationisStratum Stratum { get; }
        IDCivisAnimationis IdAnimationis { get; }
    }
}
