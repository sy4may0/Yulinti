using UnityEngine;
using Yulinti.MinisteriaUnity.Anchora;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeCrinis {
        private readonly AnchoraPuellaeCrinis[] _crines;

        public TabulaPuellaeCrinis(AnchoraPuellaeCrinis[] anchora) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeCrinis)).Length;
            _crines = new AnchoraPuellaeCrinis[longitudo];

            for (int i = 0; i < anchora.Length; i++) {
                AnchoraPuellaeCrinis a = anchora[i];
                _crines[(int)a.Typus] = a;
            }

            for (int i = 0; i < longitudo; i++) {
                if (_crines[i] == null) {
                    Errorum.Fatal(IDErrorum.TABULAPUELLAECRINIS_ID_NOT_FOUND);
                }
            }
        }

        public AnchoraPuellaeCrinis Lego(IDPuellaeCrinis idCrinis) => _crines[(int)idCrinis];
    }
}
