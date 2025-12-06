using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusPuellaeCorporisMotus : IStatusPuellaeCorporis {
        private IDStatus _id;
        private IDPuellaeAnimationisCorporis _idAnimationis;
        private IOrdinatorPuellaeModi _ordinator;
        private IOstiumPuellaeAnimationesMutabile _osAnimationes;

        public StatusPuellaeCorporisMotus(
            IDStatus id,
            IDPuellaeAnimationisCorporis idAnimationis,
            IOrdinatorPuellaeModi ordinator,
            IOstiumPuellaeAnimationesMutabile osAnimationes 
        ) {
            _id = id;
            _idAnimationis = idAnimationis;
            _ordinator = ordinator;
            _osAnimationes = osAnimationes;
        }

        public IDStatus Id => _id;
        public IDPuellaeAnimationisCorporis IdAnimationis => _idAnimationis;

        public void Intrare(IResFluidaPuellaeMotusLegibile resFuluidaMotus) {
        }

        public void Exire(IResFluidaPuellaeMotusLegibile resFuluidaMotus, Action fInvocanda) {
        }

        public OrdinatioPuellaeMotus Ordinare(IResFluidaPuellaeMotusLegibile resFuluidaMotus) {
            return _ordinator.Ordinare(resFuluidaMotus);
        }
    }
}