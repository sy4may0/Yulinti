using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResFluidaPuellaeVeletudinis : IResFluidaPuellaeVeletudinisLegibile {
        // maxima
        private float _vigorMaxima;
        private float _patientiaMaxima;
        private float _anomaliaMaxima;
        private float _claritasMaxima;
        private float _aetherMaxima;
        private float _intentioMaxima;
        private float _dedecusMaxima;
        private float _sonusQuietesMaxima;
        private float _sonusMotusMaxima;

        // health
        private float _vigor;
        private bool _estExhauritaVigoris;

        // stamina
        private float _patientia;
        private bool _estExhauritaPatientiae;

        // visibility(0~1)
        private float _claritas;
        // irregularity(0~1)
        private float _anomalia;
        // electricity
        private float _aether;
        // voltage
        private float _intentio;
        // shameness
        private float _dedecus;

        // 静止音量
        private float _sonusQuietes;
        // 動作音量(速度で補正)
        private float _sonusMotus;

        // 前面露出
        private bool _estNudusAnterior;
        // 背面露出
        private bool _estNudusPosterior;

        public ResFluidaPuellaeVeletudinis() {
            this._vigorMaxima = PuellaVeletudinis.VigorMaximaBasis;
            this._patientiaMaxima = PuellaVeletudinis.PatientiaMaximaBasis;
            this._claritasMaxima = PuellaVeletudinis.ClaritasMaximaBasis;
            this._anomaliaMaxima = PuellaVeletudinis.AnomaliaMaximaBasis;
            this._aetherMaxima = PuellaVeletudinis.AetherMaximaBasis;
            this._intentioMaxima = PuellaVeletudinis.IntentioMaximaBasis;
            this._dedecusMaxima = PuellaVeletudinis.DedecusMaximaBasis;
            this._sonusQuietesMaxima = PuellaVeletudinis.SonusQuietesMaximaBasis;
            this._sonusMotusMaxima = PuellaVeletudinis.SonusMotusMaximaBasis;

            this._vigor = _vigorMaxima;
            this._patientia = _patientiaMaxima;
            this._aether = 0f;
            this._claritas = 0f;
            this._anomalia = 0f;
            this._intentio = 0f;
            this._dedecus = 0f;
            this._sonusQuietes = 0f;
            this._sonusMotus = 0f;

            this._estNudusAnterior = false;
            this._estNudusPosterior = false;
            this._estExhauritaVigoris = false;
            this._estExhauritaPatientiae = false;
        }

        public float VigorMaxima => _vigorMaxima;
        public float PatientiaMaxima => _patientiaMaxima;
        public float ClaritasMaxima => _claritasMaxima;
        public float AnomaliaMaxima => _anomaliaMaxima;
        public float AetherMaxima => _aetherMaxima;
        public float IntentioMaxima => _intentioMaxima;
        public float DedecusMaxima => _dedecusMaxima;
        public float SonusQuietesMaxima => _sonusQuietesMaxima;
        public float SonusMotusMaxima => _sonusMotusMaxima;

        public float Vigor => _vigor;
        public bool EstExhauritaVigoris => _estExhauritaVigoris;
        public float Patientia => _patientia;
        public bool EstExhauritaPatientiae => _estExhauritaPatientiae;
        public float Claritas => _claritas;
        public float Anomalia => _anomalia;
        public float Aether => _aether;
        public float Intentio => _intentio;
        public float Dedecus => _dedecus;
        public bool EstNudusAnterior => _estNudusAnterior;
        public bool EstNudusPosterior => _estNudusPosterior;
        public float SonusQuietes => _sonusQuietes;
        public float SonusMotus => _sonusMotus;

        public float RatioVigoris => Mathematica.Clamp01(_vigor / _vigorMaxima);
        public float RatioPatientiae => Mathematica.Clamp01(_patientia / _patientiaMaxima);
        public float RatioClaritas => Mathematica.Clamp01(_claritas / _claritasMaxima);
        public float RatioAnomaliae => Mathematica.Clamp01(_anomalia / _anomaliaMaxima);
        public float RatioAether => Mathematica.Clamp01(_aether / _aetherMaxima);
        public float RatioIntentionis => Mathematica.Clamp01(_intentio / _intentioMaxima);
        public float RatioDedecus => Mathematica.Clamp01(_dedecus / _dedecusMaxima);
        public float RatioSonusQuietes => Mathematica.Clamp01(_sonusQuietes / _sonusQuietesMaxima);
        public float RatioSonusMotus => Mathematica.Clamp01(_sonusMotus / _sonusMotusMaxima);

        public void RenovareValoris(
            float vigor,
            float patientia,
            float claritas,
            float anomalia,
            float aether,
            float intentio,
            float dedecus,
            float sonusQuietes,
            float sonusMotus
        ) {
            _vigor = Mathematica.Clamp(vigor, 0f, _vigorMaxima);
            _patientia = Mathematica.Clamp(patientia, 0f, _patientiaMaxima);
            _claritas = Mathematica.Clamp(claritas, 0f, _claritasMaxima);
            _anomalia = Mathematica.Clamp(anomalia, 0f, _anomaliaMaxima);
            _aether = Mathematica.Clamp(aether, 0f, _aetherMaxima);
            _intentio = Mathematica.Clamp(intentio, 0f, _intentioMaxima);
            _dedecus = Mathematica.Clamp(dedecus, 0f, _dedecusMaxima);
            _sonusQuietes = Mathematica.Clamp(sonusQuietes, 0f, _sonusQuietesMaxima);
            _sonusMotus = Mathematica.Clamp(sonusMotus, 0f, _sonusMotusMaxima);
        }

        public void RenovareMaxima(
            float vigorMaxima,
            float patientiaMaxima,
            float claritasMaxima,
            float anomaliaMaxima,
            float aetherMaxima,
            float intentioMaxima,
            float dedecusMaxima,
            float sonusQuietesMaxima,
            float sonusMotusMaxima
        ) {
            _vigorMaxima = vigorMaxima;
            _patientiaMaxima = patientiaMaxima;
            _claritasMaxima = claritasMaxima;
            _anomaliaMaxima = anomaliaMaxima;
            _aetherMaxima = aetherMaxima;
            _intentioMaxima = intentioMaxima;
            _dedecusMaxima = dedecusMaxima;
            _sonusQuietesMaxima = sonusQuietesMaxima;
            _sonusMotusMaxima = sonusMotusMaxima;
        }

        public void RenovareNudusAnterior(bool estNudusAnterior) {
            _estNudusAnterior = estNudusAnterior;
        }
        public void RenovareNudusPosterior(bool estNudusPosterior) {
            _estNudusPosterior = estNudusPosterior;
        }

        public void ResolvereExhauritaVigoris(
            float LimenExhauritaVigoris,
            float LimenRefectaVigoris
        ) {
            float limenEx = _vigorMaxima * LimenExhauritaVigoris;
            if (!_estExhauritaVigoris && _vigor <= limenEx) {
                _estExhauritaVigoris = true;
            }

            float limenRe = _vigorMaxima * LimenRefectaVigoris;
            if (_estExhauritaVigoris && _vigor >= limenRe) {
                _estExhauritaVigoris = false;
            }
        }

        public void ResolvereExhauritaPatientiae(
            float LimenExhauritaPatientiae,
            float LimenRefectaPatientiae
        ) {
            float limenEx = _patientiaMaxima * LimenExhauritaPatientiae;
            if (!_estExhauritaPatientiae && _patientia <= limenEx) {
                _estExhauritaPatientiae = true;
            }

            float limenRe = _patientiaMaxima * LimenRefectaPatientiae;
            if (_estExhauritaPatientiae && _patientia >= limenRe) {
                _estExhauritaPatientiae = false;
            }
        }

        public void Purgare() {
            _vigorMaxima = PuellaVeletudinis.VigorMaximaBasis;
            _patientiaMaxima = PuellaVeletudinis.PatientiaMaximaBasis;
            _claritasMaxima = PuellaVeletudinis.ClaritasMaximaBasis;
            _anomaliaMaxima = PuellaVeletudinis.AnomaliaMaximaBasis;
            _aetherMaxima = PuellaVeletudinis.AetherMaximaBasis;
            _intentioMaxima = PuellaVeletudinis.IntentioMaximaBasis;
            _dedecusMaxima = PuellaVeletudinis.DedecusMaximaBasis;
            _sonusQuietesMaxima = PuellaVeletudinis.SonusQuietesMaximaBasis;
            _sonusMotusMaxima = PuellaVeletudinis.SonusMotusMaximaBasis;

            _vigor = _vigorMaxima;
            _patientia = _patientiaMaxima;
            _aether = 0f;
            _claritas = 0f;
            _anomalia = 0f;
            _intentio = 0f;
            _dedecus = 0f;
            _sonusQuietes = 0f;
            _sonusMotus = 0f;
        }
    }
}
