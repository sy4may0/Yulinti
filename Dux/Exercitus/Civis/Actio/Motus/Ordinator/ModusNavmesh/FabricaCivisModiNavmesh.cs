using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    public static class FabricaCivisModiNavmesh {
        public static ICivisModiNavmesh Creare(
            IConfiguratioCivisStatusNavmesh configurationNavmesh,
            IOstiumCivisLociNavmeshLegibile osLociNavmeshLegibile,
            IOstiumCivisLociNavmeshMutabile osLociNavmeshMutabile,
            IOstiumPunctumViaeLegibile osPunctumViaeLegibile
        ) {
            switch (configurationNavmesh.IdModiNavmesh) {
                case IDCivisModiNavmesh.None:
                    return new CivisModiNavmeshNihil(configurationNavmesh, osLociNavmeshLegibile, osLociNavmeshMutabile);
                case IDCivisModiNavmesh.MigrareAditorium:
                    return new CivisModiNavmeshMigrareAditorium(configurationNavmesh, osLociNavmeshLegibile, osLociNavmeshMutabile, osPunctumViaeLegibile);
                case IDCivisModiNavmesh.Suicidium:
                    return new CivisModiNavmeshSuicidium(configurationNavmesh, osLociNavmeshLegibile, osLociNavmeshMutabile, osPunctumViaeLegibile);
                default:
                    Errorum.Fatal(IDErrorum.FABRICACIVISMODINAVMESH_MODI_NOT_FOUND);
                    return null;
            }
        }
    }
}