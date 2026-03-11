namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IResolutorCivisIctuumVisae {
        float VisaCapitis(int idCivis);
        float VisaCorporis(int idCivis);
        bool EstVisa(int idCivis);
    }
}