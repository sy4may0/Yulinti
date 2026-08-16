using Yulinti.Auctoritas.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.Officia.Instrumentarium;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Velum {
    internal sealed class VelumSpatiiPuellaeVeletudinis : IVelumSpatiiPuellaeVeletudinis {
        private readonly IAnchoraVelumSpatiiPuellaeVeletudinis _anchoraVelumSpatiiPuellaeVeletudinis;
        private readonly ITurrisCorrectrix _turrisCorrectrix;

        public VelumSpatiiPuellaeVeletudinis(
            IAnchoraVelumSpatiiPuellaeVeletudinis anchoraVelumSpatiiPuellaeVeletudinis,
            ITurrisCorrectrix turrisCorrectrix
        ) {
            _anchoraVelumSpatiiPuellaeVeletudinis = anchoraVelumSpatiiPuellaeVeletudinis;
            _turrisCorrectrix = turrisCorrectrix;

            if (_turrisCorrectrix.EstCorrigere()) {
                _anchoraVelumSpatiiPuellaeVeletudinis.IncarnareCorrigere();
            } else {
                _anchoraVelumSpatiiPuellaeVeletudinis.SpirituareCorrigere();
            }
        }

        public void Incarnare() {
            _anchoraVelumSpatiiPuellaeVeletudinis.Incarnare();
        }

        public void Spirituare() {
            _anchoraVelumSpatiiPuellaeVeletudinis.Spirituare();
        }

        public bool EstActivum => _anchoraVelumSpatiiPuellaeVeletudinis.EstActivum;

        public void PonoRotationem(System.Numerics.Quaternion rotationem) {
            _anchoraVelumSpatiiPuellaeVeletudinis.PonoRotationem(InterpresNumeri.ToUnity(rotationem));
        }

        public void PonoVigorem(float ratioVigoris) {
            _anchoraVelumSpatiiPuellaeVeletudinis.PonoVigorem(ratioVigoris);
        }

        public void PonoPatientiam(float ratioPatientiae) {
            _anchoraVelumSpatiiPuellaeVeletudinis.PonoPatientiam(ratioPatientiae);
        }

        public void PonoTextus(string textus) {
            if (!_turrisCorrectrix.EstCorrigere()) return;
            _anchoraVelumSpatiiPuellaeVeletudinis.PonoTextus(textus);
        }
    }
}
