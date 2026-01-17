using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MachinaPuellaeStatuumCorporis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly IStatusPuellaeCorporis[] _statuum;
        private readonly ResolutorPuellaeRamorumCorporis _resolutorRamorumCorporis;
        private readonly Action _adMutareStatus;

        private IStatusPuellaeCorporis _statusCorporisActualis;
        private IDPuellaeStatusCorporis _idStatusActualis;
        private IDPuellaeStatusCorporis _idStatusProximus;

        public IDPuellaeStatusCorporis IdStatusActualis => _statusCorporisActualis.Id;

        public MachinaPuellaeStatuumCorporis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _contextusOstiorum = contextusOstiorum;
            _statuum = InitiareStatuum(
                _contextusOstiorum.Configuratio.Statuum,
                _contextusOstiorum.Configuratio.Statuum.StatuumCorporis
            );
            _resolutorRamorumCorporis = new ResolutorPuellaeRamorumCorporis(
                _contextusOstiorum
            );

            _statusCorporisActualis = _statuum[(int)IDPuellaeStatusCorporis.Quies];
            _idStatusActualis = IDPuellaeStatusCorporis.Quies;
            _idStatusProximus = IDPuellaeStatusCorporis.None;

            _adMutareStatus = AdMutareStatus;
        }
        
        private IStatusPuellaeCorporis[] InitiareStatuum(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporis[] configurationemCorporis
        ) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeStatusCorporis)).Length;
            IStatusPuellaeCorporis[] statuum = new IStatusPuellaeCorporis[longitudo];

            foreach (var conf in configurationemCorporis) {
                statuum[(int)conf.Id] = FabricaStatusPuellaeCorporis.Creare(
                    configuratioStatuum,
                    conf
                );
            }

            foreach (IDPuellaeStatusCorporis id in Enum.GetValues(typeof(IDPuellaeStatusCorporis))) {
                if (id != IDPuellaeStatusCorporis.None && statuum[(int)id] == null) {
                    Errorum.Fatal(IDErrorum.MACHINAPUELLAESTATUUMCORPORIS_STATUS_MISSING);
                }
            }
            return statuum;
        }

        public void Initare(IResFluidaPuellaeLegibile resFluida) {
            _statusCorporisActualis = _statuum[(int)IDPuellaeStatusCorporis.Quies];
            _idStatusActualis = IDPuellaeStatusCorporis.Quies;
            _idStatusProximus = IDPuellaeStatusCorporis.None;
            _statusCorporisActualis.Intrare(_contextusOstiorum, resFluida, null);
            // ベースアニメーションを適用
            _contextusOstiorum.Carrus.PostulareAnimationis(
                _contextusOstiorum.Configuratio.Statuum.IdAnimationisPraedefinitus,
                adInitium: null,
                adFinem: null,
                estCogere: true
            );
        }

        public void Ordinare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _statusCorporisActualis.Ordinare(_contextusOstiorum, resFluida);
        }

        public void MutareStatus(
            IResFluidaPuellaeLegibile resFluida
        ) {
            IDPuellaeStatusCorporis idStatusProximus = _resolutorRamorumCorporis.Resolvere(
                _idStatusActualis,
                resFluida
            );
            if (idStatusProximus == IDPuellaeStatusCorporis.None) return;

            _idStatusProximus = idStatusProximus;
            _statusCorporisActualis.Exire(_contextusOstiorum, resFluida, null);
            _statuum[(int)_idStatusProximus].Intrare(_contextusOstiorum, resFluida, _adMutareStatus);
        }

        private void AdMutareStatus() {
            _idStatusActualis = _idStatusProximus;
            _idStatusProximus = IDPuellaeStatusCorporis.None;
            _statusCorporisActualis = _statuum[(int)_idStatusActualis];
        }
    }
}
