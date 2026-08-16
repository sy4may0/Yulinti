using Yulinti.Auctoritas.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoSpatiiPuellaeVeletudinis : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis, IPraecoPulsabilisTardus {
        private readonly IVelumSpatiiPuellaeVeletudinis _velumSpatiiPuellaeVeletudinis;
        private readonly IResFluidaPuellaeVeletudinisLegibile _resFluidaPuellaeVeletudinis;
        private readonly ITurrisCorrectrix _turrisCorrectrix;

        public PraecoSpatiiPuellaeVeletudinis(
            IVelumSpatiiPuellaeVeletudinis velumSpatiiPuellaeVeletudinis,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            ITurrisCorrectrix turrisCorrectrix
        ) {
            _velumSpatiiPuellaeVeletudinis = velumSpatiiPuellaeVeletudinis;
            _resFluidaPuellaeVeletudinis = resFluidaPuellaeVeletudinis;
            _turrisCorrectrix = turrisCorrectrix;
        }

        public void Incipere() {
            _velumSpatiiPuellaeVeletudinis.Incarnare();
        }

        public void Liberare() {
            _velumSpatiiPuellaeVeletudinis.Spirituare();
        }

        public void PulsusTardus() {
            _velumSpatiiPuellaeVeletudinis.PonoVigorem(_resFluidaPuellaeVeletudinis.RatioVigoris);
            _velumSpatiiPuellaeVeletudinis.PonoPatientiam(_resFluidaPuellaeVeletudinis.RatioPatientiae);
            if (_turrisCorrectrix.EstCorrigere()) {
                _velumSpatiiPuellaeVeletudinis.PonoTextus(
                    $"VIG: {_resFluidaPuellaeVeletudinis.Vigor}\n" +
                    $"PAT: {_resFluidaPuellaeVeletudinis.Patientia}"
                );
            }
        }
    }
}