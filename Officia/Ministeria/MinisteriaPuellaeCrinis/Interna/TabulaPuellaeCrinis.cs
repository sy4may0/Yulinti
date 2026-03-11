using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using System;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class TabulaPuellaeCrinis {
        private readonly IAnchoraPuellaeCrinis[] _crines;

        public TabulaPuellaeCrinis(IAnchoraPuellaeCrinis[] anchora) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeCrinis)).Length;
            _crines = new IAnchoraPuellaeCrinis[longitudo];

            for (int i = 0; i < anchora.Length; i++) {
                IAnchoraPuellaeCrinis a = anchora[i];
                _crines[(int)a.Typus] = a;
            }

            for (int i = 0; i < longitudo; i++) {
                if (_crines[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaPuellaeCrinis_TABULAPUELLAECRINIS_ID_NOT_FOUND);
                }
            }
        }

        public IAnchoraPuellaeCrinis Lego(IDPuellaeCrinis idCrinis) => _crines[(int)idCrinis];
    }
}


