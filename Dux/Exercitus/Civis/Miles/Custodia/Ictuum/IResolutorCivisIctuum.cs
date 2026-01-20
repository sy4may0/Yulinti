namespace Yulinti.Dux.Exercitus {
    internal interface IResolutorCivisIctuum {
        float VisaCapitis(int idCivis);
        float VisaCorporis(int idCivis);
        bool EstVisa(int idCivis);
    }
}