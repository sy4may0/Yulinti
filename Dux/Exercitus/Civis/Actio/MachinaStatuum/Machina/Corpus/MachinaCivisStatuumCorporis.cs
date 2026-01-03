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

            _statusCorporisActualis = _statuum[(int)IDCivisStatusCorporis.None];
            _idStatusActualis = IDCivisStatusCorporis.None;
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
            // Suicidiumは特別扱いなので、ここで初期化。
            statuum[(int)IDCivisStatusCorporis.Suicidium] = new StatusCivisCorporisSuicidium();

            foreach (IDCivisStatusCorporis id in Enum.GetValues(typeof(IDCivisStatusCorporis))) {
                if (id != IDCivisStatusCorporis.None && statuum[(int)id] == null) {
                    Errorum.Fatal(IDErrorum.MACHINACIVISSTATUUMCORPORIS_STATUS_MISSING);
                }
            }
            return statuum;
        }

        // Dominare後に初期化しろ。
        public (OrdinatioCivis Initare, OrdinatioCivis IntrareStatus) Initare(
            IResFluidaCivisLegibile resFluida
        ) {
            _statusCorporisActualis = _statuum[(int)IDCivisStatusCorporis.MigrareAditorium];
            _idStatusActualis = IDCivisStatusCorporis.MigrareAditorium;
            _idStatusProximus = IDCivisStatusCorporis.None;

            // ランダムにNatorium地点を取得してTransporto要求を生成
            ErrorAut<IPunctumViaeLegibile> punctumViae = _contextusOstiorum.PunctumViae.LegoNatoriumTemere();

            if (punctumViae.EstError()) {
                OrdinatioCivisVeletudinisMortis mortis = new OrdinatioCivisVeletudinisMortis(
                    _idCivis, estSpirituare: true
                );
                return (new OrdinatioCivis(
                    _idCivis, veletudinisMortis: mortis
                ), OrdinatioCivis.Nihil(_idCivis));
            }
            OrdinatioCivisInitareNavmesh initareNavmesh = new OrdinatioCivisInitareNavmesh(
                punctumViae.Evolvo().Positio
            );
            OrdinatioCivis Initare = new OrdinatioCivis(
                _idCivis, actionis: OrdinatioCivisActionis.FromInitareNavmesh(_idCivis, initareNavmesh)
            );

            // 初期ステートのIntrareを実行
            OrdinatioCivis IntrareStatus = _statusCorporisActualis.Intrare(_idCivis, _contextusOstiorum, resFluida, null);

            return (Initare, IntrareStatus);
        }

        public OrdinatioCivis Ordinare(
            IResFluidaCivisLegibile resFluida
        ) {
            return _statusCorporisActualis.Ordinare(_idCivis, _contextusOstiorum, resFluida);
        }

        public (OrdinatioCivis Exire, OrdinatioCivis Intrare) MutareStatus(
            IResFluidaCivisLegibile resFluida
        ) {
            IDCivisStatusCorporis idStatusProximus = _resolutorRamorumCorporis.Resolvere(
                _idStatusActualis,
                _idCivis,
                resFluida
            );
            if (idStatusProximus == IDCivisStatusCorporis.None) { 
                return (OrdinatioCivis.Nihil(_idCivis), OrdinatioCivis.Nihil(_idCivis));
            }

            _idStatusProximus = idStatusProximus;
            OrdinatioCivis exire = 
                _statusCorporisActualis.Exire(_idCivis, _contextusOstiorum, resFluida, null);
            OrdinatioCivis intrare = 
                _statuum[(int)_idStatusProximus].Intrare(_idCivis, _contextusOstiorum, resFluida, _adMutareStatus);

            return (exire, intrare);
        }

        private void AdMutareStatus() {
            _idStatusActualis = _idStatusProximus;
            _idStatusProximus = IDCivisStatusCorporis.None;
            _statusCorporisActualis = _statuum[(int)_idStatusActualis];
        }
    }
}