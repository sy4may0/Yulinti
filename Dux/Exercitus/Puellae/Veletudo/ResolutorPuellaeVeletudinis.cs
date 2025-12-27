using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorPuellaeVeletudinis {
        private float _dtVigoris;
        private float _dtPatientiae;
        private float _dtClaritatis;
        private float _dtAetheris;
        private float _dtIntentionis;

        public ResolutorPuellaeVeletudinis() {
            _dtVigoris = 0f;
            _dtPatientiae = 0f;
            _dtClaritatis = 0f;
            _dtAetheris = 0f;
            _dtIntentionis = 0f;
        }

        public void Resolvere(OrdinatioPuellaeVeletudinis ordinatio) {
            _dtVigoris += ordinatio.DtVigoris;
            _dtPatientiae += ordinatio.DtPatientiae;
            _dtClaritatis += ordinatio.DtClaritatis;
            _dtAetheris += ordinatio.DtAetheris;
            _dtIntentionis += ordinatio.DtIntentionis;
        }

        public void Applicare(ref ResFluidaPuellaeVeletudinis resFluida) {
            resFluida.IncrementareVigoris(_dtVigoris);
            resFluida.IncrementarePatientiae(_dtPatientiae);
            resFluida.IncrementareClaritatis(_dtClaritatis);
            resFluida.IncrementareAetheris(_dtAetheris);

            resFluida.RenovareIntentio(_dtIntentionis);
        }
    }
}