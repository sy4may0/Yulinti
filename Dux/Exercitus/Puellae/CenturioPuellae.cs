using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class CenturioPuellae : ICenturio, ICenturioPulsabilis, ICenturioPulsabilisTardus {
        private readonly MilesPuellaeActionis _milesPuellaeActionis;
        private readonly MilesPuellaeVeletudinis _milesPuellaeVeletudinis;
        private readonly MilesPuellaeCrinis _milesPuellaeCrinis;
        private readonly MilesPuellaeFigurae _milesPuellaeFigurae;

        // ResFluida実体
        private readonly ResFluidaPuellaeMotus _resFluidaMotus;
        private readonly ResFluidaPuellaeVeletudinis _resFluidaVeletudinis;

        // ResFluidaファサード
        private readonly IResFluidaPuellaeLegibile _resFluidaLegibile;

        // VContainer注入
        public CenturioPuellae(
            MilesPuellaeVeletudinis milesPuellaeVeletudinis,
            MilesPuellaeActionis milesPuellaeActionis,
            MilesPuellaeCrinis milesPuellaeCrinis,
            MilesPuellaeFigurae milesPuellaeFigurae,
            ResFluidaPuellaeMotus resFluidaMotus,
            ResFluidaPuellaeVeletudinis resFluidaVeletudinis,
            IResFluidaPuellaeLegibile resFluidaLegibile
        ) {
            _milesPuellaeActionis = milesPuellaeActionis;
            _milesPuellaeVeletudinis = milesPuellaeVeletudinis;
            _milesPuellaeCrinis = milesPuellaeCrinis;
            _milesPuellaeFigurae = milesPuellaeFigurae;
            _resFluidaMotus = resFluidaMotus;
            _resFluidaVeletudinis = resFluidaVeletudinis;
            _resFluidaLegibile = resFluidaLegibile;
        }

        public void Pulsus() {
            // Veletudoキャッシュを初期化
            _milesPuellaeVeletudinis.InitarePhantasma(in _resFluidaVeletudinis);

            // Actioループ
            _milesPuellaeActionis.MutareStatus(_resFluidaLegibile);
            _milesPuellaeActionis.OrdinareActionis(_resFluidaLegibile);
            _milesPuellaeActionis.ApplicareActionis(_resFluidaLegibile);

            // Veletudo加算値を反映
            _milesPuellaeVeletudinis.Resolvere(
                _milesPuellaeActionis.OrdinareVeletudinis(_resFluidaLegibile)
            );

            // ResFluidaMotusを更新
            _milesPuellaeActionis.RenovareResFluidaMotus(in _resFluidaMotus);
            // Animation速度を更新
            _milesPuellaeActionis.InjicereVelocitatis(_resFluidaLegibile);
        }

        public void PulsusTardus() {
            // VeletudoキャッシュをResFluidaに反映
            _milesPuellaeVeletudinis.Applicare(in _resFluidaVeletudinis);

            // BlendShape適用
            _milesPuellaeFigurae.ApplicareFiguram();
            
        }

    }
}
