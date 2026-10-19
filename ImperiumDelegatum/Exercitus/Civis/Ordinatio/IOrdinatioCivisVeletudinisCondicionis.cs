using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioCivisVeletudinisCondicionis : IOrdinatioCivis {
        // 警備ステータス
        IDCivisStatusCustodiae? StatusCustodiaeCurrens { get; }
    }
}
