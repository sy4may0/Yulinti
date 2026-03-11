using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal static class CondicioPuellaeVelocitatis {
        // 停止状態である。
        public static bool EstVelocitatisQuietes(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            float limenVelocitatisIntransQuietes = contextusOstiorum.Configuratio.Statuum.LimenVelocitatisIntransQuietes;
            return resFluida.Motus.VelocitasActualisHorizontalis < limenVelocitatisIntransQuietes;
        }
    }
}