using System;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResFluidaCivisCustodiae : IResFluidaCivisCustodiaeLegibile {
        // 視認Ictuum(頭部/胴体)
        private readonly float[] _visaCapitis;
        private readonly float[] _visaCorporis;
        // 聴認Ictuum
        private readonly float[] _audita;

        // Puellaeまでの距離
        private readonly float[] _distantiaPuellae;
        // 視認/聴認範囲内判定
        private readonly bool[] _estCustodiaeVisae;
        private readonly bool[] _estCustodiaeAuditae;

        // RatioVisus算出用の視認対象数。
        private readonly int _longitudoResVisae;

        public ResFluidaCivisCustodiae(IOstiumCivisLegibile ostiumCivis) {
            int longitudo = ostiumCivis.Longitudo;

            _visaCapitis = new float[longitudo];
            _visaCorporis = new float[longitudo];
            _audita = new float[longitudo];

            _distantiaPuellae = new float[longitudo];
            _estCustodiaeVisae = new bool[longitudo];
            _estCustodiaeAuditae = new bool[longitudo];

            _longitudoResVisae =
                Enum.GetValues(typeof(IDPuellaeResVisaeCapitis)).Length +
                Enum.GetValues(typeof(IDPuellaeResVisaePectoris)).Length +
                Enum.GetValues(typeof(IDPuellaeResVisaeNatium)).Length;

            for (int i = 0; i < longitudo; i++) {
                InitareCivis(i);
            }
        }

        private void InitareCivis(int idCivis) {
            _visaCapitis[idCivis] = 0f;
            _visaCorporis[idCivis] = 0f;
            _audita[idCivis] = 0f;

            _distantiaPuellae[idCivis] = float.MaxValue;
            _estCustodiaeVisae[idCivis] = false;
            _estCustodiaeAuditae[idCivis] = false;
        }

        public int Longitudo => _visaCapitis.Length;

        public float VisaCapitis(int idCivis) => _visaCapitis[idCivis];
        public float VisaCorporis(int idCivis) => _visaCorporis[idCivis];
        public float RatioVisus(int idCivis) => (_visaCapitis[idCivis] + _visaCorporis[idCivis]) / _longitudoResVisae;
        public bool EstVisa(int idCivis) => _visaCapitis[idCivis] + _visaCorporis[idCivis] > Numerus.Epsilon;

        public float Audita(int idCivis) => _audita[idCivis];
        public bool EstAudita(int idCivis) => _audita[idCivis] > Numerus.Epsilon;

        public float DistantiaPuellae(int idCivis) => _distantiaPuellae[idCivis];
        public bool EstCustodiaeVisae(int idCivis) => _estCustodiaeVisae[idCivis];
        public bool EstCustodiaeAuditae(int idCivis) => _estCustodiaeAuditae[idCivis];

        public void RenovareDistantia(
            int idCivis,
            float distantiaPuellae,
            bool estCustodiaeVisae,
            bool estCustodiaeAuditae
        ) {
            _distantiaPuellae[idCivis] = distantiaPuellae;
            _estCustodiaeVisae[idCivis] = estCustodiaeVisae;
            _estCustodiaeAuditae[idCivis] = estCustodiaeAuditae;
        }

        public void RenovareIctuumVisae(
            int idCivis,
            float visaCapitis,
            float visaCorporis
        ) {
            _visaCapitis[idCivis] = visaCapitis;
            _visaCorporis[idCivis] = visaCorporis;
        }

        public void RenovareIctuumAuditae(
            int idCivis,
            float audita
        ) {
            _audita[idCivis] = audita;
        }

        public void Purgare(int idCivis) {
            InitareCivis(idCivis);
        }
    }
}
