using Yulinti.Exercitus.Contractus;
namespace Yulinti.Exercitus.Dux {
    internal static class CondicioCivisNavmesh {
        public static bool EstAdPerveni(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum
        ) {
            return contextusOstiorum.Loci.EstAdPerveni(idCivis);
        }
    }
}
