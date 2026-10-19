namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioCivisCustodiae : OrdinatioCivis, IOrdinatioCivisCustodiae {
        private float? _visaCapitis;
        private float? _visaCorporis;
        private float? _audita;

        private float? _distantiaPuellae;
        private bool? _estCustodiaeVisae;
        private bool? _estCustodiaeAuditae;

        private bool? _estSpectareNudusAnterior;
        private bool? _estSpectareNudusPosterior;

        public OrdinatioCivisCustodiae(int idCivis)
            : base(idCivis, true, SpeciesOrdinatioCivis.VeletudinisCustodiae) {
            _visaCapitis = null;
            _visaCorporis = null;
            _audita = null;
            _distantiaPuellae = null;
            _estCustodiaeVisae = null;
            _estCustodiaeAuditae = null;
            _estSpectareNudusAnterior = null;
            _estSpectareNudusPosterior = null;
        }

        public float? VisaCapitis => _visaCapitis;
        public float? VisaCorporis => _visaCorporis;
        public float? Audita => _audita;
        public float? DistantiaPuellae => _distantiaPuellae;
        public bool? EstCustodiaeVisae => _estCustodiaeVisae;
        public bool? EstCustodiaeAuditae => _estCustodiaeAuditae;
        public bool? EstSpectareNudusAnterior => _estSpectareNudusAnterior;
        public bool? EstSpectareNudusPosterior => _estSpectareNudusPosterior;

        public override void Purgere() {
            _estApplicandum = false;
            _visaCapitis = null;
            _visaCorporis = null;
            _audita = null;
            _distantiaPuellae = null;
            _estCustodiaeVisae = null;
            _estCustodiaeAuditae = null;
            _estSpectareNudusAnterior = null;
            _estSpectareNudusPosterior = null;
        }

        public void Pono(
            float? visaCapitis = null,
            float? visaCorporis = null,
            float? audita = null,
            float? distantiaPuellae = null,
            bool? estCustodiaeVisae = null,
            bool? estCustodiaeAuditae = null,
            bool? estSpectareNudusAnterior = null,
            bool? estSpectareNudusPosterior = null
        ) {
            _estApplicandum = true;
            _visaCapitis = visaCapitis;
            _visaCorporis = visaCorporis;
            _audita = audita;
            _distantiaPuellae = distantiaPuellae;
            _estCustodiaeVisae = estCustodiaeVisae;
            _estCustodiaeAuditae = estCustodiaeAuditae;
            _estSpectareNudusAnterior = estSpectareNudusAnterior;
            _estSpectareNudusPosterior = estSpectareNudusPosterior;
        }
    }
}
