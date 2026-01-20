using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
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

        // Incarnare後に必ず実行。
        public void Initare(
            IResFluidaCivisLegibile resFluida
        ) {
            _statusCorporisActualis = _statuum[(int)IDCivisStatusCorporis.MigrareAditorium];
            _idStatusActualis = IDCivisStatusCorporis.MigrareAditorium;
            _idStatusProximus = IDCivisStatusCorporis.None;

            // ランダムにNatorium地点を取得してTransporto要求を生成
            ErrorAut<IPunctumViaeLegibile> punctumViae = _contextusOstiorum.PunctumViae.LegoNatoriumTemere();

            if (punctumViae.EstError()) {
                _contextusOstiorum.Carrus.PostulareMortis(
                    _idCivis,
                    SpeciesOrdinationisCivisMortis.Spirituare
                );
                return;
            }

            _contextusOstiorum.Carrus.PostulareNavmesh(
                _idCivis,
                punctumViae.Evolvo().Positio,
                true,
                0f, 0f, 0, 0f
            );
            // 初期ステートのIntrareを実行。
            _statusCorporisActualis.Intrare(_idCivis, _contextusOstiorum, resFluida, null);
        }

        public void Ordinare(
            IResFluidaCivisLegibile resFluida
        ) {
            if (_statusCorporisActualis == null) {
                _contextusOstiorum.Carrus.PostulareMortis(
                    _idCivis,
                    SpeciesOrdinationisCivisMortis.Spirituare
                );
                return;
            }
            _statusCorporisActualis.Ordinare(_idCivis, _contextusOstiorum, resFluida);
        }

        public void MutareStatus(
            IResFluidaCivisLegibile resFluida
        ) {
            IDCivisStatusCorporis idStatusProximus = _resolutorRamorumCorporis.Resolvere(
                _idStatusActualis,
                _idCivis,
                resFluida
            );
            if (idStatusProximus == IDCivisStatusCorporis.None) return;

            _idStatusProximus = idStatusProximus;

            _statusCorporisActualis.Exire(_idCivis, _contextusOstiorum, resFluida, null);
            _statuum[(int)_idStatusProximus].Intrare(_idCivis, _contextusOstiorum, resFluida, _adMutareStatus);
        }

        private void AdMutareStatus() {
            // フォローバック: _idStatusProximusがNoneの場合は処理をスキップ
            if (_idStatusProximus == IDCivisStatusCorporis.None) {
                return;
            }
            _idStatusActualis = _idStatusProximus;
            _idStatusProximus = IDCivisStatusCorporis.None;
            _statusCorporisActualis = _statuum[(int)_idStatusActualis];
            // フォローバック: _statusCorporisActualisがnullの場合はNoneにリセット
            if (_statusCorporisActualis == null) {
                _idStatusActualis = IDCivisStatusCorporis.None;
            }
        }
    }
}