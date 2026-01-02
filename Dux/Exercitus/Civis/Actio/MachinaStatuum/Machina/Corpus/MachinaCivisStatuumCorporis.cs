using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MachinaCivisStatuumCorporis {
        private readonly int _idCivis;
        private readonly ContextusCivisOstiorumLegibile _contextusOstiorum;
        private readonly IStatusCivisCorporis[] _statuum;
        private readonly ResolutorCivisRamorumCorporis _resolutorRamorumCorporis;
        private readonly Action _adMutareStatus;

        private IStatusCivisCorporis _statusCorporisActualis;
        private IDCivisStatusCorporis _idStatusActualis;
        private IDCivisStatusCorporis _idStatusProximus;

        public IDCivisStatusCorporis IdStatusActualis => _statusCorporisActualis.Id;

        public MachinaCivisStatuumCorporis(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum
        ) {
            _idCivis = idCivis;
            _contextusOstiorum = contextusOstiorum;
            _statuum = InitiareStatuum(
                _contextusOstiorum.Configuratio.Statuum,
                _contextusOstiorum.Configuratio.Statuum.StatuumCorporis
            );
            _resolutorRamorumCorporis = new ResolutorCivisRamorumCorporis(
                _contextusOstiorum
            );

            _statusCorporisActualis = _statuum[(int)IDCivisStatusCorporis.Nativitas];
            _idStatusActualis = IDCivisStatusCorporis.Nativitas;
            _idStatusProximus = IDCivisStatusCorporis.None;

            _adMutareStatus = AdMutareStatus;
        }

        private IStatusCivisCorporis[] InitiareStatuum(
            IConfiguratioCivisStatuum configuratioStatuum,
            IConfiguratioCivisStatusCorporis[] configurationemCorporis
        ) {
            int longitudo = Enum.GetValues(typeof(IDCivisStatusCorporis)).Length;
            IStatusCivisCorporis[] statuum = new IStatusCivisCorporis[longitudo];

            foreach (var conf in configurationemCorporis) {
                statuum[(int)conf.Id] = FabricaStatusCivisCorporis.Creare(
                    configuratioStatuum,
                    conf
                );
            }
            // Nativitas/Suicidiumは特別扱いなので、ここで初期化。
            statuum[(int)IDCivisStatusCorporis.Nativitas] = new StatusCivisCorporisNativitas();
            statuum[(int)IDCivisStatusCorporis.Suicidium] = new StatusCivisCorporisSuicidium();

            foreach (IDCivisStatusCorporis id in Enum.GetValues(typeof(IDCivisStatusCorporis))) {
                if (id != IDCivisStatusCorporis.None && statuum[(int)id] == null) {
                    Errorum.Fatal(IDErrorum.MACHINACIVISSTATUUMCORPORIS_STATUS_MISSING);
                }
            }
            return statuum;
        }

        // Dominare後に初期化しろ。
        public void Initare() {
            _statusCorporisActualis = _statuum[(int)IDCivisStatusCorporis.Nativitas];
            _idStatusActualis = IDCivisStatusCorporis.Nativitas;
            _idStatusProximus = IDCivisStatusCorporis.None;
        }

        public OrdinatioCivisActionis OrdinareActionis(
            IResFluidaCivisLegibile resFluida
        ) {
            OrdinatioCivisActionis ordinatio = 
                _statusCorporisActualis.OrdinareActionis(_idCivis, _contextusOstiorum, resFluida);
            return ordinatio;
        }

        public OrdinatioCivisVeletudinis OrdinareVeletudinis(
            IResFluidaCivisLegibile resFluida
        ) {
            OrdinatioCivisVeletudinis ordinatio = 
                _statusCorporisActualis.OrdinareVeletudinis(_idCivis, _contextusOstiorum, resFluida);
            return ordinatio;
        }

        public void MutareStatus(
            IResFluidaCivisLegibile resFluida,
            in MotorCivisAnimationis motorAnimationis
        ) {
            IDCivisStatusCorporis idStatusProximus = _resolutorRamorumCorporis.Resolvere(
                _idStatusActualis,
                _idCivis,
                resFluida
            );
            if (idStatusProximus == IDCivisStatusCorporis.None) return;

            _idStatusProximus = idStatusProximus;
            OrdinatioCivisAnimationis ordinatioExire = 
                _statusCorporisActualis.Exire(_idCivis, _contextusOstiorum, resFluida, null);
            OrdinatioCivisAnimationis ordinatioIntrare = 
                _statuum[(int)_idStatusProximus].Intrare(_idCivis, _contextusOstiorum, resFluida, _adMutareStatus);
            
            if (ordinatioExire.EstApplicandum) {
                motorAnimationis.ApplicareAnimationis(ordinatioExire);
            }
            if (ordinatioIntrare.EstApplicandum) {
                motorAnimationis.ApplicareAnimationis(ordinatioIntrare);
            }
        }

        private void AdMutareStatus() {
            _idStatusActualis = _idStatusProximus;
            _idStatusProximus = IDCivisStatusCorporis.None;
            _statusCorporisActualis = _statuum[(int)_idStatusActualis];
        }
    }
}