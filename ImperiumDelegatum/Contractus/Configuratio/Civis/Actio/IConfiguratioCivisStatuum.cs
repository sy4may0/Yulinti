using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioCivisStatuum {
        IDCivisAnimationis IdAnimationisPraedefinitus { get; }
        IDCivisStatusCorporis IDStatusCorporisIncipalis { get; }
        IConfiguratioCivisStatusCorporis[] StatuumCorporis { get; }
    }
}
