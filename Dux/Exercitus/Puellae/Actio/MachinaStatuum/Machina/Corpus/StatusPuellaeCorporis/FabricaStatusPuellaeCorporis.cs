using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
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
                        Errorum.Fatal(IDErrorum.FABRICAPUELLAESTATUSCORPORIS_MODUS_NOT_FOUND);
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
            //            Errorum.Fatal(IDErrorum.FABRICAPUELLAESTATUSCORPORIS_MODUS_NOT_FOUND);
            //            return null;
            //    }
            } else {
                Errorum.Fatal(IDErrorum.FABRICAPUELLAESTATUSCORPORIS_INVALID_CONFIGURATION);
                return null;
            }
        }
    }
}