using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusCivisCorporis : IStatusCivisCorporis {
        private readonly int _idCivis;
        private readonly IDCivisStatusCorporis _idStatusCorporis;
        private readonly IDCivisAnimationisContinuata _idAnimationisIntrare;
        private readonly IDCivisAnimationisContinuata _idAnimationisExire;
        private readonly bool _ludereExire;
        private readonly IOstiumCivisAnimationesMutabile _osAnimationes;
        private readonly IOstiumCivisLociNavmeshMutabile _osLoci;
        private readonly bool _estNavMesh;

        public StatusCivisCorporis(
            int idCivis,
            IDCivisAnimationisContinuata idAnimationisIntrare,
            IDCivisAnimationisContinuata idAnimationisExire,
            bool ludereExire,
            IOstiumCivisAnimationesMutabile osAnimationes,
            bool estNavMesh
        ) {
            _idCivis = idCivis;
            _idAnimationisIntrare = idAnimationisIntrare;
            _idAnimationisExire = idAnimationisExire;
            _ludereExire = ludereExire;
            _osAnimationes = osAnimationes;
            _estNavMesh = estNavMesh;
        }

        public int IdCivis => _idCivis;
        public IDCivisStatusCorporis IdStatus => _idStatusCorporis;
        public IDCivisAnimationisContinuata IdAnimationisIntrare => _idAnimationisIntrare;
        public IDCivisAnimationisContinuata IdAnimationisExire => _idAnimationisExire;

        public void Intrare(IResFluidaCivisMotusLegibile resFuluidaMotus, Action adInitium = null) {
            _osAnimationes.Postulare(_idCivis, _idAnimationisIntrare, adInitium, null);
            if (_estNavMesh) {
                _osLoci.Activare(_idCivis);
            } else {
                _osLoci.Deactivare(_idCivis);
            }
        }

        public void Exire(IResFluidaCivisMotusLegibile resFuluidaMotus, Action adFinem = null) {
            _osAnimationes.Postulare(_idCivis, _idAnimationisExire, null, adFinem);
            _osLoci.Deactivare(_idCivis);
        }

        public OrdinatioCivisMotus Ordinare(IResFluidaCivisMotusLegibile resFuluidaMotus) {
            // 仮
            return OrdinatioCivisMotus.NihilMotus;
        }
    }
}
