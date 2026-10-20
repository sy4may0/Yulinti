using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using System;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class TabulaPuellaeCrinisAnterior {
        private readonly IAnchoraPuellaeCrinisAnterior[] _crines;

        public TabulaPuellaeCrinisAnterior(IAnchoraPuellaeCrinisAnterior[] anchora) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeCrinisAnterior)).Length;
            _crines = new IAnchoraPuellaeCrinisAnterior[longitudo];

            for (int i = 0; i < anchora.Length; i++) {
                IAnchoraPuellaeCrinisAnterior a = anchora[i];
                _crines[(int)a.Typus] = a;
            }

            for (int i = 0; i < longitudo; i++) {
                if ((IDPuellaeCrinisAnterior)i == IDPuellaeCrinisAnterior.Nihil) {
                    continue;
                }
                if (_crines[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeCrinisAnterior_TABULAPUELLAECRINISANTERIOR_ID_NOT_FOUND);
                }
            }
        }

        public IAnchoraPuellaeCrinisAnterior Lego(IDPuellaeCrinisAnterior idCrinis) => _crines[(int)idCrinis];
    }
}
