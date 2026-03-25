using System;
using System.Numerics;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResFluidaPuellaeFormae : IResFluidaPuellaeFormaeLegibile {
        private Vector3[] _magnitudinesActualium;

        public ResFluidaPuellaeFormae() {
            int longitudo = Enum.GetValues(typeof(IDPuellaeFormae)).Length;
            _magnitudinesActualium = new Vector3[longitudo];
            for (int i = 0; i < longitudo; i++) {
                _magnitudinesActualium[i] = new Vector3(1f, 1f, 1f);
            }
        }

        public Vector3 MagnitudoActualis(IDPuellaeFormae idFormae) {
            if (idFormae == IDPuellaeFormae.Nihil) {
                Carnifex.Error(LogTextus.ResFluidaPuellaeFormae_LEGERE_NIHIL);
                return new Vector3(1f, 1f, 1f);
            }
            return _magnitudinesActualium[(int)idFormae];
        }

        public void RenovareMagnitudoActualis(IDPuellaeFormae idFormae, Vector3 magnitudoActualis) {
            if (idFormae == IDPuellaeFormae.Nihil) {
                Carnifex.Error(LogTextus.ResFluidaPuellaeFormae_LEGERE_NIHIL);
                return;
            }
            _magnitudinesActualium[(int)idFormae] = magnitudoActualis;
        }

        public void Purgare() {
            for (int i = 0; i < _magnitudinesActualium.Length; i++) {
                _magnitudinesActualium[i] = new Vector3(0f, 0f, 0f);
            }
        }
    }
}