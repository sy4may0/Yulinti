using Yulinti.ImperiumDelegatum.Contractus;
using System.Numerics;
using System;

namespace Yulinti.Officia.Turris {
    internal sealed class OstiumSalsamentiPuellaeFormarum : IOstiumSalsamentiPuellaeFormarum {
        private SalsamentumPuellaeFormarumDto _puellaeFormarumDto;

        public OstiumSalsamentiPuellaeFormarum(
            SalsamentumPuellaeFormarumDto puellaeFormarumDto
        ) {
            _puellaeFormarumDto = puellaeFormarumDto;
        }

        public Vector3 MagnitudoActualis(IDPuellaeFormae idFormae) {
            if (!_puellaeFormarumDto.Formarum.ContainsKey(idFormae)) {
                return new Vector3(1f, 1f, 1f);
            }
            return new Vector3(
                _puellaeFormarumDto.Formarum[idFormae].MagnitudoX,
                _puellaeFormarumDto.Formarum[idFormae].MagnitudoY,
                _puellaeFormarumDto.Formarum[idFormae].MagnitudoZ
            );
        }

        // Thesaurusからのデータ更新
        public void Renovare(SalsamentumPuellaeFormarumDto puellaeFormarumDto) {
            _puellaeFormarumDto = puellaeFormarumDto;
        }

        // 内部からのデータ更新
        public void Renovare(IResFluidaPuellaeFormaeLegibile resFluidaPuellaeFormae) {
            foreach (IDPuellaeFormae idFormae in Enum.GetValues(typeof(IDPuellaeFormae))) {
                if (idFormae == IDPuellaeFormae.Nihil) {
                    continue;
                }
                _puellaeFormarumDto.Formarum[idFormae].Renovare(resFluidaPuellaeFormae.MagnitudoActualis(idFormae));
            }
        }
    }
}