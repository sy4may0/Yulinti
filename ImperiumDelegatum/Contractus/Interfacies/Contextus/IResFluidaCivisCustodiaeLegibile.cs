namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IResFluidaCivisCustodiaeLegibile {
        int Longitudo { get; }

        // 視認Ictuum(頭部)
        float VisaCapitis(int idCivis);
        // 視認Ictuum(胴体)
        float VisaCorporis(int idCivis);
        // 視認レシオ(0~1)
        float RatioVisus(int idCivis);
        // 視認判定
        bool EstVisa(int idCivis);

        // 聴認Ictuum
        float Audita(int idCivis);
        // 聴認判定
        bool EstAudita(int idCivis);

        // Puellaeまでの距離
        float DistantiaPuellae(int idCivis);
        // 視認範囲内判定
        bool EstCustodiaeVisae(int idCivis);
        // 聴認範囲内判定
        bool EstCustodiaeAuditae(int idCivis);
    }
}
