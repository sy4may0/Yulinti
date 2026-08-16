using Yulinti.Auctoritas.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoSpatiiCivisVeletudinis : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis, IPraecoPulsabilisTardus {
        private readonly IVelumSpatiiCivisVeletudinis _velumSpatiiCivisVeletudinis;
        private readonly IResFluidaCivisVeletudinisLegibile _resFluidaCivisVeletudinis;
        private readonly IOstiumCameraLegibile _ostiumCameraLegibile;
        private readonly ITurrisCorrectrix _turrisCorrectrix;

        public PraecoSpatiiCivisVeletudinis(
            IVelumSpatiiCivisVeletudinis velumSpatiiCivisVeletudinis,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IOstiumCameraLegibile ostiumCameraLegibile,
            ITurrisCorrectrix turrisCorrectrix
        ) {
            _velumSpatiiCivisVeletudinis = velumSpatiiCivisVeletudinis;
            _resFluidaCivisVeletudinis = resFluidaCivisVeletudinis;
            _ostiumCameraLegibile = ostiumCameraLegibile;
            _turrisCorrectrix = turrisCorrectrix;
        }

        public void Incipere() {
            // CivisのManifestatioは初回Pulsus以降にしか発生しないため、
            // Senator.Incipere(Start内で最後)での初期化でも最初のAnchora生成に間に合う。
            _velumSpatiiCivisVeletudinis.Initiare(_resFluidaCivisVeletudinis.Longitudo);
        }

        public void Liberare() {
            _velumSpatiiCivisVeletudinis.Liberare();
        }

        public void PulsusTardus() {
            for (int i = 0; i < _resFluidaCivisVeletudinis.Longitudo; i++) {
                if (!_resFluidaCivisVeletudinis.EstActivum(i)) {
                    _velumSpatiiCivisVeletudinis.SpirituareUnus(i);
                    continue;
                }

                // suspecta/intentioが0なら非表示
                if (
                    _resFluidaCivisVeletudinis.Suspecta(i) <= Numerus.Epsilon && 
                    _resFluidaCivisVeletudinis.Intentio(i) <= Numerus.Epsilon) 
                {
                    _velumSpatiiCivisVeletudinis.SpirituareUnus(i);
                } else {
                    _velumSpatiiCivisVeletudinis.IncarnareUnus(i);
                    _velumSpatiiCivisVeletudinis.PonoRotationem(i, _ostiumCameraLegibile.Rotatio);
                }

                _velumSpatiiCivisVeletudinis.PonoIntentionem(i, _resFluidaCivisVeletudinis.Intentio(i));
                _velumSpatiiCivisVeletudinis.PonoSuspectum(i, _resFluidaCivisVeletudinis.Suspecta(i));

                if (_turrisCorrectrix.EstCorrigere()) {
                    _velumSpatiiCivisVeletudinis.PonoTextus(i, 
                       $"VIT: {_resFluidaCivisVeletudinis.Vitae(i)}\n" +
                       $"SUS: {_resFluidaCivisVeletudinis.Suspecta(i)}\n" +
                       $"STU: {_resFluidaCivisVeletudinis.Studium(i)}\n" +
                       $"INT: {_resFluidaCivisVeletudinis.Intentio(i)}\n" +
                       $"TORMAX: {_resFluidaCivisVeletudinis.TorelantiaAnomaliaeMaxima(i)}\n" +
                       $"TORMIN: {_resFluidaCivisVeletudinis.TorelantiaAnomaliaeMinima(i)}\n" +
                       $"SPCNUD: {_resFluidaCivisVeletudinis.EstSpectareNudus(i)}"
                    );
                }
            }
        }
        
    }
}