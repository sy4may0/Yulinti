using Yulinti.ImperiumDelegatum.Contractus;
namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal static class CondicioCivisNavmesh {
        public static bool EstAdPerveni(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum
        ) {
            return contextusOstiorum.Loci.EstAdPerveni(idCivis);
        }
    }
}
