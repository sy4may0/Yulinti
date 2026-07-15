namespace Yulinti.ImperiumDelegatum.Exercitus {
    // TODO: Custodiaの再構成が終わったら、01レシオ出力に変更し、メソッド名もRatioAuditae/RatioVisaeに変更する
    internal interface IResolutorCivisIctuumAuditae {
        float Audita(int idCivis);
        bool EstAudita(int idCivis);
    }
}