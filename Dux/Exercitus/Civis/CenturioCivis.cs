using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class CenturioCivis : ICenturio, ICenturioPulsabilis, ICenturioPulsabilisTardus {
        private readonly ContextusCivisOstiorumLegibile _contextus;
        private readonly MilesCivisVeletudinis _milesCivisVeletudinis;
        private readonly MilesCivisActionis _milesCivisActionis;

        // ResFluida実体
        private readonly ResFluidaCivisMotus _resFluidaMotus;
        private readonly ResFluidaCivisVeletudinis _resFluidaVeletudinis;

        // ResFluidaファサード
        private readonly IResFluidaCivisLegibile _resFluidaLegibile;

        // VContainer注入
        public CenturioCivis(
            MilesCivisVeletudinis milesCivisVeletudinis,
            MilesCivisActionis milesCivisActionis,
            ResFluidaCivisMotus resFluidaMotus,
            ResFluidaCivisVeletudinis resFluidaVeletudinis,
            IResFluidaCivisLegibile resFluidaLegibile,
            ContextusCivisOstiorumLegibile contextus
        ) {
            _milesCivisVeletudinis = milesCivisVeletudinis;
            _milesCivisActionis = milesCivisActionis;
            _resFluidaMotus = resFluidaMotus;
            _resFluidaVeletudinis = resFluidaVeletudinis;
            _resFluidaLegibile = resFluidaLegibile;
            _contextus = contextus;
        }

        public void Pulsus() {
            // Veletudoキャッシュを初期化
            _milesCivisVeletudinis.InitarePhantasma(_resFluidaVeletudinis);
            // Dominate
            _milesCivisVeletudinis.RenovereDomina(_resFluidaVeletudinis);

            // MilesCivisActionisの初期化。処理対象整理
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                if (_resFluidaVeletudinis.EstDominare(i) && !_resFluidaVeletudinis.EstMotus(i)) {
                    var (initare, intrareStatus) = _milesCivisActionis.InitareServatum(i, _resFluidaLegibile);
                    ResolvereOrdinatio(initare);
                    ResolvereOrdinatio(intrareStatus);

                    // EstDominareとEstMotusを同期する。
                    _milesCivisVeletudinis.Servatum(i, _resFluidaVeletudinis);
                }
                if (!_resFluidaVeletudinis.EstDominare(i) && _resFluidaVeletudinis.EstMotus(i)) {
                    // EstDominareとEstMotusを同期する。
                    _milesCivisVeletudinis.LiberareServatum(i, _resFluidaVeletudinis);
                }

                // Actionis処理実行
                if (!_resFluidaVeletudinis.EstDominare(i) || !_resFluidaVeletudinis.EstMotus(i)) continue;

                var (exire, intrare) = _milesCivisActionis.MutareStatus(i, _resFluidaLegibile);
                ResolvereOrdinatio(exire);
                ResolvereOrdinatio(intrare);
                ResolvereOrdinatio(_milesCivisActionis.Ordinare(i, _resFluidaLegibile));

                //ResFluidaMotus更新
                _milesCivisActionis.RenovareResFluidaMotus(i, _resFluidaLegibile, _resFluidaMotus);
                // Animationis更新
                _milesCivisActionis.InjicereVelocitatis(i, _resFluidaLegibile);

                // Navmesh確認(Transporto失敗時に除去)
                ResolvereOrdinatio(_milesCivisActionis.VerificareNavmesh(i));
            }
        }

        public void PulsusTardus() {
            // VeletudoキャッシュをResFluidaに反映
            _milesCivisVeletudinis.Applicare(_resFluidaVeletudinis);
        }

        private void ResolvereOrdinatio(
            OrdinatioCivis ordinatio
        ) {
            if (ordinatio.ConareLegoActionis(out OrdinatioCivisActionis actionis)) {
                _milesCivisActionis.ApplicareActionis(actionis);
            }
            if (ordinatio.ConareLegoAnimationis(out OrdinatioCivisAnimationis animationis)) {
                _milesCivisActionis.ApplicareAnimationis(animationis);
            }
            if (ordinatio.ConareLegoVeletudinisValoris(out OrdinatioCivisVeletudinisValoris veletudinisValoris)) {
                _milesCivisVeletudinis.Addo(veletudinisValoris);
            }
            if (ordinatio.ConareLegoVeletudinisMortis(out OrdinatioCivisVeletudinisMortis veletudinisMortis)) {
                _milesCivisVeletudinis.ApplicareMors(veletudinisMortis, _resFluidaVeletudinis);
            }
        }
    }
}
