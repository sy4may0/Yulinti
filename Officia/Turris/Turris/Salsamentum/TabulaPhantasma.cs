using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Officia.Turris {
    internal sealed class TabulaPhantasma {
        private readonly IPhantasmaSalsamenti[] _phantasmata;
        private readonly PhantasmaPuellaePersonae _phantasmaPuellaePersonae;

        public TabulaPhantasma(
            IReadOnlyList<IPhantasmaSalsamenti> phantasmata,
            PhantasmaPuellaePersonae phantasmaPuellaePersonae
        ) {
            _phantasmata = phantasmata.ToArray();
            _phantasmaPuellaePersonae = phantasmaPuellaePersonae;
        }

        public void Purgare() {
            foreach (IPhantasmaSalsamenti phantasma in _phantasmata) {
                phantasma.Purgare();
            }
        }

        public void Renovare(SalsamentumDto dto) {
            foreach (IPhantasmaSalsamenti phantasma in _phantasmata) {
                phantasma.Renovare(dto);
            }
        }

        public SalsamentumDto CreareDto() {
            SalsamentumDto dto = new SalsamentumDto();
            foreach (IPhantasmaSalsamenti phantasma in _phantasmata) {
                phantasma.Imple(dto);
            }
            return dto;
        }

        public SalsamentumNotitiaeDto CreareNotitiaeDto() {
            SalsamentumNotitiaeDto dto = new SalsamentumNotitiaeDto();
            _phantasmaPuellaePersonae.Imple(dto);
            return dto;
        }
    }
}
