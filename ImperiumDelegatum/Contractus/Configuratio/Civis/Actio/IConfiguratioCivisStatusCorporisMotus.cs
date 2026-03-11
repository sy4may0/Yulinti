using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioCivisStatusCorporisMotus : IConfiguratioCivisStatusCorporis {
        IDCivisStatusCorporisModiMotus IdModiMotus { get; }
    }
}