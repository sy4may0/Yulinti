using System;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.Officia.Turris {
    internal sealed class PhantasmaPuellaeFormarum : IPhantasmaPuellaeFormarumLegibile, IPhantasmaSalsamenti {
        private readonly float[] _ratiosActualium;

        public PhantasmaPuellaeFormarum() {
            int longitudo = Enum.GetValues(typeof(IDPuellaeFormae)).Length;
            _ratiosActualium = new float[longitudo];
            Purgare();
        }

        public float RatioActualis(IDPuellaeFormae idFormae) {
            if (idFormae == IDPuellaeFormae.Nihil) {
                Carnifex.Error(LogTextus.PhantasmaPuellaeFormarum_LEGERE_NIHIL);
                return 0.5f;
            }
            return _ratiosActualium[(int)idFormae];
        }

        internal void PonoRationem(IDPuellaeFormae idFormae, float ratio) {
            if (idFormae == IDPuellaeFormae.Nihil) {
                Carnifex.Error(LogTextus.PhantasmaPuellaeFormarum_LEGERE_NIHIL);
                return;
            }
            _ratiosActualium[(int)idFormae] = ratio;
        }

        public void Renovare(SalsamentumDto dto) {
            foreach (IDPuellaeFormae idFormae in Enum.GetValues(typeof(IDPuellaeFormae))) {
                if (idFormae == IDPuellaeFormae.Nihil) {
                    continue;
                }
                if (!dto.PuellaeFormarum.Formarum.ContainsKey(idFormae)) {
                    _ratiosActualium[(int)idFormae] = 0.5f;
                    continue;
                }
                _ratiosActualium[(int)idFormae] = dto.PuellaeFormarum.Formarum[idFormae].Ratio;
            }
        }

        public void Imple(SalsamentumDto dto) {
            foreach (IDPuellaeFormae idFormae in Enum.GetValues(typeof(IDPuellaeFormae))) {
                if (idFormae == IDPuellaeFormae.Nihil) {
                    continue;
                }
                if (!dto.PuellaeFormarum.Formarum.ContainsKey(idFormae)) {
                    dto.PuellaeFormarum.Formarum[idFormae] = new SalsamentumPuellaeFormaeDto();
                }
                dto.PuellaeFormarum.Formarum[idFormae].Renovare(RatioActualis(idFormae));
            }
        }

        public void Purgare() {
            for (int i = 0; i < _ratiosActualium.Length; i++) {
                _ratiosActualium[i] = 0.5f;
            }
        }
    }
}
