namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IStatusCivisCustodiae {
        void Initare(int idCivis, AbaciCivisStatus abaciCivisStatus);
        void Exire(int idCivis, AbaciCivisStatus abaciCivisStatus);
        void Ordinare(int idCivis, AbaciCivisStatus abaciCivisStatus);
    }
}