using Yulinti.Dux.ContractusDucis;
namespace Yulinti.Dux.Exercitus {
    internal static class CondicioCivisNavmesh {
        public static bool EstAdPerveni(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            ContextusCivisResFluidaLegibile contextusResFluida
        ) {
            int idCivis = contextusResFluida.IDCivis;
            IOstiumCivisLociNavmeshLegibile civisLoci = 
                contextusOstiorum.CivisLoci;

            return civisLoci.EstAdPerveni(idCivis);
        }
    }
}