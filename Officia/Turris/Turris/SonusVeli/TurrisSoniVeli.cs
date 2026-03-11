using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System.Collections.Generic;

namespace Yulinti.Officia.Turris {
    public class TurrisSoniVeli : ITurrisSoniVeli, ITurrisPulsabilisTardus {
        private readonly IAnchoraSoniVeli _anchoraSoniVeli;
        private readonly TabulaSoniVeli _tabulaSoniVeli;

        private readonly Ordo<SonusVeli> _ordoSoniVeli;
        private readonly List<SonusVeli> _sonusTemporarius;

        public TurrisSoniVeli(IAnchoraSoniVeli anchoraSoniVeli, IConfiguratioSonorumVeli configuratioSonorumVeli) {
            _anchoraSoniVeli = anchoraSoniVeli;
            _tabulaSoniVeli = new TabulaSoniVeli(configuratioSonorumVeli);
            _ordoSoniVeli = new Ordo<SonusVeli>(configuratioSonorumVeli.NumerusSonorumVeliMaxima);
            _sonusTemporarius = new List<SonusVeli>(configuratioSonorumVeli.NumerusSonorumVeliMaxima);
        }

        public void Sonare(IDSonusVeli idSonusVeli) {
            if (!_tabulaSoniVeli.ConareLego(idSonusVeli, out SonusVeli sonusVeli)) return;
            if (!_ordoSoniVeli.ConarePono(sonusVeli)) return;
        }

        public void PulsusTardus() {
            //Temporariusを初期化。
            _sonusTemporarius.Clear();

            // キューからSonusVeliを取得し、Temporariusに格納。ついでに最大Prioritasを算出。
            int prioritasMaxima = int.MinValue;
            while (_ordoSoniVeli.ConareLego(out SonusVeli sonusVeli)) {
                if (!sonusVeli.EstSonarabilis()) continue;
                if (sonusVeli.Prioritas() > prioritasMaxima) {
                    prioritasMaxima = sonusVeli.Prioritas();
                }
                _sonusTemporarius.Add(sonusVeli);
            }

            // 最大Prioritasのものだけ再生。
            foreach (SonusVeli sonusVeli in _sonusTemporarius) {
                if (sonusVeli.Prioritas() == prioritasMaxima) {
                    sonusVeli.Sonare(_anchoraSoniVeli.FonsSoniVeli);
                }
            }

            // 念のため。
            _ordoSoniVeli.Purgere();
            _sonusTemporarius.Clear();
        }
    }
}