using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaCivisMotus : IResFluidaCivisMotusLegibile {
        private float[] _velocitasActualisHorizontalis;
        private float[] _velocitasActualisVerticalis;
        private float[] _rotatioYActualis;
        private bool[] _estInTerra;

        public ResFluidaCivisMotus(IOstiumCivisLegibile ostiumCivis) {
            _velocitasActualisHorizontalis = new float[ostiumCivis.Longitudo];
            _velocitasActualisVerticalis = new float[ostiumCivis.Longitudo];
            _rotatioYActualis = new float[ostiumCivis.Longitudo];
            _estInTerra = new bool[ostiumCivis.Longitudo];
            for (int i = 0; i < ostiumCivis.Longitudo; i++) {
                _estInTerra[i] = true;
            }
        }

        public int Longitudo => _velocitasActualisHorizontalis.Length;

        public float VelocitasActualisHorizontalis(int idCivis) {
            if (idCivis < 0 || idCivis >= _velocitasActualisHorizontalis.Length) return 0f;
            return _velocitasActualisHorizontalis[idCivis];
        }
        public float VelocitasActualisVerticalis(int idCivis) {
            if (idCivis < 0 || idCivis >= _velocitasActualisVerticalis.Length) return 0f;
            return _velocitasActualisVerticalis[idCivis];
        }
        public float RotatioYActualis(int idCivis) {
            if (idCivis < 0 || idCivis >= _rotatioYActualis.Length) return 0f;
            return _rotatioYActualis[idCivis];
        }
        public bool EstInTerra(int idCivis) {
            if (idCivis < 0 || idCivis >= _estInTerra.Length) return false;
            return _estInTerra[idCivis];
        }

        public void RenovareVelocitasActualisHorizontalis(int idCivis, float velocitasActualisHorizontalis) {
            if (idCivis < 0 || idCivis >= _velocitasActualisHorizontalis.Length) return;
            _velocitasActualisHorizontalis[idCivis] = velocitasActualisHorizontalis;
        }
        public void RenovareVelocitasActualisVerticalis(int idCivis, float velocitasActualisVerticalis) {
            if (idCivis < 0 || idCivis >= _velocitasActualisVerticalis.Length) return;
            _velocitasActualisVerticalis[idCivis] = velocitasActualisVerticalis;
        }
        public void RenovareRotatioYActualis(int idCivis, float rotatioYActualis) {
            if (idCivis < 0 || idCivis >= _rotatioYActualis.Length) return;
            _rotatioYActualis[idCivis] = rotatioYActualis;
        }
        public void RenovareEstInTerra(int idCivis, bool estInTerra) {
            if (idCivis < 0 || idCivis >= _estInTerra.Length) return;
            _estInTerra[idCivis] = estInTerra;
        }

        public void Renovare(int idCivis, float velocitasActualisHorizontalis, float velocitasActualisVerticalis, float rotatioYActualis, bool estInTerra) {
            if (idCivis < 0 || idCivis >= _estInTerra.Length) return;
            _velocitasActualisHorizontalis[idCivis] = velocitasActualisHorizontalis;
            _velocitasActualisVerticalis[idCivis] = velocitasActualisVerticalis;
            _rotatioYActualis[idCivis] = rotatioYActualis;
            _estInTerra[idCivis] = estInTerra;
        }

        public void Purgare(int idCivis) {
            if (idCivis < 0 || idCivis >= _estInTerra.Length) return;
            _velocitasActualisHorizontalis[idCivis] = 0f;
            _velocitasActualisVerticalis[idCivis] = 0f;
            _rotatioYActualis[idCivis] = 0f;
            _estInTerra[idCivis] = true;
        }
    }
}