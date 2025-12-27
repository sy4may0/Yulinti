using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MachinaPuellaeStatuumCorporis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly IStatusPuellaeCorporis2[] _statuum;
        private readonly ResolutorPuellaeRamorumCorporis _resolutorRamorumCorporis;

        private IStatusPuellaeCorporis2 _statusCorporisActualis;
        private IDPuellaeStatusCorporis _idStatusActualis;
        private IDPuellaeStatusCorporis _idStatusProximus;

        private Action _adMutareStatus;

        public IDPuellaeStatusCorporis IdStatusActualis => _statusCorporisActualis.Id;

        public MachinaPuellaeStatuumCorporis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IOstiumPuellaeAnimationesMutabile osAnimationes
        ) {
            _statuum = InitiareStatuum(
                _contextusOstiorum.Configuratio.Statuum,
                _contextusOstiorum.Configuratio.Statuum.StatuumCorporis,
                osAnimationes
            );
            _resolutorRamorumCorporis = new ResolutorPuellaeRamorumCorporis();

            _statusCorporisActualis = _statuum[(int)IDPuellaeStatusCorporis.Quies];
            _idStatusActualis = IDPuellaeStatusCorporis.Quies;
            _idStatusProximus = IDPuellaeStatusCorporis.None;

            _adMutareStatus = AdMutareStatus;
        }
        
        private IStatusPuellaeCorporis2[] InitiareStatuum(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporis2[] configurationemCorporis,
            IOstiumPuellaeAnimationesMutabile osAnimationes
        ) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeStatusCorporis)).Length;
            IStatusPuellaeCorporis2[] statuum = new IStatusPuellaeCorporis2[longitudo];

            foreach (var conf in configurationemCorporis) {
                _statuum[(int)conf.Id] = FabricaStatusPuellaeCorporis.Creare(
                    configuratioStatuum,
                    conf,
                    osAnimationes
                );
            }

            foreach (IDPuellaeStatusCorporis id in Enum.GetValues(typeof(IDPuellaeStatusCorporis))) {
                if (id != IDPuellaeStatusCorporis.None && _statuum[(int)id] == null) {
                    Errorum.Fatal(IDErrorum.MACHINAPUELLAESTATUUMCORPORIS_STATUS_MISSING);
                }
            }
            return statuum;
        }

        public OrdinatioPuellaeActionis OrdinareActionis(
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            OrdinatioPuellaeActionis ordinatio = _statusCorporisActualis.OrdinareActionis(_contextusOstiorum, contextusResFluida);
            return ordinatio;
        }

        public OrdinatioPuellaeVeletudinis OrdinareVeletudinis(
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            OrdinatioPuellaeVeletudinis ordinatio = _statusCorporisActualis.OrdinareVeletudinis(_contextusOstiorum, contextusResFluida);
            return ordinatio;
        }

        public void MutareStatus(
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            IDPuellaeStatusCorporis idStatusProximus = _resolutorRamorumCorporis.Resolvere(
                _idStatusActualis,
                _contextusOstiorum,
                contextusResFluida
            );
            if (idStatusProximus == IDPuellaeStatusCorporis.None) return;

            _idStatusProximus = idStatusProximus;
            _statusCorporisActualis.Exire(_contextusOstiorum, contextusResFluida, null);
            _statuum[(int)_idStatusProximus].Intrare(_contextusOstiorum, contextusResFluida, _adMutareStatus);
        }

        private void AdMutareStatus() {
            _idStatusActualis = _idStatusProximus;
            _idStatusProximus = IDPuellaeStatusCorporis.None;
            _statusCorporisActualis = _statuum[(int)_idStatusActualis];
        }
    }
}