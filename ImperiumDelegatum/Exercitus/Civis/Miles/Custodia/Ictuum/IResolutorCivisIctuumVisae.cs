namespace Yulinti.ImperiumDelegatum.Exercitus {
    // TODO: Custodiaの再構成が終わったら、01レシオ出力に変更し、メソッド名もRatioAuditae/RatioVisaeに変更する
    internal interface IResolutorCivisIctuumVisae {
        float VisaCapitis(int idCivis);
        float VisaCorporis(int idCivis);
        float RatioVisus(int idCivis);
        bool EstVisa(int idCivis);
    }
}