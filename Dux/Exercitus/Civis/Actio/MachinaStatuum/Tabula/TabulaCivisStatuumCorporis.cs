using Yulinti.Dux.ContractusDucis;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class TabulaCivisStatuumCorporis {
        private int IdCivis;
        private readonly IStatusCivisCorporis[] _statuum;

        public TabulaCivisStatuumCorporis(
            int idCivis,
            IConfiguratioCivisStatusCorporis[] configurationemCorporis,
            IOstiumCivisAnimationesMutabile osAnimationes,
            IOstiumCivisLociNavmeshMutabile osLoci,
            IOstiumCivisLociNavmeshLegibile osLociNavmeshLegibile,
            IOstiumCivisLociNavmeshMutabile osLociNavmeshMutabile,
            IOstiumPunctumViaeLegibile osPunctumViaeLegibile
        ) {
            IdCivis = idCivis;
            int longitudo = Enum.GetValues(typeof(IDCivisStatusCorporis)).Length;
            _statuum = new IStatusCivisCorporis[longitudo];

            foreach (var conf in configurationemCorporis) {
                ICivisModiNavmesh modusNavmesh = FabricaCivisModiNavmesh.Creare(
                    conf,
                    osLociNavmeshLegibile,
                    osLociNavmeshMutabile,
                    osPunctumViaeLegibile
                );

                _statuum[(int)conf.Id] = new StatusCivisCorporis(
                    idCivis,
                    conf,
                    osAnimationes,
                    osLoci,
                    modusNavmesh
                );
            }
        }

        public IStatusCivisCorporis Lego(IDCivisStatusCorporis id) {
            return _statuum[(int)id];
        }
    }
}