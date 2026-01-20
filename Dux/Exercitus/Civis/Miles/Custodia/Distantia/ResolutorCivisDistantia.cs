using Yulinti.Nucleus;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorCivisDistantia : IResolutorCivisDistantia {
        private readonly ContextusCivisOstiorumLegibile _contextus;

        private readonly float[] _distantiaPuellae;

        public ResolutorCivisDistantia(
            ContextusCivisOstiorumLegibile contextus
        ) {
            _contextus = contextus;
        }

        public float DistantiaPuellae(int idCivis) => _distantiaPuellae[idCivis];
        public bool EstCustodiae(int idCivis) => _distantiaPuellae[idCivis] <= _contextus.Configuratio.Custodiae.DistantiaCustodiaeActivum;

        public void Ordinare(
            int idCivis
        ) {
            Vector3 positioCivis = _contextus.Loci.Positio(idCivis);
            Vector3 positioPuellae = _contextus.PuellaeResVisae.LegoPositionemRadix();
            _distantiaPuellae[idCivis] = (positioCivis - positioPuellae).Length();
        }
    }
}