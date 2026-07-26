using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IStatusCivisCustodiae {
        void Initare(int idCivis, AbaciCivisStatusCustodiae abaciCivisStatus);
        void Exire(int idCivis, AbaciCivisStatusCustodiae abaciCivisStatus);
        void Ordinare(int idCivis, AbaciCivisStatusCustodiae abaciCivisStatus);
        IDCivisStatusCustodiae MutareStatus(int idCivis);
    }
}