using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusCivisNavmesh : IStatusCivisNavmesh {
        private readonly int _idCivis;
        private readonly IOstiumCivisAnimationesMutabile _osAnimationes;
        private readonly IOstiumCivisLociNavmeshMutabile _osLoci;

        private readonly IDCivisStatusNavmesh _idStatus;
        private readonly IDCivisAnimationisContinuata _idAnimationisIntrare;
        private readonly IDCivisAnimationisContinuata _idAnimationisExire;
        private readonly bool _ludereExire;
        private readonly int _consumptioVitae;

        private readonly ICivisModiNavmesh _modusNavmesh;

        public StatusCivisNavmesh(
            int idCivis,
            IConfiguratioCivisStatusNavmesh configurationNavmesh,
            IOstiumCivisAnimationesMutabile osAnimationes,
            IOstiumCivisLociNavmeshMutabile osLoci,
            ICivisModiNavmesh modusNavmesh
        ) {
            _idCivis = idCivis;
            _idStatus = configurationNavmesh.Id;
            _idAnimationisIntrare = configurationNavmesh.IdAnimationisIntrare;
            _idAnimationisExire = configurationNavmesh.IdAnimationisExire;
            _ludereExire = configurationNavmesh.LudereExire;
            _consumptioVitae = configurationNavmesh.ConsumptioVitae;
            _osAnimationes = osAnimationes;
            _osLoci = osLoci;
            _modusNavmesh = modusNavmesh;
        }

        public int IdCivis => _idCivis;
        public IDCivisStatusNavmesh IdStatus => _idStatus;
        public IDCivisAnimationisContinuata IdAnimationisIntrare => _idAnimationisIntrare;
        public IDCivisAnimationisContinuata IdAnimationisExire => _idAnimationisExire;
        public int ConsumptioVitae => _consumptioVitae;

        public void Intrare(ContextusCivisResFluidaLegibile contextus, Action adInitium = null) {
            _osAnimationes.Postulare(_idCivis, _idAnimationisIntrare, adInitium, null);
            _modusNavmesh.Intrare(_idCivis);
        }

        public void Exire(ContextusCivisResFluidaLegibile contextus, Action adFinem = null) {
            _osAnimationes.Postulare(_idCivis, _idAnimationisExire, null, adFinem);
            _modusNavmesh.Exire(_idCivis);
        }

        public OrdinatioCivisMotus Ordinare(ContextusCivisResFluidaLegibile contextus) {
            // 仮
            return OrdinatioCivisMotus.NihilMotus;
        }
    }
}
