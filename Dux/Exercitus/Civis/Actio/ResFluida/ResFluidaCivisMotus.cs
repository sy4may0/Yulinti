namespace Yulinti.Dux.Exercitus {
    public sealed class ResFluidaCivisMotus {
        private int _idPunctumViaeActualis;
        private int _idPunctumViaeProximus;
        private float _velocitasActualisHorizontalis;
        private float _velocitasActualisVerticalis;
        private float _rotatioYActualis;
        private bool _estInTerra;

        public ResFluidaCivisMotus() {
            this._idPunctumViaeActualis = -1;
            this._idPunctumViaeProximus = -1;
            this._velocitasActualisHorizontalis = 0f;
            this._velocitasActualisVerticalis = -2f;
            this._rotatioYActualis = 0f;
            this._estInTerra = true;
        }

        public int IDPunctumViaeActualis => _idPunctumViaeActualis;
        public int IDPunctumViaeProximus => _idPunctumViaeProximus;
        public float VelocitasActualisHorizontalis => _velocitasActualisHorizontalis;
        public float VelocitasActualisVerticalis => _velocitasActualisVerticalis;
        public float RotatioYActualis => _rotatioYActualis;
        public bool EstInTerra => _estInTerra;

        public void Renovare(
            int idPunctumViaeActualis,
            int idPunctumViaeProximus,
            float velocitasActualisHorizontalis,
            float velocitasActualisVerticalis,
            float rotatioYActualis,
            bool estInTerra
        ) {
            _idPunctumViaeActualis = idPunctumViaeActualis;
            _idPunctumViaeProximus = idPunctumViaeProximus;
            _velocitasActualisHorizontalis = velocitasActualisHorizontalis;
            _velocitasActualisVerticalis = velocitasActualisVerticalis;
            _rotatioYActualis = rotatioYActualis;
            _estInTerra = estInTerra;
        }
    }
}