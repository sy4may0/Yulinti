using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioCivisStatuum {
        IDCivisAnimationis IdAnimationisPraedefinitus { get; }
        IDCivisStatusCorporis IDStatusCorporisIncipalis { get; }
        IConfiguratioCivisStatusCorporis[] StatuumCorporis { get; }
    }
}
