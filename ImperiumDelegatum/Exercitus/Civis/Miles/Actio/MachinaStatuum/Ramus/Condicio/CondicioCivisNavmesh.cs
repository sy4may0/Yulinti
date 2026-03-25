using Yulinti.ImperiumDelegatum.Contractus;
namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal static class CondicioCivisNavmesh {
        public static bool EstAdPerveni(
            int idCivis,
            ContextusRamusCivis contextus
        ) {
            return contextus.Loci.EstAdPerveni(idCivis);
        }
    }
}
