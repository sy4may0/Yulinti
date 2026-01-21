using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaCivisVeletudinis : IResFluidaCivisVeletudinisLegibile {
        private float[] _vitae;
        private bool[] _estDominare;

        // 視力(0~1)
        private float[] _visus;
        // Puellae視認度 (0~1)
        private float[] _visa;
        // 聞き耳
        private float[] _audita;
        // 疑心度
        private float[] _suspecta;

        private bool _estSpectareNudusAnterior;
        private bool _estSpectareNudusPosterior;

        // 警戒フラグ
        private bool[] _estVigilantia;
        // 検知フラグ
        private bool[] _estDetectio;

        public ResFluidaCivisVeletudinis(IOstiumCivisLegibile ostiumCivis) {
            _vitae = new float[ostiumCivis.Longitudo];
            _visus = new float[ostiumCivis.Longitudo];
            _visa = new float[ostiumCivis.Longitudo];
            _audita = new float[ostiumCivis.Longitudo];
            _suspecta = new float[ostiumCivis.Longitudo];

            _estDominare = new bool[ostiumCivis.Longitudo];
            _estVigilantia = new bool[ostiumCivis.Longitudo];
            _estDetectio = new bool[ostiumCivis.Longitudo];

            _estSpectareNudusAnterior = false;
            _estSpectareNudusPosterior = false;
 
            for (int i = 0; i < ostiumCivis.Longitudo; i++) {
                _vitae[i] = 1f;
                _visus[i] = 1f;
                _visa[i] = 0f;
                _audita[i] = 0f;
                _suspecta[i] = 0f;
                _estDominare[i] = false;
                _estSpectareNudusAnterior = false;
                _estSpectareNudusPosterior = false;
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
        public float Audita(int idCivis) {
            if (!estActivum(idCivis)) return 0f;
            return _audita[idCivis];
        }
        public float Suspecta(int idCivis) {
            if (!estActivum(idCivis)) return 0f;
            return _suspecta[idCivis];
        }

        public bool EstDominare(int idCivis) {
            return estActivum(idCivis);
        }
        public bool EstExhaurita(int idCivis) {
            if (!estActivum(idCivis)) return false;
            return _vitae[idCivis] <= 0;
        }
        public bool EstVigilantia(int idCivis) {
            if (!estActivum(idCivis)) return false;
            return _estVigilantia[idCivis];
        }
        public bool EstDetectio(int idCivis) {
            if (!estActivum(idCivis)) return false;
            return _estDetectio[idCivis];
        }

        public bool EstSpectareNudusAnterior(int idCivis) {
            if (!estActivum(idCivis)) return false;
            return _estSpectareNudusAnterior;
        }
        public bool EstSpectareNudusPosterior(int idCivis) {
            if (!estActivum(idCivis)) return false;
            return _estSpectareNudusPosterior;
        }
        public bool EstSpectareNudus(int idCivis) {
            if (!estActivum(idCivis)) return false;
            return _estSpectareNudusAnterior || _estSpectareNudusPosterior;
        }

        public void RenovareCondicionis(
            int idCivis,
            bool? estVigilantia = null,
            bool? estDetectio = null,
            bool? estSpectareNudusAnterior = null,
            bool? estSpectareNudusPosterior = null
        ) {
            if (!estActivum(idCivis)) return;
            if (estVigilantia != null) _estVigilantia[idCivis] = estVigilantia.Value;
            if (estDetectio != null) _estDetectio[idCivis] = estDetectio.Value;
            if (estSpectareNudusAnterior != null) _estSpectareNudusAnterior = estSpectareNudusAnterior.Value;
            if (estSpectareNudusPosterior != null) _estSpectareNudusPosterior = estSpectareNudusPosterior.Value;
        }

        public void RenovareValoris(
            int idCivis,
            float vitae,
            float visus,
            float visa,
            float audita,
            float suspecta
        ) {
            if (!estActivum(idCivis)) return;
            _vitae[idCivis] = DuxMath.Clamp(vitae, 0f, 1f);
            _visus[idCivis] = DuxMath.Clamp(visus, 0f, 1f);
            _visa[idCivis] = DuxMath.Clamp(visa, 0f, 1f);
            _audita[idCivis] = DuxMath.Clamp(audita, 0f, 1f);
            _suspecta[idCivis] = DuxMath.Clamp(suspecta, 0f, 1f);
        }

        public void Purgare(int idCivis) {
            _vitae[idCivis] = 1f;
            _visus[idCivis] = 1f;
            _visa[idCivis] = 0f;
            _audita[idCivis] = 0f;
            _suspecta[idCivis] = 0f;
            _estVigilantia[idCivis] = false;
            _estDetectio[idCivis] = false;
            _estSpectareNudusAnterior = false;
            _estSpectareNudusPosterior = false;
        }

        public void Dominare(int idCivis) {
            if (idCivis < 0 || idCivis >= _estDominare.Length) return;
            if (_estDominare[idCivis]) return;
            Purgare(idCivis);
            _estDominare[idCivis] = true;
        }
        public void Liberare(int idCivis) {
            if (!estActivum(idCivis)) return;
            Purgare(idCivis);
            _estDominare[idCivis] = false;
        }
    }
}
