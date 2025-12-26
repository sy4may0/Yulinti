using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusCivisNativitasAdAditorium : IRamusCivisNavmesh {
        public IDCivisStatusNavmesh IdStatusActualis => IDCivisStatusNavmesh.Nativitas;
        public IDCivisStatusNavmesh IdStatusProximus => IDCivisStatusNavmesh.Aditorium;
        public int Prioritas => 0;
        public bool Condicio(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            ContextusCivisResFluidaLegibile contextusResFluida
        ) {
            // Nativitas -> MigrareAditoriumは即遷移する。
            // NativitasはIntareでSpawn/Warpされる。
            return true;
        }
    }
}