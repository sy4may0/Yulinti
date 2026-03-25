using Yulinti.Nucleus;
using Yulinti.ImperiumDelegatum.Contractus;
using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorCivisDistantia : IResolutorCivisDistantia {
        private readonly IConfiguratioCivisCustodiae _configuratioCivisCustodiae;
        private readonly IOstiumCivisLegibile _civis;
        private readonly IOstiumCivisLociLegibile _loci;
        private readonly IOstiumPuellaeResVisaeLegibile _puellaeResVisae;

        private readonly float[] _distantiaPuellae;

        public ResolutorCivisDistantia(
            IConfiguratioCivisCustodiae configuratioCivisCustodiae,
            IOstiumCivisLegibile civis,
            IOstiumCivisLociLegibile loci,
            IOstiumPuellaeResVisaeLegibile puellaeResVisae
        ) {
            _configuratioCivisCustodiae = configuratioCivisCustodiae;
            _civis = civis;
            _loci = loci;
            _puellaeResVisae = puellaeResVisae;
            _distantiaPuellae = new float[_civis.Longitudo];
            for (int i = 0; i < _civis.Longitudo; i++) {
                _distantiaPuellae[i] = float.MaxValue;
            }
        }

        public void Initare(int idCivis) {
            _distantiaPuellae[idCivis] = float.MaxValue;
        }

        public float DistantiaPuellae(int idCivis) => _distantiaPuellae[idCivis];
        public bool EstCustodiaeVisae(int idCivis) => _distantiaPuellae[idCivis] <= _configuratioCivisCustodiae.DistantiaCustodiaeActivum;
        public bool EstCustodiaeAuditae(int idCivis) => _distantiaPuellae[idCivis] <= _configuratioCivisCustodiae.DistantiaAuditaeActivum;

        public void Ordinare(
            int idCivis
        ) {
            Vector3 positioCivis = _loci.Positio(idCivis);
            Vector3 positioPuellae = _puellaeResVisae.LegoPositionemRadix();
            _distantiaPuellae[idCivis] = (positioCivis - positioPuellae).Length();
        }
    }
}