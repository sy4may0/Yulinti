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

        public float RatioActualis(IDPuellaeFormae idFormae) {
            if (!_puellaeFormarumDto.Formarum.ContainsKey(idFormae)) {
                return 0.5f;
            }
            return _puellaeFormarumDto.Formarum[idFormae].Ratio;
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
                _puellaeFormarumDto.Formarum[idFormae].Renovare(resFluidaPuellaeFormae.RatioActualis(idFormae));
            }
        }
    }
}