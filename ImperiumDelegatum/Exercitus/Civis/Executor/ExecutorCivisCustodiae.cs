using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Custodiae(視認/聴認/距離)の解決結果をResFluidaCivisCustodiaeに反映する。
    // Executareではキャッシュ(Phantasma)に退避し、Confirmareでまとめて反映する。
    // これによりフレーム内での参照値は前フレームの確定値で安定する(1フレーム遅延を許容)。
    // 複数ソースからの更新が発生しても、参照タイミングに依存しない設計とするための遅延適用。
    internal sealed class ExecutorCivisCustodiae : IExecutorCivis {
        private readonly ResFluidaCivisCustodiae _resFluidaCustodiae;

        // 反映待ちのキャッシュ(最後に投入された値で上書きされる)。
        private readonly float[] _visaCapitis;
        private readonly float[] _visaCorporis;
        private readonly float[] _audita;
        private readonly float[] _distantiaPuellae;
        private readonly bool[] _estCustodiaeVisae;
        private readonly bool[] _estCustodiaeAuditae;

        public ExecutorCivisCustodiae(
            ResFluidaCivisCustodiae resFluidaCustodiae
        ) {
            _resFluidaCustodiae = resFluidaCustodiae;

            int longitudo = resFluidaCustodiae.Longitudo;
            _visaCapitis = new float[longitudo];
            _visaCorporis = new float[longitudo];
            _audita = new float[longitudo];
            _distantiaPuellae = new float[longitudo];
            _estCustodiaeVisae = new bool[longitudo];
            _estCustodiaeAuditae = new bool[longitudo];

            for (int i = 0; i < longitudo; i++) {
                InitarePhantasma(i);
            }
        }

        private void InitarePhantasma(int idCivis) {
            _visaCapitis[idCivis] = 0f;
            _visaCorporis[idCivis] = 0f;
            _audita[idCivis] = 0f;
            _distantiaPuellae[idCivis] = float.MaxValue;
            _estCustodiaeVisae[idCivis] = false;
            _estCustodiaeAuditae[idCivis] = false;
        }

        public void Initare(int idCivis) {
            InitarePhantasma(idCivis);
            _resFluidaCustodiae.Purgare(idCivis);
        }

        public void Primum(int idCivis) {
        }

        public void Executare(int idCivis, IOrdinatioCivisCustodiae custodiae) {
            if (custodiae.DistantiaPuellae.HasValue) {
                _distantiaPuellae[idCivis] = custodiae.DistantiaPuellae.Value;
                _estCustodiaeVisae[idCivis] = custodiae.EstCustodiaeVisae ?? false;
                _estCustodiaeAuditae[idCivis] = custodiae.EstCustodiaeAuditae ?? false;
            }

            if (custodiae.VisaCapitis.HasValue || custodiae.VisaCorporis.HasValue) {
                _visaCapitis[idCivis] = custodiae.VisaCapitis ?? 0f;
                _visaCorporis[idCivis] = custodiae.VisaCorporis ?? 0f;
            }

            if (custodiae.Audita.HasValue) {
                _audita[idCivis] = custodiae.Audita.Value;
            }
        }

        public void Confirmare(int idCivis) {
            _resFluidaCustodiae.RenovareDistantia(
                idCivis,
                _distantiaPuellae[idCivis],
                _estCustodiaeVisae[idCivis],
                _estCustodiaeAuditae[idCivis]
            );
            _resFluidaCustodiae.RenovareIctuumVisae(
                idCivis,
                _visaCapitis[idCivis],
                _visaCorporis[idCivis]
            );
            _resFluidaCustodiae.RenovareIctuumAuditae(
                idCivis,
                _audita[idCivis]
            );
        }

        public void Purgare(int idCivis) {
            InitarePhantasma(idCivis);
            _resFluidaCustodiae.Purgare(idCivis);
        }
    }
}
