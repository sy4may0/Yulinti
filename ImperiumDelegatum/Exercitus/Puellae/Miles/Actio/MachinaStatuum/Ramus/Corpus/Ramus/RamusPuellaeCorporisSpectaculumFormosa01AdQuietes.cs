using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // 移動入力でエモートを抜ける。
    internal sealed class RamusPuellaeCorporisSpectaculumFormosa01AdQuietes : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.SpectaculumFormosa01;
        public IDPuellaeStatusCorporis IdStatusProximus(
            ContextusRamusPuellae contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return IDPuellaeStatusCorporis.Quies;
        }
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusRamusPuellae contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return CondicioPuellaeInput.EstMotus(contextusOstiorum, resFluida);
        }
    }
}