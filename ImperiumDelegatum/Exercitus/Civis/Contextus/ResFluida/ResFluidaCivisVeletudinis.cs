using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResFluidaCivisVeletudinis : IResFluidaCivisVeletudinisLegibile {
        // maxima
        private float[] _vitaeMaxima;
        private float[] _visusMaxima;
        private float[] _auditusMaxima;
        private float[] _suspectaMaxima;
        private float[] _studiumMaxima;
        private float[] _intentioMaxima;
        private float[] _torelantiaAnomaliaeMaximaMaxima;
        private float[] _torelantiaAnomaliaeMinimaMaxima;

        private IDCivisStatusCustodiae[] _statusCustodiaeCurrens;

        // health
        private float[] _vitae;

        // 視力
        private float[] _visus;
        // 聴力
        private float[] _auditus;
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

        public ResFluidaCivisVeletudinis(IOstiumCivisLegibile ostiumCivis) {
            int longitudo = ostiumCivis.Longitudo;

            _vitaeMaxima = new float[longitudo];
            _visusMaxima = new float[longitudo];
            _auditusMaxima = new float[longitudo];
            _suspectaMaxima = new float[longitudo];
            _studiumMaxima = new float[longitudo];
            _intentioMaxima = new float[longitudo];
            _torelantiaAnomaliaeMaximaMaxima = new float[longitudo];
            _torelantiaAnomaliaeMinimaMaxima = new float[longitudo];

            _statusCustodiaeCurrens = new IDCivisStatusCustodiae[longitudo];

            _vitae = new float[longitudo];
            _visus = new float[longitudo];
            _auditus = new float[longitudo];
            _suspecta = new float[longitudo];
            _studium = new float[longitudo];
            _intentio = new float[longitudo];
            _torelantiaAnomaliaeMaxima = new float[longitudo];
            _torelantiaAnomaliaeMinima = new float[longitudo];

            _estSpectareNudusAnterior = false;
            _estSpectareNudusPosterior = false;

            for (int i = 0; i < longitudo; i++) {
                InitareCivis(i);
            }
        }

        private void InitareCivis(int idCivis) {
            _vitaeMaxima[idCivis] = CivisVeletudinis.VitaeMaximaBasis;
            _visusMaxima[idCivis] = CivisVeletudinis.VisusMaximaBasis;
            _auditusMaxima[idCivis] = CivisVeletudinis.AuditusMaximaBasis;
            _suspectaMaxima[idCivis] = CivisVeletudinis.SuspectaMaximaBasis;
            _studiumMaxima[idCivis] = CivisVeletudinis.StudiumMaximaBasis;
            _intentioMaxima[idCivis] = CivisVeletudinis.IntentioMaximaBasis;
            _torelantiaAnomaliaeMaximaMaxima[idCivis] = CivisVeletudinis.TorelantiaAnomaliaeMaximaMaximaBasis;
            _torelantiaAnomaliaeMinimaMaxima[idCivis] = CivisVeletudinis.TorelantiaAnomaliaeMinimaMaximaBasis;

            _statusCustodiaeCurrens[idCivis] = IDCivisStatusCustodiae.Circumitus;

            _vitae[idCivis] = _vitaeMaxima[idCivis];
            _visus[idCivis] = _visusMaxima[idCivis];
            _auditus[idCivis] = _auditusMaxima[idCivis];
            _suspecta[idCivis] = 0f;
            _studium[idCivis] = 0f;
            _intentio[idCivis] = 0f;
            _torelantiaAnomaliaeMaxima[idCivis] = 0f;
            _torelantiaAnomaliaeMinima[idCivis] = 0f;

            _estSpectareNudusAnterior = false;
            _estSpectareNudusPosterior = false;
        }

        public int Longitudo => _vitae.Length;

        public float VitaeMaxima(int idCivis) => _vitaeMaxima[idCivis];
        public float VisusMaxima(int idCivis) => _visusMaxima[idCivis];
        public float AuditusMaxima(int idCivis) => _auditusMaxima[idCivis];
        public float SuspectaMaxima(int idCivis) => _suspectaMaxima[idCivis];
        public float StudiumMaxima(int idCivis) => _studiumMaxima[idCivis];
        public float IntentioMaxima(int idCivis) => _intentioMaxima[idCivis];
        public float TorelantiaAnomaliaeMaximaMaxima(int idCivis) => _torelantiaAnomaliaeMaximaMaxima[idCivis];
        public float TorelantiaAnomaliaeMinimaMaxima(int idCivis) => _torelantiaAnomaliaeMinimaMaxima[idCivis];

        public IDCivisStatusCustodiae StatusCustodiaeCurrens(int idCivis) => _statusCustodiaeCurrens[idCivis];

        public float Vitae(int idCivis) => _vitae[idCivis];
        public float Visus(int idCivis) => _visus[idCivis];
        public float Auditus(int idCivis) => _auditus[idCivis];
        public float Suspecta(int idCivis) => _suspecta[idCivis];
        public float Studium(int idCivis) => _studium[idCivis];
        public float Intentio(int idCivis) => _intentio[idCivis];
        public float TorelantiaAnomaliaeMaxima(int idCivis) => _torelantiaAnomaliaeMaxima[idCivis];
        public float TorelantiaAnomaliaeMinima(int idCivis) => _torelantiaAnomaliaeMinima[idCivis];

        public float RatioVitae(int idCivis) => Mathematica.Clamp01(_vitae[idCivis] / _vitaeMaxima[idCivis]);
        public float RatioVisus(int idCivis) => Mathematica.Clamp01(_visus[idCivis] / _visusMaxima[idCivis]);
        public float RatioAuditus(int idCivis) => Mathematica.Clamp01(_auditus[idCivis] / _auditusMaxima[idCivis]);
        public float RatioSuspecta(int idCivis) => Mathematica.Clamp01(_suspecta[idCivis] / _suspectaMaxima[idCivis]);
        public float RatioStudium(int idCivis) => Mathematica.Clamp01(_studium[idCivis] / _studiumMaxima[idCivis]);
        public float RatioIntentionis(int idCivis) => Mathematica.Clamp01(_intentio[idCivis] / _intentioMaxima[idCivis]);
        public float RatioTorelantiaAnomaliaeMaxima(int idCivis) => Mathematica.Clamp01(_torelantiaAnomaliaeMaxima[idCivis] / _torelantiaAnomaliaeMaximaMaxima[idCivis]);
        public float RatioTorelantiaAnomaliaeMinima(int idCivis) => Mathematica.Clamp01(_torelantiaAnomaliaeMinima[idCivis] / _torelantiaAnomaliaeMinimaMaxima[idCivis]);

        public bool EstExhaurita(int idCivis) {
            return _vitae[idCivis] <= 0;
        }

        public bool EstVigilantia(int idCivis) {
            return (
                _statusCustodiaeCurrens[idCivis] == IDCivisStatusCustodiae.Vigilantia ||
                _statusCustodiaeCurrens[idCivis] == IDCivisStatusCustodiae.Spectans ||
                _statusCustodiaeCurrens[idCivis] == IDCivisStatusCustodiae.Sequens ||
                _statusCustodiaeCurrens[idCivis] == IDCivisStatusCustodiae.Discedens 
            );
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
            bool? estSpectareNudusAnterior = null,
            bool? estSpectareNudusPosterior = null,
            IDCivisStatusCustodiae? statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil
        ) {
            if (estSpectareNudusAnterior != null) _estSpectareNudusAnterior = estSpectareNudusAnterior.Value;
            if (estSpectareNudusPosterior != null) _estSpectareNudusPosterior = estSpectareNudusPosterior.Value;
            if (statusCustodiaeCurrens != null && statusCustodiaeCurrens.Value != IDCivisStatusCustodiae.Nihil) {
                _statusCustodiaeCurrens[idCivis] = statusCustodiaeCurrens.Value;
            }
        }

        public void RenovareValoris(
            int idCivis,
            float vitae,
            float visus,
            float auditus,
            float suspecta,
            float studium,
            float intentio,
            float torelantiaAnomaliaeMaxima,
            float torelantiaAnomaliaeMinima
        ) {
            _vitae[idCivis] = Mathematica.Clamp(vitae, 0f, _vitaeMaxima[idCivis]);
            _visus[idCivis] = Mathematica.Clamp(visus, 0f, _visusMaxima[idCivis]);
            _auditus[idCivis] = Mathematica.Clamp(auditus, 0f, _auditusMaxima[idCivis]);
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
            float auditusMaxima,
            float suspectaMaxima,
            float studiumMaxima,
            float intentioMaxima,
            float torelantiaAnomaliaeMaximaMaxima,
            float torelantiaAnomaliaeMinimaMaxima
        ) {
            _vitaeMaxima[idCivis] = vitaeMaxima;
            _visusMaxima[idCivis] = visusMaxima;
            _auditusMaxima[idCivis] = auditusMaxima;
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
