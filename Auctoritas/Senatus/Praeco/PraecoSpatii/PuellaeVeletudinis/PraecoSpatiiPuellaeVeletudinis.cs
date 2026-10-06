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
                    $"PAT: {_resFluidaPuellaeVeletudinis.Patientia}\n" +
                    $"CLAR: {_resFluidaPuellaeVeletudinis.Claritas}\n" +
                    $"ANO: {_resFluidaPuellaeVeletudinis.Anomalia}\n" +
                    $"ANOUD: {_resFluidaPuellaeVeletudinis.AnomaliaNudus}\n" +
                    $"AET: {_resFluidaPuellaeVeletudinis.Aether}\n" +
                    $"INT: {_resFluidaPuellaeVeletudinis.Intentio}\n" +
                    $"DED: {_resFluidaPuellaeVeletudinis.Dedecus}\n" +
                    $"SONQ: {_resFluidaPuellaeVeletudinis.SonusQuietes}\n" +
                    $"SONM: {_resFluidaPuellaeVeletudinis.SonusMotus}\n" +
                    $"NUDUSANT: {_resFluidaPuellaeVeletudinis.EstNudusAnterior}\n" +
                    $"NUDUSPOS: {_resFluidaPuellaeVeletudinis.EstNudusPosterior}"
                );
            }
        }
    }
}