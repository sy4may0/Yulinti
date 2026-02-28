using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioCivisStatuum {
        IDCivisAnimationisContinuata IdAnimationisPraedefinitus { get; }
        IConfiguratioCivisStatusCorporis[] StatuumCorporis { get; }
    }
}