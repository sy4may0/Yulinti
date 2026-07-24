namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioCivisCustodiae : IOrdinatioCivis {
        // 視認Ictuum(頭部)
        float? VisaCapitis { get; }
        // 視認Ictuum(胴体)
        float? VisaCorporis { get; }
        // 聴認Ictuum
        float? Audita { get; }

        // Puellaeまでの距離
        float? DistantiaPuellae { get; }
        // 視認範囲内判定
        bool? EstCustodiaeVisae { get; }
        // 聴認範囲内判定
        bool? EstCustodiaeAuditae { get; }
    }
}
