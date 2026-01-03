using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaCivisVeletudinis : IResFluidaCivisVeletudinisLegibile {
        private float[] _vitae;
        private bool[] _estDominare;
        // モーション適用有無 StateMachineから捕縛される前までfalse
        private bool[] _estMotus;

        public ResFluidaCivisVeletudinis(IOstiumCivisLegibile ostiumCivis) {
            _vitae = new float[ostiumCivis.Longitudo];
            _estDominare = new bool[ostiumCivis.Longitudo];
            _estMotus = new bool[ostiumCivis.Longitudo];
            for (int i = 0; i < ostiumCivis.Longitudo; i++) {
                _vitae[i] = 100;
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

        public void RenovareVitae(int idCivis, float vitae) {
            if (!estActivum(idCivis)) return;
            _vitae[idCivis] = vitae;
        }
        public void Dominare(int idCivis) {
            if (idCivis < 0 || idCivis >= _estDominare.Length) return;
            if (_estDominare[idCivis]) return;
            _vitae[idCivis] = 100;
            _estDominare[idCivis] = true;
            _estMotus[idCivis] = false;
        }
        public void Liberare(int idCivis) {
            if (!estActivum(idCivis)) return;
            _vitae[idCivis] = 100;
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