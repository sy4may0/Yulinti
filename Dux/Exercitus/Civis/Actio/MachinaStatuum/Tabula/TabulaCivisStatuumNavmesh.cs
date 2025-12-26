using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class TabulaCivisStatuumNavmesh {
        private int IdCivis;
        private readonly IStatusCivisNavmesh[] _statuum;

        public TabulaCivisStatuumNavmesh(
            int idCivis,
            IConfiguratioCivisStatusNavmesh[] configurationemNavmesh,
            IOstiumCivisAnimationesMutabile osAnimationes,
            IOstiumCivisLociNavmeshLegibile osLociNavmeshLegibile,
            IOstiumCivisLociNavmeshMutabile osLociNavmeshMutabile,
            IOstiumPunctumViaeLegibile osPunctumViaeLegibile
        ) {
            IdCivis = idCivis;
            int longitudo = Enum.GetValues(typeof(IDCivisStatusNavmesh)).Length;
            _statuum = new IStatusCivisNavmesh[longitudo];

            foreach (var conf in configurationemNavmesh) {
                ICivisModiNavmesh modusNavmesh = FabricaCivisModiNavmesh.Creare(
                    conf,
                    osLociNavmeshLegibile,
                    osLociNavmeshMutabile,
                    osPunctumViaeLegibile
                );

                _statuum[(int)conf.Id] = new StatusCivisNavmesh(
                    idCivis,
                    conf,
                    osAnimationes,
                    osLociNavmeshMutabile,
                    modusNavmesh
                );
            }
        }

        public IStatusCivisNavmesh Lego(IDCivisStatusNavmesh id) {
            return _statuum[(int)id];
        }
    }
}