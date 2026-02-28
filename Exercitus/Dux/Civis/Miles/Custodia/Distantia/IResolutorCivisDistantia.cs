namespace Yulinti.Exercitus.Dux {
    internal interface IResolutorCivisDistantia {
        float DistantiaPuellae(int idCivis);
        bool EstCustodiaeVisae(int idCivis);
        bool EstCustodiaeAuditae(int idCivis);
    }
}