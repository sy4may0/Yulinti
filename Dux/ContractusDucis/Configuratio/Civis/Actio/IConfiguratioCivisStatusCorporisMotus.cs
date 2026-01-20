using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisStatusCorporisMotus : IConfiguratioCivisStatusCorporis {
        IDCivisStatusCorporisModiMotus IdModiMotus { get; }
    }
}