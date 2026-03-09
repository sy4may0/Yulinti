using System;
using Yulinti.Unity.Contractus;
using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Turris {
    public class TabulaSoniVeli {
        private readonly SonusVeli[] _sonorumVeli;

        public TabulaSoniVeli(IConfiguratioSonorumVeli configuratioSonorumVeli) {
            int longitudo = Enum.GetValues(typeof(IDSonusVeli)).Length;
            _sonorumVeli = new SonusVeli[longitudo];
            for (int i = 0; i < longitudo; i++) {
                IConfiguratioSoniVeli configuratioSoniVeli = configuratioSonorumVeli.SonorumVeli[i];
                _sonorumVeli[i] = new SonusVeli(configuratioSoniVeli);
            }

            for (int i = 0; i < longitudo; i++) {
                if ((int)IDSonusVeli.Nihil == i) continue;
                if (_sonorumVeli[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaSoniVeli_TABULASONIVELI_SONUS_NOT_FOUND);
                }
            }
        }

        public bool ConareLego(IDSonusVeli idSonusVeli, out SonusVeli sonusVeli) {
            sonusVeli = _sonorumVeli[(int)idSonusVeli];
            if (sonusVeli == null) {
                return false;
            }
            return true;
        }
    }
}