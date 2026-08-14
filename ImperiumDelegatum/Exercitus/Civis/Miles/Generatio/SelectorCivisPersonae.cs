using Yulinti.ImperiumDelegatum.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    public sealed class SelectorCivisPersonae {
        private readonly IConfiguratioCivisPersonae[] _configurationes;
        private readonly Random _random;

        private readonly int _pondusTotum;

        public SelectorCivisPersonae(
            IConfiguratioCivisPersonae[] configurationes,
            Random random
        ) {
            _configurationes = configurationes;
            _random = random;
            _pondusTotum = 0;
            foreach (var configuration in _configurationes) {
                _pondusTotum += configuration.PondusGenerationis;
            }
        }

        public IDCivisPersonae Selectare() {
            int pondus = _random.Next(0, _pondusTotum);

            int s = 0;
            foreach (var conf in _configurationes) {
                if (
                    s <= pondus &&
                    s + conf.PondusGenerationis > pondus
                ) {
                    return conf.IDCivisPersonae;
                }
                s += conf.PondusGenerationis;
            }
            return IDCivisPersonae.Nihil;
        }
    }
}