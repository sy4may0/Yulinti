using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using System;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class TabulaPuellaeAnimationum {
        private readonly OnusAnimationis[] _animationes;

        public TabulaPuellaeAnimationum(IConfiguratioPuellaeAnimationis[] config) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeAnimationis)).Length;
            _animationes = new OnusAnimationis[longitudo];

            foreach (IConfiguratioPuellaeAnimationis c in config) {
                if (c == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeAnimationum_TABULAPUELLAEANIMATIONUM_CONFIG_NOT_FOUND);
                }
                _animationes[(int)c.Id] = new OnusAnimationis(
                    c.Animatio,
                    c.TempusEvanescentiae,
                    c.Lenitio,
                    c.EstIterans,
                    c.EstSimulataneum
                );
            }

            for (int i = 0; i < longitudo; i++) {
                if (i == (int)IDPuellaeAnimationis.Nihil) continue;
                if (i == (int)IDPuellaeAnimationis.Desinere) continue;
                if (_animationes[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeAnimationum_TABULAPUELLAEANIMATIONUM_CONFIG_NOT_FOUND);
                }
            }
        }

        public OnusAnimationis Legere(IDPuellaeAnimationis id) => _animationes[(int)id];
    }
}