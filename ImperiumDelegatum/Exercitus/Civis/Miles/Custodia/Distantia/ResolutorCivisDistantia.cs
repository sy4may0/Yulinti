using Yulinti.Nucleus;
using Yulinti.ImperiumDelegatum.Contractus;
using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorCivisDistantia {
        private readonly IConfiguratioCivisCustodiaeIctuum _configuratioCivisCustodiae;
        private readonly IOstiumCivisLegibile _civis;
        private readonly IOstiumCivisLociLegibile _loci;
        private readonly IOstiumPuellaeResVisaeLegibile _puellaeResVisae;
        private readonly IOstiumCarrusCivis _carrus;

        public ResolutorCivisDistantia(
            IConfiguratioCivisCustodiaeIctuum configuratioCivisCustodiae,
            IOstiumCivisLegibile civis,
            IOstiumCivisLociLegibile loci,
            IOstiumPuellaeResVisaeLegibile puellaeResVisae,
            IOstiumCarrusCivis carrus
        ) {
            _configuratioCivisCustodiae = configuratioCivisCustodiae;
            _civis = civis;
            _loci = loci;
            _puellaeResVisae = puellaeResVisae;
            _carrus = carrus;
        }

        public void Initare(int idCivis) {
            // ResFluidaCivisCustodiaeの初期化はExecutorCivisCustodiaeが行う。
        }

        public void Ordinare(
            int idCivis
        ) {
            Vector3 positioCivis = _loci.Positio(idCivis);
            Vector3 positioPuellae = _puellaeResVisae.LegoPositionemRadix();
            float distantiaPuellae = (positioCivis - positioPuellae).Length();

            bool estCustodiaeVisae = distantiaPuellae <= _configuratioCivisCustodiae.DistantiaCustodiaeActivum;
            bool estCustodiaeAuditae = distantiaPuellae <= _configuratioCivisCustodiae.DistantiaAuditaeActivum;

            _carrus.PostulareCustodiaeDistantia(
                idCivis,
                distantiaPuellae,
                estCustodiaeVisae,
                estCustodiaeAuditae
            );
        }
    }
}
