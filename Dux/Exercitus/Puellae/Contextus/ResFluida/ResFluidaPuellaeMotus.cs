using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaPuellaeMotus : IResFluidaPuellaeMotusLegibile {
        private float _velocitasActualisHorizontalis;
        private float _rotatioYActualis;
        private bool _estInTerra;

        public ResFluidaPuellaeMotus() {
            this._velocitasActualisHorizontalis = 0f;
            this._rotatioYActualis = 0f;
            this._estInTerra = true;
        }

        public float VelocitasActualisHorizontalis => _velocitasActualisHorizontalis;
        public float RotatioYActualis => _rotatioYActualis;
        public bool EstInTerra => _estInTerra;

        public void RenovareVelocitasActualisHorizontalis(float velocitasActualisHorizontalis) {
            _velocitasActualisHorizontalis = velocitasActualisHorizontalis;
        }
        public void RenovareRotatioYActualis(float rotatioYActualis) {
            _rotatioYActualis = rotatioYActualis;
        }
        public void RenovareEstInTerra(bool estInTerra) {
            _estInTerra = estInTerra;
        }

        public void Renovare(float velocitasActualisHorizontalis, float rotatioYActualis, bool estInTerra) {
            _velocitasActualisHorizontalis = velocitasActualisHorizontalis;
            _rotatioYActualis = rotatioYActualis;
            _estInTerra = estInTerra;
        }

        public void Purgare() {
            _velocitasActualisHorizontalis = 0f;
            _rotatioYActualis = 0f;
            _estInTerra = true;
        }
    }
}