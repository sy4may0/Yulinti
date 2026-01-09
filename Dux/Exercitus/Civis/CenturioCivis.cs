using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class CenturioCivis : ICenturio, ICenturioPulsabilis, ICenturioPulsabilisFixus, ICenturioPulsabilisTardus {
        private readonly ContextusCivisOstiorumLegibile _contextus;
        private readonly MilesCivisVeletudinis _milesCivisVeletudinis;
        private readonly MilesCivisActionis _milesCivisActionis;
        private readonly MilesCivisCustodiae _milesCivisCustodiae;

        // ResFluida実体
        private readonly ResFluidaCivisMotus _resFluidaMotus;
        private readonly ResFluidaCivisVeletudinis _resFluidaVeletudinis;

        // ResFluidaファサード
        private readonly IResFluidaCivisLegibile _resFluidaLegibile;

        // VContainer注入
        public CenturioCivis(
            MilesCivisVeletudinis milesCivisVeletudinis,
            MilesCivisActionis milesCivisActionis,
            MilesCivisCustodiae milesCivisCustodiae,
            ResFluidaCivisMotus resFluidaMotus,
            ResFluidaCivisVeletudinis resFluidaVeletudinis,
            IResFluidaCivisLegibile resFluidaLegibile,
            ContextusCivisOstiorumLegibile contextus
        ) {
            _milesCivisVeletudinis = milesCivisVeletudinis;
            _milesCivisActionis = milesCivisActionis;
            _milesCivisCustodiae = milesCivisCustodiae;
            _resFluidaMotus = resFluidaMotus;
            _resFluidaVeletudinis = resFluidaVeletudinis;
            _resFluidaLegibile = resFluidaLegibile;
            _contextus = contextus;

            // 実体化完了時に呼ばれる
            _milesCivisVeletudinis.PonoAdIncarnare(AdIncarnare);
            // 実体化解除完了時に呼ばれる
            _milesCivisVeletudinis.PonoAdSpirituare(AdSpirituare);
        }

        private void AdIncarnare(int idCivis) {
            _resFluidaVeletudinis.Dominare(idCivis);
            _milesCivisVeletudinis.Purgare(idCivis);
            _milesCivisActionis.Purgere(idCivis);
            var (initare, intrareStatus) = _milesCivisActionis.InitareServatum(idCivis, _resFluidaLegibile);
            ResolvereOrdinatio(initare);
            ResolvereOrdinatio(intrareStatus);
        }

        private void AdSpirituare(int idCivis) {
            _resFluidaVeletudinis.Liberare(idCivis);
            _milesCivisVeletudinis.Purgare(idCivis);
            _milesCivisActionis.Purgere(idCivis);
        }

        // !注意
        // 処理対象整理とステートマシンのステート切り替えが同期しないことがある。
        // MutareStatus()がステート遷移要求を返し、アニメーション適用時にコールバックで自身のステートを更新する。
        // このコールバックが呼ばれる前にInitareServatumが実行されるとコールバック実行時にNoneステートに遷移する。
        // この問題はInitareServatumでPurgereを実行することで解決するはずではあるが、確実ではない。
        // したがって、Ordinatio()時に現在StateがnullならNPCをIncarnareする。
        public void Pulsus() {
            // Veletudoキャッシュを初期化
            _milesCivisVeletudinis.InitarePhantasma(_resFluidaVeletudinis);

            // MilesCivisActionisの初期化。処理対象整理
            for (int i = 0; i < _contextus.Civis.Longitudo; i++) {
                if (!_resFluidaVeletudinis.EstDominare(i)) continue;
                // Actionis処理実行
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

                // 視認度を更新
                ResolvereOrdinatio(_milesCivisCustodiae.Ordinare(i, _resFluidaLegibile));
                ResolvereOrdinatio(_milesCivisCustodiae.OrdinareDetectio(i, _resFluidaLegibile));
            }
        }

        public void PulsusFixus() {
            // Raycast
            _milesCivisCustodiae.ResolvereIctuum();
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
            if (ordinatio.ConareLegoVeletudinisCustodiae(out OrdinatioCivisVeletudinisCustodiae veletudinisCustodiae)) {
                veletudinisCustodiae.Match(
                    visa: (visa) => {
                        _milesCivisVeletudinis.AddoVisa(ordinatio.IdCivis, visa);
                    },
                    detectio: (detectio) => {
                        _milesCivisVeletudinis.AddDetectio(ordinatio.IdCivis, detectio);
                    }
                );  
            }
        }
    }
}
