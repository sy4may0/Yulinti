using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusPuellaeCorporisMotus : IStatusPuellaeCorporis {
        private IDStatus _id;
        private IDPuellaeAnimationisContinuata _idAnimationisIntrare;
        private IDPuellaeAnimationisContinuata _idAnimationisExire;
        private bool _ludereExire;
        private IOrdinatorPuellaeModi _ordinator;
        private IOstiumPuellaeAnimationesMutabile _osAnimationes;

        public StatusPuellaeCorporisMotus(
            IDStatus id,
            IDPuellaeAnimationisContinuata idAnimationisIntrare,
            IDPuellaeAnimationisContinuata idAnimationisExire,
            bool ludereExire,
            IOrdinatorPuellaeModi ordinator,
            IOstiumPuellaeAnimationesMutabile osAnimationes 
        ) {
            _id = id;
            _idAnimationisIntrare = idAnimationisIntrare;
            _idAnimationisExire = idAnimationisExire;
            _ludereExire = ludereExire;
            _ordinator = ordinator;
            _osAnimationes = osAnimationes;
        }

        public IDStatus Id => _id;
        public IDPuellaeAnimationisContinuata IdAnimationisIntrare => _idAnimationisIntrare;
        public IDPuellaeAnimationisContinuata IdAnimationisExire => _idAnimationisExire;

        public void Intrare(IResFluidaPuellaeMotusLegibile resFuluidaMotus, Action adInitium = null) {
            _osAnimationes.Postulare(_idAnimationisIntrare, adInitium, null);
        }

        public void Exire(IResFluidaPuellaeMotusLegibile resFuluidaMotus, Action adFinem = null) {
            if (_ludereExire) {
                _osAnimationes.Postulare(_idAnimationisExire, null, adFinem);
            }
        }

        public OrdinatioPuellaeMotus Ordinare(IResFluidaPuellaeMotusLegibile resFuluidaMotus) {
            return _ordinator.Ordinare(resFuluidaMotus);
        }
    }
}