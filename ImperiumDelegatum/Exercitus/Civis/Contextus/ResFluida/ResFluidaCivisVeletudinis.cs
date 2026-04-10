using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResFluidaCivisVeletudinis : IResFluidaCivisVeletudinisLegibile {
        private float[] _vitae;

        // 視力(0~1)
        private float[] _visus;
        // Puellae視認度 (0~1)
        private float[] _visa;
        // 聴力(0~1)
        private float[] _auditus;
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
        // 疑心フラグ
        private bool[] _estSuspecta;
        // 聴認フラグ
        private bool[] _estDetectioSonora;

        public ResFluidaCivisVeletudinis(IOstiumCivisLegibile ostiumCivis) {
            _vitae = new float[ostiumCivis.Longitudo];
            _visus = new float[ostiumCivis.Longitudo];
            _visa = new float[ostiumCivis.Longitudo];
            _auditus = new float[ostiumCivis.Longitudo];
            _audita = new float[ostiumCivis.Longitudo];
            _suspecta = new float[ostiumCivis.Longitudo];

            _estVigilantia = new bool[ostiumCivis.Longitudo];
            _estDetectio = new bool[ostiumCivis.Longitudo];
            _estDetectioSonora = new bool[ostiumCivis.Longitudo];
            _estSuspecta = new bool[ostiumCivis.Longitudo];

            _estSpectareNudusAnterior = false;
            _estSpectareNudusPosterior = false;
 
            for (int i = 0; i < ostiumCivis.Longitudo; i++) {
                _vitae[i] = 1f;
                _visus[i] = 1f;
                _visa[i] = 0f;
                _auditus[i] = 1f;
                _audita[i] = 0f;
                _suspecta[i] = 0f;
                _estVigilantia[i] = false;
                _estDetectio[i] = false;
                _estDetectioSonora[i] = false;
                _estSuspecta[i] = false;
                _estSpectareNudusAnterior = false;
                _estSpectareNudusPosterior = false;
            }
        }

        public int Longitudo => _vitae.Length;

        public float Vitae(int idCivis) {
            return _vitae[idCivis];
        }
        public float Visus(int idCivis) {
            return _visus[idCivis];
        }
        public float Visa(int idCivis) {
            return _visa[idCivis];
        }
        public float Auditus(int idCivis) {
            return _auditus[idCivis];
        }
        public float Audita(int idCivis) {
            return _audita[idCivis];
        }
        public float Suspecta(int idCivis) {
            return _suspecta[idCivis];
        }

        public bool EstExhaurita(int idCivis) {
            return _vitae[idCivis] <= 0;
        }
        public bool EstVigilantia(int idCivis) {
            return _estVigilantia[idCivis];
        }
        public bool EstDetectio(int idCivis) {
            return _estDetectio[idCivis];
        }

        public bool EstDetectioSonora(int idCivis) {
            return _estDetectioSonora[idCivis];
        }
        public bool EstSuspecta(int idCivis) {
            return _estSuspecta[idCivis];
        }

        public bool EstSpectareNudusAnterior(int idCivis) {
            return _estSpectareNudusAnterior;
        }
        public bool EstSpectareNudusPosterior(int idCivis) {
            return _estSpectareNudusPosterior;
        }
        public bool EstSpectareNudus(int idCivis) {
            return _estSpectareNudusAnterior || _estSpectareNudusPosterior;
        }

        public void RenovareCondicionis(
            int idCivis,
            bool? estVigilantia = null,
            bool? estDetectio = null,
            bool? estDetectioSonora = null,
            bool? estSuspecta = null,
            bool? estSpectareNudusAnterior = null,
            bool? estSpectareNudusPosterior = null
        ) {
            if (estVigilantia != null) _estVigilantia[idCivis] = estVigilantia.Value;
            if (estDetectio != null) _estDetectio[idCivis] = estDetectio.Value;
            if (estDetectioSonora != null) _estDetectioSonora[idCivis] = estDetectioSonora.Value;
            if (estSuspecta != null) _estSuspecta[idCivis] = estSuspecta.Value;
            if (estSpectareNudusAnterior != null) _estSpectareNudusAnterior = estSpectareNudusAnterior.Value;
            if (estSpectareNudusPosterior != null) _estSpectareNudusPosterior = estSpectareNudusPosterior.Value;
        }

        public void RenovareValoris(
            int idCivis,
            float vitae,
            float visus,
            float visa,
            float auditus,
            float audita,
            float suspecta
        ) {
            _vitae[idCivis] = Mathematica.Clamp01(vitae);
            _visus[idCivis] = Mathematica.Clamp01(visus);
            _visa[idCivis] = Mathematica.Clamp01(visa);
            _auditus[idCivis] = Mathematica.Clamp01(auditus);
            _audita[idCivis] = Mathematica.Clamp01(audita);
            _suspecta[idCivis] = Mathematica.Clamp01(suspecta);
        }

        public void Purgare(int idCivis) {
            _vitae[idCivis] = 1f;
            _visus[idCivis] = 1f;
            _visa[idCivis] = 0f;
            _auditus[idCivis] = 1f;
            _audita[idCivis] = 0f;
            _suspecta[idCivis] = 0f;
            _estVigilantia[idCivis] = false;
            _estDetectio[idCivis] = false;
            _estSpectareNudusAnterior = false;
            _estSpectareNudusPosterior = false;
        }
    }
}
