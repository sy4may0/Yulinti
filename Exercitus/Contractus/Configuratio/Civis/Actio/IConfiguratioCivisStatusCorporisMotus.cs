using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioCivisStatusCorporisMotus : IConfiguratioCivisStatusCorporis {
        IDCivisStatusCorporisModiMotus IdModiMotus { get; }
    }
}