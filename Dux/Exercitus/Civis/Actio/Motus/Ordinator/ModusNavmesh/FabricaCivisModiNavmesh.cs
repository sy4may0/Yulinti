using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    public static class FabricaCivisModiNavmesh {
        public static ICivisModiNavmesh Creare(
            IConfiguratioCivisStatusCorporis configurationCorporis,
            IOstiumCivisLociNavmeshLegibile osLociNavmeshLegibile,
            IOstiumCivisLociNavmeshMutabile osLociNavmeshMutabile,
            IOstiumPunctumViaeLegibile osPunctumViaeLegibile
        ) {
            switch (configurationCorporis.IdModiNavmesh) {
                case IDCivisModiNavmesh.None:
                    return new CivisModiNavmeshNihil(configurationCorporis, osLociNavmeshLegibile, osLociNavmeshMutabile);
                case IDCivisModiNavmesh.MigrareAditrium:
                    return new CivisModiNavmeshMigrareAditrium(configurationCorporis, osLociNavmeshLegibile, osLociNavmeshMutabile, osPunctumViaeLegibile);
                case IDCivisModiNavmesh.Suicidium:
                    return new CivisModiNavmeshSuicidium(configurationCorporis, osLociNavmeshLegibile, osLociNavmeshMutabile, osPunctumViaeLegibile);
                default:
                    Errorum.Fatal(IDErrorum.FABRICACIVISMODINAVMESH_MODI_NOT_FOUND);
                    return null;
            }
        }
    }
}