using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    public static class FabricaCivisModiNavmesh {
        public static ICivisModiNavmesh Creare(
            IDCivisModiNavmesh idModiNavmesh,
            IOstiumCivisLociNavmeshLegibile osLociNavmeshLegibile,
            IOstiumCivisLociNavmeshMutabile osLociNavmeshMutabile,
            IOstiumPunctumViaeLegibile osPunctumViaeLegibile
        ) {
            switch (idModiNavmesh) {
                case IDCivisModiNavmesh.None:
                    return new CivisModiNavmeshNihil(osLociNavmeshLegibile, osLociNavmeshMutabile);
                case IDCivisModiNavmesh.MigrareAditrium:
                    return new CivisModiNavmeshMigrareAditrium(osLociNavmeshLegibile, osLociNavmeshMutabile, osPunctumViaeLegibile);
                case IDCivisModiNavmesh.Suicidium:
                    return new CivisModiNavmeshSuicidium(osLociNavmeshLegibile, osLociNavmeshMutabile, osPunctumViaeLegibile);
                default:
                    Errorum.Fatal(IDErrorum.FABRICACIVISMODINAVMESH_MODI_NOT_FOUND);
                    return null;
            }
        }
    }
}