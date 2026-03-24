using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal static class CondicioPuellaeInput {
        // 移動E力があるかどうを判定すめ
        public static bool EstMotus(
            ContextusRamusPuellae contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            float limenInputQuadratum = contextusOstiorum.ConfiguratioStatuum.LimenInputQuadratum;
            return contextusOstiorum.Introductionis.LegoMotus.LengthSquared() >= limenInputQuadratum;
        }

        // Incumboが押されていかどうを判定すめ
        public static bool EstIncumbo(
            ContextusRamusPuellae contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return contextusOstiorum.Introductionis.LegoIncumbo;
        }

        // Cursusが押されていかどうを判定すめ
        public static bool EstCursus(
            ContextusRamusPuellae contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return contextusOstiorum.Introductionis.LegoCursus;
        }

        // SpectaculumCorporisが押されていかどうを判定すめ
        public static bool EstSpectaculumCorporis(
            ContextusRamusPuellae contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return contextusOstiorum.Introductionis.LegoSpectaculumCorporis;
        }
    }
}
