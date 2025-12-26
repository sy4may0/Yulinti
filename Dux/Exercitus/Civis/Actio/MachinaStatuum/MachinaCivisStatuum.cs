using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MachinaCivisStatuum {
        private readonly int _idCivis;
        private readonly TabulaCivisStatuumNavmesh _tabulaStatuumNavmesh;
        private readonly ResolutorCivisRamorumNavmesh _resolutorRamorumNavmesh;
        private readonly IOstiumPuellaeAnimationesMutabile _osAnimationes;

        private IStatusCivisNavmesh _statusNavmeshActualis;
        private IDCivisStatusNavmesh _idStatusNavmeshActualis;
        private IDCivisStatusNavmesh _idStatusNavmeshProximus;

        private Action _adMutareStatus;

        public MachinaCivisStatuum(
            int idCivis,
            IConfiguratioCivisStatusNavmesh[] configurationemNavmesh,
            IOstiumCivisAnimationesMutabile osAnimationes,
            IOstiumCivisLociNavmeshLegibile osLociNavmeshLegibile,
            IOstiumCivisLociNavmeshMutabile osLociNavmeshMutabile,
            IOstiumPunctumViaeLegibile osPunctumViaeLegibile,
            ResolutorCivisRamorumNavmesh resolutorRamorumNavmesh
        ) {
            _idCivis = idCivis;
            _tabulaStatuumNavmesh = new TabulaCivisStatuumNavmesh(
                idCivis,
                configurationemNavmesh,
                osAnimationes,
                osLociNavmeshLegibile,
                osLociNavmeshMutabile,
                osPunctumViaeLegibile
            );
            _resolutorRamorumNavmesh = resolutorRamorumNavmesh;
            Initare();
        }

        public void Initare() {
            _statusNavmeshActualis = _tabulaStatuumNavmesh.Lego(IDCivisStatusNavmesh.Nativitas);
            _idStatusNavmeshActualis = IDCivisStatusNavmesh.Nativitas;
            _idStatusNavmeshProximus = IDCivisStatusNavmesh.None;
        }

        public void Opero(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            ContextusCivisResFluidaLegibile contextusResFluida
        ) {
            MutareStatus(contextusOstiorum, contextusResFluida);
        }

        public void InjicereVelocitatem(float velocitas) {
            _osAnimationes.InjicereVelocitatem(velocitas);
        }

        private void MutareStatus(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            ContextusCivisResFluidaLegibile contextusResFluida
        ) {
            IDCivisStatusNavmesh idStatusNavmeshProximus = _resolutorRamorumNavmesh.Resolvere(
                _idStatusNavmeshActualis,
                contextusOstiorum,
                contextusResFluida
            );
            if (idStatusNavmeshProximus == IDCivisStatusNavmesh.None) return;

            _idStatusNavmeshProximus = idStatusNavmeshProximus;
            _statusNavmeshActualis.Exire(contextusResFluida, null);
            _tabulaStatuumNavmesh.Lego(_idStatusNavmeshProximus).Intrare(contextusResFluida, _adMutareStatus);
            return;
        }

        private void AdMutareStatus() {
            _idStatusNavmeshActualis = _idStatusNavmeshProximus;
            _idStatusNavmeshProximus = IDCivisStatusNavmesh.None;
            _statusNavmeshActualis = _tabulaStatuumNavmesh.Lego(_idStatusNavmeshActualis);
        }
    }
}