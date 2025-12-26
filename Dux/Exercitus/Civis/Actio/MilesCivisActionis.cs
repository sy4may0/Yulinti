using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesCivisActionis : IMilesCivisActionis {
        private readonly MachinaCivisStatuum _machinaCivisStatuum;

        // VContainer注入
        public MilesCivisActionis(
            int idCivis,
            IConfiguratioCivisStatusNavmesh[] configurationemNavmesh,
            IOstiumCivisAnimationesMutabile osAnimationes,
            IOstiumCivisLociNavmeshLegibile osLociNavmeshLegibile,
            IOstiumCivisLociNavmeshMutabile osLociNavmeshMutabile,
            IOstiumPunctumViaeLegibile osPunctumViaeLegibile,
            ResolutorCivisRamorumNavmesh resolutorRamorumNavmesh
        ) {
            _machinaCivisStatuum = new MachinaCivisStatuum(
                idCivis,
                configurationemNavmesh,
                osAnimationes,
                osLociNavmeshLegibile,
                osLociNavmeshMutabile,
                osPunctumViaeLegibile,
                resolutorRamorumNavmesh
            );
        }

        public void Opero(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            ContextusCivisResFluidaLegibile contextusResFluida
        ) {
            _machinaCivisStatuum.Opero(
                contextusOstiorum,
                contextusResFluida
            );
        }

        public void RenovareResFluida(ref ResFluidaCivis resFluida) {
            // resFluidaを更新
        }
    }
}