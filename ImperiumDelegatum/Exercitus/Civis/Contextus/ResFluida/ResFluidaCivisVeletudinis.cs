using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResFluidaCivisVeletudinis : IResFluidaCivisVeletudinisLegibile {
        // maxima
        private float[] _vitaeMaxima;
        private float[] _visusMaxima;
        private float[] _visaMaxima;
        private float[] _auditusMaxima;
        private float[] _auditaMaxima;
        private float[] _suspectaMaxima;
        private float[] _studiumMaxima;
        private float[] _intentioMaxima;
        private float[] _torelantiaAnomaliaeMaximaMaxima;
        private float[] _torelantiaAnomaliaeMinimaMaxima;

        // health
        private float[] _vitae;

        // 視力
        private float[] _visus;
        // Puellae視認度
        private float[] _visa;
        // 聴力
        private float[] _auditus;
        // 聞き耳
        private float[] _audita;
        // 疑心度
        private float[] _suspecta;
        // 興味度
        private float[] _studium;
        // 緊張度(0~1)
        private float[] _intentio;
        // 異常耐性上限(0~1)
        private float[] _torelantiaAnomaliaeMaxima;
        // 異常耐性下限(0~1)
        private float[] _torelantiaAnomaliaeMinima;

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
            int longitudo = ostiumCivis.Longitudo;

            _vitaeMaxima = new float[longitudo];
            _visusMaxima = new float[longitudo];
            _visaMaxima = new float[longitudo];
            _auditusMaxima = new float[longitudo];
            _auditaMaxima = new float[longitudo];
            _suspectaMaxima = new float[longitudo];
            _studiumMaxima = new float[longitudo];
            _intentioMaxima = new float[longitudo];
            _torelantiaAnomaliaeMaximaMaxima = new float[longitudo];
            _torelantiaAnomaliaeMinimaMaxima = new float[longitudo];

            _vitae = new float[longitudo];
            _visus = new float[longitudo];
            _visa = new float[longitudo];
            _auditus = new float[longitudo];
            _audita = new float[longitudo];
            _suspecta = new float[longitudo];
            _studium = new float[longitudo];
            _intentio = new float[longitudo];
            _torelantiaAnomaliaeMaxima = new float[longitudo];
            _torelantiaAnomaliaeMinima = new float[longitudo];

            _estVigilantia = new bool[longitudo];
            _estDetectio = new bool[longitudo];
            _estDetectioSonora = new bool[longitudo];
            _estSuspecta = new bool[longitudo];

            _estSpectareNudusAnterior = false;
            _estSpectareNudusPosterior = false;

            for (int i = 0; i < longitudo; i++) {
                InitareCivis(i);
            }
        }

        private void InitareCivis(int idCivis) {
            _vitaeMaxima[idCivis] = CivisVeletudinis.VitaeMaximaBasis;
            _visusMaxima[idCivis] = CivisVeletudinis.VisusMaximaBasis;
            _visaMaxima[idCivis] = CivisVeletudinis.VisaMaximaBasis;
            _auditusMaxima[idCivis] = CivisVeletudinis.AuditusMaximaBasis;
            _auditaMaxima[idCivis] = CivisVeletudinis.AuditaMaximaBasis;
            _suspectaMaxima[idCivis] = CivisVeletudinis.SuspectaMaximaBasis;
            _studiumMaxima[idCivis] = CivisVeletudinis.StudiumMaximaBasis;
            _intentioMaxima[idCivis] = CivisVeletudinis.IntentioMaximaBasis;
            _torelantiaAnomaliaeMaximaMaxima[idCivis] = CivisVeletudinis.TorelantiaAnomaliaeMaximaMaximaBasis;
            _torelantiaAnomaliaeMinimaMaxima[idCivis] = CivisVeletudinis.TorelantiaAnomaliaeMinimaMaximaBasis;

            _vitae[idCivis] = _vitaeMaxima[idCivis];
            _visus[idCivis] = _visusMaxima[idCivis];
            _visa[idCivis] = 0f;
            _auditus[idCivis] = _auditusMaxima[idCivis];
            _audita[idCivis] = 0f;
            _suspecta[idCivis] = 0f;
            _studium[idCivis] = 0f;
            _intentio[idCivis] = 0f;
            _torelantiaAnomaliaeMaxima[idCivis] = 0f;
            _torelantiaAnomaliaeMinima[idCivis] = 0f;

            _estVigilantia[idCivis] = false;
            _estDetectio[idCivis] = false;
            _estDetectioSonora[idCivis] = false;
            _estSuspecta[idCivis] = false;
            _estSpectareNudusAnterior = false;
            _estSpectareNudusPosterior = false;
        }

        public int Longitudo => _vitae.Length;

        public float VitaeMaxima(int idCivis) => _vitaeMaxima[idCivis];
        public float VisusMaxima(int idCivis) => _visusMaxima[idCivis];
        public float VisaMaxima(int idCivis) => _visaMaxima[idCivis];
        public float AuditusMaxima(int idCivis) => _auditusMaxima[idCivis];
        public float AuditaMaxima(int idCivis) => _auditaMaxima[idCivis];
        public float SuspectaMaxima(int idCivis) => _suspectaMaxima[idCivis];
        public float StudiumMaxima(int idCivis) => _studiumMaxima[idCivis];
        public float IntentioMaxima(int idCivis) => _intentioMaxima[idCivis];
        public float TorelantiaAnomaliaeMaximaMaxima(int idCivis) => _torelantiaAnomaliaeMaximaMaxima[idCivis];
        public float TorelantiaAnomaliaeMinimaMaxima(int idCivis) => _torelantiaAnomaliaeMinimaMaxima[idCivis];

        public float Vitae(int idCivis) => _vitae[idCivis];
        public float Visus(int idCivis) => _visus[idCivis];
        public float Visa(int idCivis) => _visa[idCivis];
        public float Auditus(int idCivis) => _auditus[idCivis];
        public float Audita(int idCivis) => _audita[idCivis];
        public float Suspecta(int idCivis) => _suspecta[idCivis];
        public float Studium(int idCivis) => _studium[idCivis];
        public float Intentio(int idCivis) => _intentio[idCivis];
        public float TorelantiaAnomaliaeMaxima(int idCivis) => _torelantiaAnomaliaeMaxima[idCivis];
        public float TorelantiaAnomaliaeMinima(int idCivis) => _torelantiaAnomaliaeMinima[idCivis];

        public float RatioVitae(int idCivis) => Mathematica.Clamp01(_vitae[idCivis] / _vitaeMaxima[idCivis]);
        public float RatioVisus(int idCivis) => Mathematica.Clamp01(_visus[idCivis] / _visusMaxima[idCivis]);
        public float RatioVisa(int idCivis) => Mathematica.Clamp01(_visa[idCivis] / _visaMaxima[idCivis]);
        public float RatioAuditus(int idCivis) => Mathematica.Clamp01(_auditus[idCivis] / _auditusMaxima[idCivis]);
        public float RatioAudita(int idCivis) => Mathematica.Clamp01(_audita[idCivis] / _auditaMaxima[idCivis]);
        public float RatioSuspecta(int idCivis) => Mathematica.Clamp01(_suspecta[idCivis] / _suspectaMaxima[idCivis]);
        public float RatioStudium(int idCivis) => Mathematica.Clamp01(_studium[idCivis] / _studiumMaxima[idCivis]);
        public float RatioIntentionis(int idCivis) => Mathematica.Clamp01(_intentio[idCivis] / _intentioMaxima[idCivis]);
        public float RatioTorelantiaAnomaliaeMaxima(int idCivis) => Mathematica.Clamp01(_torelantiaAnomaliaeMaxima[idCivis] / _torelantiaAnomaliaeMaximaMaxima[idCivis]);
        public float RatioTorelantiaAnomaliaeMinima(int idCivis) => Mathematica.Clamp01(_torelantiaAnomaliaeMinima[idCivis] / _torelantiaAnomaliaeMinimaMaxima[idCivis]);

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
            float suspecta,
            float studium,
            float intentio,
            float torelantiaAnomaliaeMaxima,
            float torelantiaAnomaliaeMinima
        ) {
            _vitae[idCivis] = Mathematica.Clamp(vitae, 0f, _vitaeMaxima[idCivis]);
            _visus[idCivis] = Mathematica.Clamp(visus, 0f, _visusMaxima[idCivis]);
            _visa[idCivis] = Mathematica.Clamp(visa, 0f, _visaMaxima[idCivis]);
            _auditus[idCivis] = Mathematica.Clamp(auditus, 0f, _auditusMaxima[idCivis]);
            _audita[idCivis] = Mathematica.Clamp(audita, 0f, _auditaMaxima[idCivis]);
            _suspecta[idCivis] = Mathematica.Clamp(suspecta, 0f, _suspectaMaxima[idCivis]);
            _studium[idCivis] = Mathematica.Clamp(studium, 0f, _studiumMaxima[idCivis]);
            _intentio[idCivis] = Mathematica.Clamp(intentio, 0f, _intentioMaxima[idCivis]);
            _torelantiaAnomaliaeMaxima[idCivis] = Mathematica.Clamp(torelantiaAnomaliaeMaxima, 0f, _torelantiaAnomaliaeMaximaMaxima[idCivis]);
            _torelantiaAnomaliaeMinima[idCivis] = Mathematica.Clamp(torelantiaAnomaliaeMinima, 0f, _torelantiaAnomaliaeMinimaMaxima[idCivis]);

            if (_torelantiaAnomaliaeMinima[idCivis] > _torelantiaAnomaliaeMaxima[idCivis]) {
                _torelantiaAnomaliaeMinima[idCivis] = _torelantiaAnomaliaeMaxima[idCivis];
            }
        }

        public void RenovareMaxima(
            int idCivis,
            float vitaeMaxima,
            float visusMaxima,
            float visaMaxima,
            float auditusMaxima,
            float auditaMaxima,
            float suspectaMaxima,
            float studiumMaxima,
            float intentioMaxima,
            float torelantiaAnomaliaeMaximaMaxima,
            float torelantiaAnomaliaeMinimaMaxima
        ) {
            _vitaeMaxima[idCivis] = vitaeMaxima;
            _visusMaxima[idCivis] = visusMaxima;
            _visaMaxima[idCivis] = visaMaxima;
            _auditusMaxima[idCivis] = auditusMaxima;
            _auditaMaxima[idCivis] = auditaMaxima;
            _suspectaMaxima[idCivis] = suspectaMaxima;
            _studiumMaxima[idCivis] = studiumMaxima;
            _intentioMaxima[idCivis] = intentioMaxima;
            _torelantiaAnomaliaeMaximaMaxima[idCivis] = torelantiaAnomaliaeMaximaMaxima;
            _torelantiaAnomaliaeMinimaMaxima[idCivis] = torelantiaAnomaliaeMinimaMaxima;
        }

        public void Purgare(int idCivis) {
            InitareCivis(idCivis);
        }
    }
}
