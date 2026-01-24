using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisStatuum {
        IDCivisAnimationisContinuata IdAnimationisPraedefinitus { get; }
        IConfiguratioCivisStatusCorporis[] StatuumCorporis { get; }
    }
}