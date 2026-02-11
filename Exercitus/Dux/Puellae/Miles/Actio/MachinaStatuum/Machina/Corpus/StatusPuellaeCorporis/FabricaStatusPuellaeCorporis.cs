using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class FabricaStatusPuellaeCorporis {
        internal static IStatusPuellaeCorporis Creare(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporis configuratio
        ) {
            // configuratioがMotus実装の場合
            if (configuratio is IConfiguratioPuellaeStatusCorporisMotus configuratioMotus) {
                switch (configuratioMotus.IdModiMotus) {
                    case IDPuellaeStatusCorporisModiMotus.MotusQuietus:
                        return new StatusPuellaeCorporisMotusQuietes(configuratioStatuum, configuratioMotus);
                    case IDPuellaeStatusCorporisModiMotus.MotusLoci:
                        return new StatusPuellaeCorporisMotusLoci(configuratioStatuum, configuratioMotus);
                    default:
                        Carnifex.Intermissio(LogTextus.FabricaStatusPuellaeCorporis_FABRICAPUELLAESTATUSCORPORIS_MODUS_NOT_FOUND);
                        return null;
                }
            // configuratioがNavmesh実装の場合 (Navmeshステートは未実装)
            //} else if (configuratio is IConfiguratioPuellaeStatusCorporisNavmesh configuratioNavmesh) {
            //    switch (configuratioNavmesh.IdModiNavmesh) {
            //        case IDPuellaeStatusCorporisModiNavmesh.NavmeshQuietus:
            //            return new StatusPuellaeCorporisNavmeshQuietes(configuratioStatuum, configuratioNavmesh, osAnimationes);
            //        case IDPuellaeStatusCorporisModiNavmesh.NavmeshLoci:
            //            return new StatusPuellaeCorporisNavmeshLoci(configuratioStatuum, configuratioNavmesh, osAnimationes);
            //        default:
            //            Carnifex.Intermissio(LogTextus.FabricaStatusPuellaeCorporis_FABRICAPUELLAESTATUSCORPORIS_MODUS_NOT_FOUND);
            //            return null;
            //    }
            } else {
                Carnifex.Intermissio(LogTextus.FabricaStatusPuellaeCorporis_FABRICAPUELLAESTATUSCORPORIS_INVALID_CONFIGURATION);
                return null;
            }
        }
    }
}