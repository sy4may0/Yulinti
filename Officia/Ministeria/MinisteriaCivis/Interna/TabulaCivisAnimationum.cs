using System;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class TabulaCivisAnimationum {
        private readonly OnusAnimationis[] _animationes;

        public TabulaCivisAnimationum(IConfiguratioCivisAnimationis[] config) {
            int longitudo = Enum.GetValues(typeof(IDCivisAnimationis)).Length;
            _animationes = new OnusAnimationis[longitudo];

            foreach (IConfiguratioCivisAnimationis c in config) {
                if (c == null) {
                    Carnifex.Intermissio(LogTextus.TabulaCivisAnimationumContinuata_TABULACIVISANIMATIONUMCONTINUATA_CONFIG_NOT_FOUND);
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
                if (i == (int)IDCivisAnimationis.Nihil) continue;
                if (i == (int)IDCivisAnimationis.Desinere) continue;
                if (_animationes[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaCivisAnimationumContinuata_TABULACIVISANIMATIONUMCONTINUATA_CONFIG_NOT_FOUND);
                }
            }
        }

        public OnusAnimationis Legere(IDCivisAnimationis id) => _animationes[(int)id];
    }
}
