using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaCivisVeletudinis : IResFluidaCivisVeletudinisLegibile {
        private int[] _vitae;
        private bool[] _estDominare;

        public ResFluidaCivisVeletudinis(IOstiumCivisLegibile ostiumCivis) {
            _vitae = new int[ostiumCivis.Longitudo];
            _estDominare = new bool[ostiumCivis.Longitudo];
            for (int i = 0; i < ostiumCivis.Longitudo; i++) {
                _vitae[i] = 100;
                _estDominare[i] = false;
            }
        }

        public int Longitudo => _vitae.Length;

        private bool estActivum(int idCivis) {
            if (idCivis < 0 || idCivis >= _estDominare.Length) return false;
            return _estDominare[idCivis];
        }

        public int Vitae(int idCivis) {
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
        public void RenovareVitae(int idCivis, int vitae) {
            if (!estActivum(idCivis)) return;
            _vitae[idCivis] = vitae;
        }
        public void Dominare(int idCivis) {
            if (idCivis < 0 || idCivis >= _estDominare.Length) return;
            if (_estDominare[idCivis]) return;
            _vitae[idCivis] = 100;
            _estDominare[idCivis] = true;
        }
        public void Liberare(int idCivis) {
            if (!estActivum(idCivis)) return;
            _vitae[idCivis] = 100;
            _estDominare[idCivis] = false;
        }
    }
}