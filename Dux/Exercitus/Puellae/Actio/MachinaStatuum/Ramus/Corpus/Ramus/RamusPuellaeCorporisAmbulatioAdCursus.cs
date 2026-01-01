using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusPuellaeCorporisAmbulatioAdCursus : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Ambulatio;
        public IDPuellaeStatusCorporis IdStatusProximus => IDPuellaeStatusCorporis.Cursus;
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return CondicioPuellaeInput.EstCursus(contextusOstiorum, resFluida);
        }
    }
}

