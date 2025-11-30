namespace Yulinti.Dux.Miles {
    internal sealed class ResFuluidaMotus{
        public float _velocitasActualisHorizontal;
        public float _velocitasActualisVertical;
        public float _rotatioYActualis;
        public bool _estInTerra;

        public ResFuluidaMotus() {
            this._velocitasActualisHorizontal = 0f;
            this._velocitasActualisVertical = -2f;
            this._rotatioYActualis = 0f;
            this._estInTerra = true;
        }

        public float VelocitasActualisHorizontal => _velocitasActualisHorizontal;
        public float VelocitasActualisVertical => _velocitasActualisVertical;
        public float RotatioYActualis => _rotatioYActualis;
        public bool EstInTerra => _estInTerra;

        public void Renovare(
            float velocitasActualisHorizontal,
            float velocitasActualisVertical,
            float rotatioYActualis,
            bool estInTerra
        ) {
            _velocitasActualisHorizontal = velocitasActualisHorizontal;
            _velocitasActualisVertical = velocitasActualisVertical;
            _rotatioYActualis = rotatioYActualis;
            _estInTerra = estInTerra;
        }
    }

    internal interface IResFuluidaMotusLegibile {
        float VelocitasActualisHorizontal { get; }
        float VelocitasActualisVertical { get; }
        float RotatioYActualis { get; }
        bool EstInTerra { get; }
    }

    internal sealed class ResFuluidaMotusLegibile : IResFuluidaMotusLegibile {
        private readonly ResFuluidaMotus _resFuluidaMotus;

        public ResFuluidaMotusLegibile(ResFuluidaMotus resFuluidaMotus) {
            _resFuluidaMotus = resFuluidaMotus;
        }

        public float VelocitasActualisHorizontal => _resFuluidaMotus.VelocitasActualisHorizontal;
        public float VelocitasActualisVertical => _resFuluidaMotus.VelocitasActualisVertical;
        public float RotatioYActualis => _resFuluidaMotus.RotatioYActualis;
        public bool EstInTerra => _resFuluidaMotus.EstInTerra;
    }
}
