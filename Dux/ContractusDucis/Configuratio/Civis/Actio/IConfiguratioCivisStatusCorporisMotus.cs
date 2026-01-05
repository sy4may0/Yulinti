using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisStatusCorporisMotus : IConfiguratioCivisStatusCorporis {
        IDCivisStatusCorporisModiMotus IdModiMotus { get; }
    }
}