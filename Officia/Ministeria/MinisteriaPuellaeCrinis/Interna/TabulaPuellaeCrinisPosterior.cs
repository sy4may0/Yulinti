using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using System;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class TabulaPuellaeCrinisPosterior {
        private readonly IAnchoraPuellaeCrinisPosterior[] _crines;

        public TabulaPuellaeCrinisPosterior(IAnchoraPuellaeCrinisPosterior[] anchora) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeCrinisPosterior)).Length;
            _crines = new IAnchoraPuellaeCrinisPosterior[longitudo];

            for (int i = 0; i < anchora.Length; i++) {
                IAnchoraPuellaeCrinisPosterior a = anchora[i];
                _crines[(int)a.Typus] = a;
            }

            for (int i = 0; i < longitudo; i++) {
                if ((IDPuellaeCrinisPosterior)i == IDPuellaeCrinisPosterior.Nihil) {
                    continue;
                }
                if (_crines[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeCrinisPosterior_TABULAPUELLAECRINISPOSTERIOR_ID_NOT_FOUND);
                }
            }
        }

        public IAnchoraPuellaeCrinisPosterior Lego(IDPuellaeCrinisPosterior idCrinis) => _crines[(int)idCrinis];
    }
}
