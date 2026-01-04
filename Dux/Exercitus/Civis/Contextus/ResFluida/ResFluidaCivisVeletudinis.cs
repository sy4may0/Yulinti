using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaCivisVeletudinis : IResFluidaCivisVeletudinisLegibile {
        private float[] _vitae;
        private bool[] _estDominare;
        // モーション適用有無 StateMachineから捕縛される前までfalse
        private bool[] _estMotus;

        // 視力(0~100%)
        private float[] _visus;
        // Puellae視認度 (0~100)
        private float[] _visa;

        // 警戒フラグ
        private bool[] _estVigilantia;
        // 検知フラグ
        private bool[] _estDetectio;

        public ResFluidaCivisVeletudinis(IOstiumCivisLegibile ostiumCivis) {
            _vitae = new float[ostiumCivis.Longitudo];
            _visus = new float[ostiumCivis.Longitudo];
            _visa = new float[ostiumCivis.Longitudo];

            _estDominare = new bool[ostiumCivis.Longitudo];
            _estMotus = new bool[ostiumCivis.Longitudo];
            _estVigilantia = new bool[ostiumCivis.Longitudo];
            _estDetectio = new bool[ostiumCivis.Longitudo];
 
            for (int i = 0; i < ostiumCivis.Longitudo; i++) {
                _vitae[i] = 100f;
                _visus[i] = 100f;
                _visa[i] = 0f;
                _estDominare[i] = false;
                _estMotus[i] = false;
            }
        }

        public int Longitudo => _vitae.Length;

        private bool estActivum(int idCivis) {
            if (idCivis < 0 || idCivis >= _estDominare.Length) return false;
            return _estDominare[idCivis];
        }

        public float Vitae(int idCivis) {
            if (!estActivum(idCivis)) return 0;
            return _vitae[idCivis];
        }
        public float Visus(int idCivis) {
            if (!estActivum(idCivis)) return 0f;
            return _visus[idCivis];
        }
        public float Visa(int idCivis) {
            if (!estActivum(idCivis)) return 0f;
            return _visa[idCivis];
        }

        public bool EstDominare(int idCivis) {
            return estActivum(idCivis);
        }
        public bool EstExhaurita(int idCivis) {
            if (!estActivum(idCivis)) return false;
            return _vitae[idCivis] <= 0;
        }
        public bool EstMotus(int idCivis) {
            if (!estActivum(idCivis)) return false;
            return _estMotus[idCivis];
        }
        public bool EstVigilantia(int idCivis) {
            if (!estActivum(idCivis)) return false;
            return _estVigilantia[idCivis];
        }
        public bool EstDetectio(int idCivis) {
            if (!estActivum(idCivis)) return false;
            return _estDetectio[idCivis];
        }

        public void RenovareVitae(int idCivis, float vitae) {
            if (!estActivum(idCivis)) return;
            _vitae[idCivis] = DuxMath.Clamp(vitae, 0f, 100f);
        }

        public void RenovareVisa(int idCivis, float visa) {
            if (!estActivum(idCivis)) return;
            _visa[idCivis] = DuxMath.Clamp(visa, 0f, 100f);
        }

        public void RenovareVigilantia(int idCivis, bool estVigilantia) {
            if (!estActivum(idCivis)) return;
            _estVigilantia[idCivis] = estVigilantia;
        }
        public void RenovareDetectio(int idCivis, bool estDetectio) {
            if (!estActivum(idCivis)) return;
            _estDetectio[idCivis] = estDetectio;
        }

        public void Dominare(int idCivis) {
            if (idCivis < 0 || idCivis >= _estDominare.Length) return;
            if (_estDominare[idCivis]) return;
            _vitae[idCivis] = 100;
            _visus[idCivis] = 100;
            _visa[idCivis] = 0f;
            _estDominare[idCivis] = true;
            _estMotus[idCivis] = false;
        }
        public void Liberare(int idCivis) {
            if (!estActivum(idCivis)) return;
            _vitae[idCivis] = 100;
            _visus[idCivis] = 100;
            _visa[idCivis] = 0f;
            _estDominare[idCivis] = false;
            _estMotus[idCivis] = false;
        }

        public void ServereMotus(int idCivis) {
            if (!estActivum(idCivis)) return;
            _estMotus[idCivis] = true;
        }

        public void LiberareServatum(int idCivis) {
            _estMotus[idCivis] = false;
        }
    }
}