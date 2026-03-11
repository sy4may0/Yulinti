using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.Officia.Turris {
    public class SonusVeli {
        private readonly AudioClip _sonus;
        private readonly float _visSoniBasis;
        private readonly float _tempusRefrigerationis;
        private readonly int _prioritas;

        private float _tempusSonareProximum;

        public SonusVeli(IConfiguratioSoniVeli configuratioSoniVeli) {
            _sonus = configuratioSoniVeli.Sonus;
            _visSoniBasis = configuratioSoniVeli.VisSoniBasis;
            _tempusRefrigerationis = configuratioSoniVeli.TempusRefrigerationis;
            _prioritas = configuratioSoniVeli.Prioritas;

            _tempusSonareProximum = 0f;

            if (_sonus == null) {
                Carnifex.Intermissio(LogTextus.SonusVeli_SONUSVELI_SONUS_NULL);
            }
        }

        public bool EstSonarabilis() {
            if (Time.time < _tempusSonareProximum) return false;
            return true;
        }

        public int Prioritas() {
            return _prioritas;
        }

        public void Sonare(AudioSource audioSource) {
            if (!EstSonarabilis()) return;
            audioSource.PlayOneShot(_sonus, _visSoniBasis);
            _tempusSonareProximum = Time.time + _tempusRefrigerationis;
        }
    }
}