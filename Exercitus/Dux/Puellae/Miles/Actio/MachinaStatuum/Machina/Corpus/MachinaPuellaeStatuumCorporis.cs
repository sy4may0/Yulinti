using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using System;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Exercitus.Dux {
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

            // 初期ステートを設定
            _statusCorporisActualis = _statuum[
                (int)_contextusOstiorum.Configuratio.Statuum.IDStatusCorporisIncipalis
            ];
            _idStatusActualis = _contextusOstiorum.Configuratio.Statuum.IDStatusCorporisIncipalis;
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

            foreach (IConfiguratioPuellaeStatusCorporis conf in configurationemCorporis) {
                int id = (int)conf.Id;
                if (statuum[id] == null) {
                    Carnifex.Intermissio(LogTextus.MachinaPuellaeStatuumCorporis_MACHINAPUELLAESTATUUMCORPORIS_STATUS_MISSING);
                }
            }
            return statuum;
        }

        public void Initare(IResFluidaPuellaeLegibile resFluida) {
            // 初期ステートを設定
            _statusCorporisActualis = _statuum[
                (int)_contextusOstiorum.Configuratio.Statuum.IDStatusCorporisIncipalis
            ];
            _idStatusActualis = _contextusOstiorum.Configuratio.Statuum.IDStatusCorporisIncipalis;
            _idStatusProximus = IDPuellaeStatusCorporis.None;
            _statusCorporisActualis.Intrare(_contextusOstiorum, resFluida, null);
            // ベースアニメーションを適用
            _contextusOstiorum.Carrus.PostulareAnimationis(
                _contextusOstiorum.Configuratio.Statuum.IdAnimationisPraedefinitus,
                adInitium: null,
                adFinem: null,
                estCogere: true
            );
            // 初期地点に移動
            _contextusOstiorum.Carrus.PostulareNavmeshInitii(
                _contextusOstiorum.Configuratio.Statuum.PositioIncipalis,
                _contextusOstiorum.Configuratio.Statuum.RotatioIncipalis
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
            // 次のステートが存在しない場合はエラーを出力して処理をスキップ
            if (_statuum[(int)idStatusProximus] == null) {
                Notarius.Memorare(LogTextus.MachinaPuellaeStatuumCorporis_MACHINAPUELLAESTATUUMCORPORIS_STATUS_MISSING);
                return;
            }

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
