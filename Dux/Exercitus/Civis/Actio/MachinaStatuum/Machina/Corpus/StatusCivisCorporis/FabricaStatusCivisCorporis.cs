using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal sealed class FabricaStatusCivisCorporis {
        internal static IStatusCivisCorporis Creare(
            IConfiguratioCivisStatuum configuratioStatuum,
            IConfiguratioCivisStatusCorporis configuratio
        ) {
            // configuratioがMotus実装の場合
            if (configuratio is IConfiguratioCivisStatusCorporisMotus configuratioMotus) {
                switch (configuratioMotus.IdModiMotus) {
                    case IDCivisStatusCorporisModiMotus.MotusQuietus:
                        return new StatusCivisCorporisMotusQuietes(configuratioStatuum, configuratioMotus);
                    default:
                        Errorum.Fatal(IDErrorum.FABRICACIVISSTATUSCORPORIS_MODUS_NOT_FOUND);
                        return null;
                }
            // configuratioがNavmesh実装の場合
            } else if (configuratio is IConfiguratioCivisStatusCorporisNavmesh configuratioNavmesh) {
                switch (configuratioNavmesh.IdModiNavmesh) {
                    case IDCivisStatusCorporisModiNavmesh.NavmeshLociTemere:
                        return new StatusCivisCorporisNavmeshLoci(configuratioStatuum, configuratioNavmesh);
                    default:
                        Errorum.Fatal(IDErrorum.FABRICACIVISSTATUSCORPORIS_MODUS_NOT_FOUND);
                        return null;
                }
            } else {
                Errorum.Fatal(IDErrorum.FABRICACIVISSTATUSCORPORIS_INVALID_CONFIGURATION);
                return null;
            }
        }
    }
}