namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IResFluidaCivisCustodiaeLegibile {
        int Longitudo { get; }
        bool EstActivum(int idCivis);

        // 視認Ictuum(頭部)
        float VisaCapitis(int idCivis);
        // 視認Ictuum(胴体)
        float VisaCorporis(int idCivis);
        // 視認レシオ(0~1)
        float RatioVisae(int idCivis);
        // 視認判定
        bool EstVisa(int idCivis);
        // 視認頭部判定
        bool EstVisaCapitis(int idCivis);
        // 視認胴体判定
        bool EstVisaCorporis(int idCivis);

        // 聴認レシオ(0~1)
        float RatioAudita(int idCivis);
        // 聴認判定
        bool EstAudita(int idCivis);

        // Puellaeまでの距離
        float DistantiaPuellae(int idCivis);
        // 視認範囲内判定
        bool EstCustodiaeVisae(int idCivis);
        // 聴認範囲内判定
        bool EstCustodiaeAuditae(int idCivis);

        // Puellaeを裸として視認しているか(前面/背面)
        bool EstSpectareNudusAnterior(int idCivis);
        bool EstSpectareNudusPosterior(int idCivis);
        bool EstSpectareNudus(int idCivis);
    }
}
