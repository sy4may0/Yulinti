using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.Officia.Instrumentarium;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumSpatiiCivisVeletudinis : IVelumSpatiiCivisVeletudinis {
        private readonly OperatioAnchoraCivisVelum _operatioAnchoraCivisVelum;
        private readonly ITurrisCorrectrix _turrisCorrectrix;
        private IAnchoraVelumSpatiiCivisVeletudinis[] _anchorae;

        public VelumSpatiiCivisVeletudinis(
            OperatioAnchoraCivisVelum operatioAnchoraCivisVelum,
            ITurrisCorrectrix turrisCorrectrix
        ) {
            _operatioAnchoraCivisVelum = operatioAnchoraCivisVelum;
            _turrisCorrectrix = turrisCorrectrix;
            _anchorae = null;
        }

        // Anchoraコールバックの登録も兼ねるため、最初のManifestatioより前に呼ぶこと。
        // 呼び出し元はPraeco(Incipere/Liberare)。
        public void Initiare(int longitudo) {
            _anchorae = new IAnchoraVelumSpatiiCivisVeletudinis[longitudo];
            _operatioAnchoraCivisVelum.Initiare(Initio, Purgare);
        }

        public void Liberare() {
            _operatioAnchoraCivisVelum.Purgare();
            _anchorae = null;
        }

        private void Initio(int idCivis, IAnchoraCivis anchora) {
            if (_anchorae == null) return;
            if (idCivis < 0 || idCivis >= _anchorae.Length) return;

            IAnchoraVelumSpatiiCivisVeletudinis anchoraVelum = anchora.VelumVeletudinis;
            _anchorae[idCivis] = anchoraVelum;
            if (anchoraVelum == null) return;

            anchoraVelum.Spirituare();
            if (_turrisCorrectrix.EstCorrigere()) {
                anchoraVelum.IncarnareCorrigere();
            }
        }

        private void Purgare(int idCivis) {
            if (_anchorae == null) return;
            if (idCivis < 0 || idCivis >= _anchorae.Length) return;

            _anchorae[idCivis] = null;
        }

        private IAnchoraVelumSpatiiCivisVeletudinis Anchora(int idCivis) {
            if (_anchorae == null) return null;
            if (idCivis < 0 || idCivis >= _anchorae.Length) return null;

            return _anchorae[idCivis];
        }

        public void Incarnare() {
            if (_anchorae == null) return;

            for (int i = 0; i < _anchorae.Length; i++) {
                IncarnareUnus(i);
            }
        }
        public void IncarnareUnus(int idCivis) {
            IAnchoraVelumSpatiiCivisVeletudinis anchora = Anchora(idCivis);
            if (anchora == null) return;

            anchora.Incarnare();
            if (_turrisCorrectrix.EstCorrigere()) {
                anchora.IncarnareCorrigere();
            }
        }

        public void Spirituare() {
            if (_anchorae == null) return;

            for (int i = 0; i < _anchorae.Length; i++) {
                SpirituareUnus(i);
            }
        }
        public void SpirituareUnus(int idCivis) {
            IAnchoraVelumSpatiiCivisVeletudinis anchora = Anchora(idCivis);
            if (anchora == null) return;

            anchora.Spirituare();
            if (_turrisCorrectrix.EstCorrigere()) {
                anchora.SpirituareCorrigere();
            }
        }

        public bool EstActivum => estActivum();

        private bool estActivum() {
            if (_anchorae == null) return false;

            for (int i = 0; i < _anchorae.Length; i++) {
                if (_anchorae[i] != null) {
                    return true;
                }
            }
            return false;
        }

        public void PonoRotationem(int idCivis, System.Numerics.Quaternion rotatio) {
            IAnchoraVelumSpatiiCivisVeletudinis anchora = Anchora(idCivis);
            if (anchora == null) return;

            anchora.PonoRotationem(InterpresNumeri.ToUnity(rotatio));
        }

        public void PonoIntentionem(int idCivis, float intentio) {
            IAnchoraVelumSpatiiCivisVeletudinis anchora = Anchora(idCivis);
            if (anchora == null) return;

            anchora.PonoIntentionem(intentio);
        }

        public void PonoSuspectum(int idCivis, float suspecta) {
            IAnchoraVelumSpatiiCivisVeletudinis anchora = Anchora(idCivis);
            if (anchora == null) return;

            anchora.PonoSuspectum(suspecta);
        }

        public void PonoTextus(int idCivis, string textus) {
            IAnchoraVelumSpatiiCivisVeletudinis anchora = Anchora(idCivis);
            if (anchora == null) return;

            anchora.PonoTextus(textus);
        }
    }
}
