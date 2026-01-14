using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class CenturioPuellae : ICenturio, ICenturioPulsabilis, ICenturioPulsabilisTardus {
        private readonly MilesPuellaeActionis _milesPuellaeActionis;
        private readonly MilesPuellaeCrinis _milesPuellaeCrinis;
        private readonly MilesPuellaeFigurae _milesPuellaeFigurae;

        // ResFluidaファサード
        private readonly IResFluidaPuellaeLegibile _resFluidaLegibile;

        // VContainer注入
        public CenturioPuellae(
            MilesPuellaeActionis milesPuellaeActionis,
            MilesPuellaeCrinis milesPuellaeCrinis,
            MilesPuellaeFigurae milesPuellaeFigurae,
            IResFluidaPuellaeLegibile resFluidaLegibile
        ) {
            _milesPuellaeActionis = milesPuellaeActionis;
            _milesPuellaeCrinis = milesPuellaeCrinis;
            _milesPuellaeFigurae = milesPuellaeFigurae;
            _resFluidaLegibile = resFluidaLegibile;
        }

        public void Pulsus() {
            // Actioループ
            _milesPuellaeActionis.MutareStatus(_resFluidaLegibile);

            // Navmeshチェック / 失敗時はAnimetion初期化、初期ステート遷移(MachinaPuellaeStatuumCorporis.Initare())
            _milesPuellaeActionis.ValidereNavmesh(_resFluidaLegibile);
            _milesPuellaeActionis.Ordinare(_resFluidaLegibile);

            // ResFluidaMotusを更新
            _milesPuellaeActionis.RenovareResFluidaMotus(in _resFluidaMotus);
            // Animation速度を更新
            _milesPuellaeActionis.InjicereVelocitatis(_resFluidaLegibile);
        }

        public void PulsusTardus() {
            // BlendShape適用
            _milesPuellaeFigurae.ApplicareFiguram();
            
        }

    }
}
