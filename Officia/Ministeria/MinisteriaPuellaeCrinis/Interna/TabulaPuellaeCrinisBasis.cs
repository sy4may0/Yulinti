using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using System;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class TabulaPuellaeCrinisBasis {
        private readonly IAnchoraPuellaeCrinisBasis[] _crines;

        public TabulaPuellaeCrinisBasis(IAnchoraPuellaeCrinisBasis[] anchora) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeCrinisBasis)).Length;
            _crines = new IAnchoraPuellaeCrinisBasis[longitudo];

            for (int i = 0; i < anchora.Length; i++) {
                IAnchoraPuellaeCrinisBasis a = anchora[i];
                _crines[(int)a.Typus] = a;
            }

            for (int i = 0; i < longitudo; i++) {
                if ((IDPuellaeCrinisBasis)i == IDPuellaeCrinisBasis.Nihil) {
                    continue;
                }
                if (_crines[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeCrinisBasis_TABULAPUELLAECRINISBASIS_ID_NOT_FOUND);
                }
            }
        }

        public IAnchoraPuellaeCrinisBasis Lego(IDPuellaeCrinisBasis idCrinis) => _crines[(int)idCrinis];
    }
}
