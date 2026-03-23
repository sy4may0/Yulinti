using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResFluidaPuellaeVeletudinis : IResFluidaPuellaeVeletudinisLegibile {
        // health
        private float _vigor;
        private bool _estExhauritaVigoris;

        // stamina
        private float _patientia;
        private bool _estExhauritaPatientiae;

        // visibility(0~1)
        private float _claritas;
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
            this._vigor = 1f;
            this._patientia = 1f;
            this._claritas = 1f;
            this._aether = 0f;
            this._intentio = 0f;
            this._dedecus = 0f;
        }

        public float Vigor => _vigor;
        public bool EstExhauritaVigoris => _estExhauritaVigoris;
        public float Patientia => _patientia;
        public bool EstExhauritaPatientiae => _estExhauritaPatientiae;
        public float Claritas => _claritas;
        public float Aether => _aether;
        public float Intentio => _intentio;
        public float Dedecus => _dedecus;
        public bool EstNudusAnterior => _estNudusAnterior;
        public bool EstNudusPosterior => _estNudusPosterior;
        public float SonusQuietes => _sonusQuietes;
        public float SonusMotus => _sonusMotus;

        public void RenovareValoris(
            float vigor,
            float patientia,
            float claritas,
            float aether,
            float intentio,
            float dedecus,
            float sonusQuietes,
            float sonusMotus
        ) {
            _vigor = Mathematica.Clamp01(vigor);
            _patientia = Mathematica.Clamp01(patientia);
            _claritas = Mathematica.Clamp01(claritas);
            _aether = Mathematica.Clamp01(aether);
            _intentio = Mathematica.Clamp01(intentio);
            _dedecus = Mathematica.Clamp01(dedecus);
            _sonusQuietes = Mathematica.Clamp01(sonusQuietes);
            _sonusMotus = Mathematica.Clamp01(sonusMotus);
        }

        public void RenovareNudusAnterior(bool estNudusAnterior) {
            _estNudusAnterior = estNudusAnterior;
        }
        public void RenovareNudusPosterior(bool estNudusPosterior) {
            _estNudusPosterior = estNudusPosterior;
        }

        public void ResolvereExhauritaVigoris(
            float LimenExhauritaVigoris,
            float LimenRefectaVigoris,
            float VigorMaxima
        ) {
            float limenEx = VigorMaxima * LimenExhauritaVigoris;
            if (!_estExhauritaVigoris && _vigor <= limenEx) {
                _estExhauritaVigoris = true;
            }

            float limenRe = VigorMaxima * LimenRefectaVigoris;
            if (_estExhauritaVigoris && _vigor >= limenRe) {
                _estExhauritaVigoris = false;
            }
        }

        public void ResolvereExhauritaPatientiae(
            float LimenExhauritaPatientiae,
            float LimenRefectaPatientiae,
            float PatientiaMaxima
        ) {
            float limenEx = PatientiaMaxima * LimenExhauritaPatientiae;
            if (!_estExhauritaPatientiae && _patientia <= limenEx) {
                _estExhauritaPatientiae = true;
            }

            float limenRe = PatientiaMaxima * LimenRefectaPatientiae;
            if (_estExhauritaPatientiae && _patientia >= limenRe) {
                _estExhauritaPatientiae = false;
            }
        }

        public void Purgare() {
            _vigor = 1f;
            _patientia = 1f;
            _claritas = 0f;
            _aether = 0f;
            _intentio = 0f;
            _dedecus = 0f;
            _sonusQuietes = 0f;
            _sonusMotus = 0f;
        }
    }
}
