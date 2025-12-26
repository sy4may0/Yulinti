namespace Yulinti.Dux.Exercitus {
    public struct OrdinatioResFluidaPuellaeMotus {
        public readonly float velocitasActualisHorizontalis;
        public readonly float velocitasActualisVerticalis;
        public readonly float rotatioYActualis;
        public readonly bool estInTerra;

        public OrdinatioResFluidaPuellaeMotus(
            float velocitasActualisHorizontalis,
            float velocitasActualisVerticalis,
            float rotatioYActualis,
            bool estInTerra
        ) {
            this.velocitasActualisHorizontalis = velocitasActualisHorizontalis;
            this.velocitasActualisVerticalis = velocitasActualisVerticalis;
            this.rotatioYActualis = rotatioYActualis;
            this.estInTerra = estInTerra;
        }
    }

    public sealed class ResFluidaPuellaeMotus {
        private float _velocitasActualisHorizontalis;
        private float _velocitasActualisVerticalis;
        private float _rotatioYActualis;
        private bool _estInTerra;

        public ResFluidaPuellaeMotus() {
            this._velocitasActualisHorizontalis = 0f;
            this._velocitasActualisVerticalis = -2f;
            this._rotatioYActualis = 0f;
            this._estInTerra = true;
        }

        public float VelocitasActualisHorizontalis => _velocitasActualisHorizontalis;
        public float VelocitasActualisVerticalis => _velocitasActualisVerticalis;
        public float RotatioYActualis => _rotatioYActualis;
        public bool EstInTerra => _estInTerra;

        public void Renovare(
            float velocitasActualisHorizontalis,
            float velocitasActualisVerticalis,
            float rotatioYActualis,
            bool estInTerra
        ) {
            _velocitasActualisHorizontalis = velocitasActualisHorizontalis;
            _velocitasActualisVerticalis = velocitasActualisVerticalis;
            _rotatioYActualis = rotatioYActualis;
            _estInTerra = estInTerra;
        }

        public void Renovare(OrdinatioResFluidaPuellaeMotus ordinatio) {
            _velocitasActualisHorizontalis = ordinatio.velocitasActualisHorizontalis;
            _velocitasActualisVerticalis = ordinatio.velocitasActualisVerticalis;
            _rotatioYActualis = ordinatio.rotatioYActualis;
            _estInTerra = ordinatio.estInTerra;
        }
    }
}