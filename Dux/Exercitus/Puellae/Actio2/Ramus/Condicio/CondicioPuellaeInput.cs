using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal static class CondicioPuellaeInput {
        // 移動入力があるかどうかを判定する
        public static bool EstMotus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            float limenInputQuadratum = contextusOstiorum.Configuratio.Statuum.LimenInputQuadratum;
            IOstiumInputMotusLegibile inputMotus = contextusOstiorum.InputMotus;

            return inputMotus.LegoMotus.LengthSquared() >= limenInputQuadratum;
        }

        // Incumboが押されているかどうかを判定する
        public static bool EstIncumbo(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            return contextusOstiorum.InputMotus.LegoIncumbo;
        }

        // Cursusが押されているかどうかを判定する
        public static bool EstCursus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            return contextusOstiorum.InputMotus.LegoCursus;
        }
    }
}