using Yulinti.Dux.ContractusDucis;
namespace Yulinti.Dux.Exercitus {
    internal static class CondicioCivisNavmesh {
        public static bool EstAdPerveni(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum
        ) {
            return contextusOstiorum.LociNavmesh.EstAdPerveni(idCivis);
        }
    }
}