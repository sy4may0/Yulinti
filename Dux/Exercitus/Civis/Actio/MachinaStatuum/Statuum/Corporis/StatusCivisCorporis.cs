using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusCivisCorporis : IStatusCivisCorporis {
        private readonly int _idCivis;
        private readonly IOstiumCivisAnimationesMutabile _osAnimationes;
        private readonly IOstiumCivisLociNavmeshMutabile _osLoci;

        private readonly IDCivisStatusCorporis _idStatus;
        private readonly IDCivisAnimationisContinuata _idAnimationisIntrare;
        private readonly IDCivisAnimationisContinuata _idAnimationisExire;
        private readonly bool _ludereExire;
        private readonly bool _estNavMesh;
        private readonly int _consumptioVitae;

        private readonly ICivisModiNavmesh _modusNavmesh;

        public StatusCivisCorporis(
            int idCivis,
            IConfiguratioCivisStatusCorporis configurationCorporis,
            IOstiumCivisAnimationesMutabile osAnimationes,
            IOstiumCivisLociNavmeshMutabile osLoci,
            ICivisModiNavmesh modusNavmesh
        ) {
            _idCivis = idCivis;
            _idStatus = configurationCorporis.Id;
            _idAnimationisIntrare = configurationCorporis.IdAnimationisIntrare;
            _idAnimationisExire = configurationCorporis.IdAnimationisExire;
            _ludereExire = configurationCorporis.LudereExire;
            _estNavMesh = configurationCorporis.EstNavMesh;
            _consumptioVitae = configurationCorporis.ConsumptioVitae;
            _osAnimationes = osAnimationes;
            _osLoci = osLoci;
            _modusNavmesh = modusNavmesh;
        }

        public int IdCivis => _idCivis;
        public IDCivisStatusCorporis IdStatus => _idStatus;
        public IDCivisAnimationisContinuata IdAnimationisIntrare => _idAnimationisIntrare;
        public IDCivisAnimationisContinuata IdAnimationisExire => _idAnimationisExire;
        public int ConsumptioVitae => _consumptioVitae;

        public void Intrare(IResFluidaCivisMotusLegibile resFuluidaMotus, Action adInitium = null) {
            _osAnimationes.Postulare(_idCivis, _idAnimationisIntrare, adInitium, null);
            if (_estNavMesh) {
                _modusNavmesh.Intrare(_idCivis);
            }
        }

        public void Exire(IResFluidaCivisMotusLegibile resFuluidaMotus, Action adFinem = null) {
            _osAnimationes.Postulare(_idCivis, _idAnimationisExire, null, adFinem);
            if (_estNavMesh) {
                _modusNavmesh.Exire(_idCivis);
            }
        }

        public OrdinatioCivisMotus Ordinare(IResFluidaCivisMotusLegibile resFuluidaMotus) {
            // 仮
            return OrdinatioCivisMotus.NihilMotus;
        }
    }
}
