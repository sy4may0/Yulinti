namespace Yulinti.Exercitus.Dux {
    internal interface IResolutorCivisIctuumVisae {
        float VisaCapitis(int idCivis);
        float VisaCorporis(int idCivis);
        bool EstVisa(int idCivis);
    }
}