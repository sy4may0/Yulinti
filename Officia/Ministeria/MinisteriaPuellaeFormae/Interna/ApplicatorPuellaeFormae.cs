using System.Collections.Generic;

namespace Yulinti.Officia.Ministeria {
    internal sealed class ApplicatorPuellaeFormae {
        private readonly IReadOnlyList<FormaPuellaeFigurae> _figurae;
        private readonly IReadOnlyList<FormaPuellaeOssisCorrectorium> _ossa;

        public ApplicatorPuellaeFormae(
            IReadOnlyList<FormaPuellaeFigurae> figurae,
            IReadOnlyList<FormaPuellaeOssisCorrectorium> ossa
        ) {
            _figurae = figurae;
            _ossa = ossa;
        }

        public void Applicare(float ratio) {
            foreach (var figurae in _figurae) {
                figurae.Applicare(ratio);
            }

            foreach (var ossa in _ossa) {
                ossa.Applicare(ratio);
            }
        }
    }
}
