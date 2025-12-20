using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisStatuum {
        IDCivisAnimationisContinuata IdAnimationisPraedefinitus { get; }
        IConfiguratioCivisStatusCorporis[] StatusCorporum { get; }
        IConfiguratioCivisStatusPartis[] StatusPartium { get; }
    }
}