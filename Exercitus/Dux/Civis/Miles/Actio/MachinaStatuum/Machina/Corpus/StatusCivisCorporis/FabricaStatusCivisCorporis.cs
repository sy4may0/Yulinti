using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Exercitus.Dux {
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
                        Carnifex.Intermissio(LogTextus.FabricaStatusCivisCorporis_FABRICACIVISSTATUSCORPORIS_MODUS_NOT_FOUND);
                        return null;
                }
            // configuratioがNavmesh実装の場合
            } else if (configuratio is IConfiguratioCivisStatusCorporisNavmesh configuratioNavmesh) {
                switch (configuratioNavmesh.IdModiNavmesh) {
                    case IDCivisStatusCorporisModiNavmesh.NavmeshLociTemere:
                        return new StatusCivisCorporisNavmeshLoci(configuratioStatuum, configuratioNavmesh);
                    default:
                        Carnifex.Intermissio(LogTextus.FabricaStatusCivisCorporis_FABRICACIVISSTATUSCORPORIS_MODUS_NOT_FOUND);
                        return null;
                }
            } else {
                Carnifex.Intermissio(LogTextus.FabricaStatusCivisCorporis_FABRICACIVISSTATUSCORPORIS_INVALID_CONFIGURATION);
                return null;
            }
        }
    }
}