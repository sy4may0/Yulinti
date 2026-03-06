using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using System;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class NewTabulaPuellaeAnimationum {
        private readonly OnusAnimationis[] _animationes;

        public NewTabulaPuellaeAnimationum(NewIConfiguratioPuellaeAnimationis[] config) {
            int longitudo = Enum.GetValues(typeof(NewIDPuellaeAnimationis)).Length;
            _animationes = new OnusAnimationis[longitudo];

            foreach (NewIConfiguratioPuellaeAnimationis c in config) {
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
                if (i == (int)NewIDPuellaeAnimationis.Nihil) continue;
                if (_animationes[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeAnimationum_TABULAPUELLAEANIMATIONUM_CONFIG_NOT_FOUND);
                }
            }
        }

        public OnusAnimationis Legere(NewIDPuellaeAnimationis id) => _animationes[(int)id];
    }
}