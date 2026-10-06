using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IStatusCivisCustodiae {
        IDCivisStatusCustodiae Id { get; }

        void Intrare(int idCivis);

        void Exire(int idCivis);

        void Ordinare(int idCivis);

        IDCivisStatusCustodiae MutareStatus(int idCivis);
    }
}