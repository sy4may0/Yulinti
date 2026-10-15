using UnityEngine;
using RootMotion.FinalIK;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumCivisSpectandi : IMinisteriumPulsabilis {
        private readonly ILacusAnchorarumCivisLegibile _lacusAnchorarumCivis;
        private readonly IConfiguratioCivisSpectandi _configSpectandi;
        private readonly IOstiumTemporisLegibile _ostiumTemporisLegibile;
        private readonly Transform _locusSpectandi;

        private readonly float[] _pondusDesiderata;
        private readonly float[] _pondusActualis;
        private readonly float[] _velocitas;

        public MinisteriumCivisSpectandi(
            ILacusAnchorarumCivisLegibile lacusAnchorarumCivis,
            IAnchoraPuellae anchoraPuellae,
            IConfiguratioCivisSpectandi configSpectandi,
            IOstiumTemporisLegibile ostiumTemporisLegibile,
            OperatioAnchoraCivisSpectandi operatio
        ) {
            _lacusAnchorarumCivis = lacusAnchorarumCivis;
            _configSpectandi = configSpectandi;
            _ostiumTemporisLegibile = ostiumTemporisLegibile;
            _locusSpectandi = anchoraPuellae.LocusReferensCapitis;

            int longitudo = _lacusAnchorarumCivis.Longitudo;
            _pondusDesiderata = new float[longitudo];
            _pondusActualis = new float[longitudo];
            _velocitas = new float[longitudo];

            operatio.Initiare(Initio, Deleto);
        }

        public int Longitudo => _lacusAnchorarumCivis.Longitudo;

        private void Initio(int id, IAnchoraCivis anchora) {
            Purgare(id);
            if (anchora.LookAtIK == null) return;
            anchora.LookAtIK.solver.target = _locusSpectandi;
            anchora.LookAtIK.solver.SetLookAtWeight(0f);
            Activare(id);
        }

        private void Deleto(int id) {
            Purgare(id);
            if (!ConareLegoLookAtIK(id, out IAnchoraCivis anchora)) return;
            anchora.LookAtIK.solver.SetLookAtWeight(0f);
        }

        private void Purgare(int id) {
            _pondusDesiderata[id] = 0f;
            _pondusActualis[id] = 0f;
            _velocitas[id] = 0f;
        }

        private bool ConareLegoLookAtIK(int id, out IAnchoraCivis anchora) {
            if (!_lacusAnchorarumCivis.ConareLego(id, out anchora)) return false;
            if (anchora.LookAtIK == null) return false;
            if (!anchora.EstActivum) return false;
            return true;
        }

        public void Activare(int id) {
            _pondusDesiderata[id] = 1f;
        }

        public void Deactivare(int id) {
            _pondusDesiderata[id] = 0f;
        }

        public void Pulsus() {
            float intervallum = _ostiumTemporisLegibile.Intervallum;
            float tempusLevigatum = _configSpectandi.TempusLevigatum;
            float epsilonPonderis = _configSpectandi.EpsilonPonderis;
            for (int id = 0; id < _lacusAnchorarumCivis.Longitudo; id++) {
                if (_pondusActualis[id] == _pondusDesiderata[id]) continue;
                if (!ConareLegoLookAtIK(id, out IAnchoraCivis anchora)) continue;

                float pondus = Mathf.SmoothDamp(
                    _pondusActualis[id],
                    _pondusDesiderata[id],
                    ref _velocitas[id],
                    tempusLevigatum,
                    Mathf.Infinity,
                    intervallum
                );
                if (Mathf.Abs(pondus - _pondusDesiderata[id]) < epsilonPonderis) {
                    pondus = _pondusDesiderata[id];
                    _velocitas[id] = 0f;
                }
                _pondusActualis[id] = pondus;
                anchora.LookAtIK.solver.SetLookAtWeight(pondus);
            }
        }
    }
}
