using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class PraecoIndexusPrincipalis : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis {
        private readonly ITurrisMundus _turrisMundus;
        private readonly IVelumIndexusPrincipalis _velumIndexusPrincipalis;
        private readonly IPraecoConfirmationis _legatusConfirmationis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSalsamenti _turrisSalsamenti;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private readonly CuratorVela _curatorVela;

        // 下位Praeco
        private readonly PraecoSalsamenti _legatusSalsamenti;

        private readonly CancellationTokenSource _cancellationTokenSource;

        // Dux -> Velumへのコールバック
        private Action _aeAdPremereLudusNovus;
        private Action _aeAdPremerePergeLudum;
        private Action _aeAdPremereOneraLudum;
        private Action _aeAdPremereOptiones;
        private Action _aeAdPremereExi;

        // PraecoSalsamentiのDemittereへのコールバック
        private Action _aeAdReditumSalsamenti;

        private bool _potestPergeLudum;
        private bool _potestOneraLudum;
        private bool _estProcessusButton;

        public PraecoIndexusPrincipalis(
            ITurrisMundus turrisMundus,
            IVelumIndexusPrincipalis velumIndexusPrincipalis,
            ITurrisSoniVeli turrisSoniVeli,
            ITurrisInterpretationis turrisInterpretationis,
            ITurrisSalsamenti turrisSalsamenti,
            IPraecoConfirmationis legatusConfirmationis,
            PraecoSalsamenti legatusSalsamenti,
            CuratorVela curatorVela
        ) {
            _turrisMundus = turrisMundus;
            _velumIndexusPrincipalis = velumIndexusPrincipalis;
            _turrisSoniVeli = turrisSoniVeli;
            _turrisInterpretationis = turrisInterpretationis;
            _turrisSalsamenti = turrisSalsamenti;
            _legatusConfirmationis = legatusConfirmationis;
            _legatusSalsamenti = legatusSalsamenti;
            _curatorVela = curatorVela;

            _aeAdPremereLudusNovus = AdPremereLudusNovus;
            _aeAdPremerePergeLudum = AdPremerePergeLudum;
            _aeAdPremereOneraLudum = AdPremereOneraLudum;
            _aeAdPremereOptiones = AdPremereOptiones;
            _aeAdPremereExi = AdPremereExi;

            _aeAdReditumSalsamenti = AdReditumSalsamenti;

            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Incipere() {
            _velumIndexusPrincipalis.Initare();
            // Fire-and-forget。Task.Runは使わない＝呼び出し元（Unityメインスレッド）のコンテキストで継続が動くようにする。
            _ = Demittere();
        }


        private async Task Demittere() {
            // ここがasync起点。try/catchで囲う。
            try {
                // LongitudoとNovissimusを取得。
                int longitudoManualis = await _turrisSalsamenti.LongitudoManualis(_cancellationTokenSource.Token);
                int longitudoAutomaticus = await _turrisSalsamenti.LongitudoAutomaticus(_cancellationTokenSource.Token);
                bool estNovissimus = await _turrisSalsamenti.EstNovissimus(_cancellationTokenSource.Token);

                // UIを表示
                _velumIndexusPrincipalis.DemittereIndexusPrincipalis();

                _velumIndexusPrincipalis.AdPremereLudusNovus(_aeAdPremereLudusNovus);
                _velumIndexusPrincipalis.AdPremerePergeLudum(_aeAdPremerePergeLudum);
                _velumIndexusPrincipalis.AdPremereOneraLudum(_aeAdPremereOneraLudum);
                _velumIndexusPrincipalis.AdPremereOptiones(_aeAdPremereOptiones);
                _velumIndexusPrincipalis.AdPremereExi(_aeAdPremereExi);

                // データが無ければロードボタンを無効。
                _potestOneraLudum = longitudoManualis > 0 || longitudoAutomaticus > 0;

                // 最新セーブデータが無ければContinueを無効化。
                _potestPergeLudum = estNovissimus;
                ApplicareStatusButton();
            // これをキャンセルは異常のため、OperationCanceledExceptionはCarnifexで落とす。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        // SalsamentiからCancelでタイトルに戻った際に実行する関数。
        private void AdReditumSalsamenti() {
            _ = ReditumSalsamenti();
        }

        // Salsamentiでセーブデータが更新されるため、ボタンの状態を更新する。
        private async Task ReditumSalsamenti() {
            try {
                // LongitudoとNovissimusを取得。
                int longitudoManualis = await _turrisSalsamenti.LongitudoManualis(_cancellationTokenSource.Token);
                int longitudoAutomaticus = await _turrisSalsamenti.LongitudoAutomaticus(_cancellationTokenSource.Token);
                bool estNovissimus = await _turrisSalsamenti.EstNovissimus(_cancellationTokenSource.Token);

                // データが無ければロードボタンを無効。
                _potestOneraLudum = longitudoManualis > 0 || longitudoAutomaticus > 0;

                // 最新セーブデータが無ければContinueを無効化。
                _potestPergeLudum = estNovissimus;
                ApplicareStatusButton();
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        private void AdPremereLudusNovus() {
            _ = PremereLudusNovus();
        }

        private async Task PremereLudusNovus() {
            if (!ConariIncipereProcessumButton()) {
                return;
            }
            try {
                bool estConfirmationis = await _legatusConfirmationis.DemittereAsync(
                    _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_TITULUS),
                    _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_TEXTUS),
                    _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_BUTTON_ITA),
                    _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_BUTTON_NON),
                    null,
                    null,
                    IDSonusVeli.SubmittereAdditum,
                    IDSonusVeli.Exire,
                    _cancellationTokenSource.Token
                );

                if (!estConfirmationis) {
                    return;
                }

                _ = await _turrisSalsamenti.Creare(_cancellationTokenSource.Token);
                // UIを消す
                _curatorVela.TollereVelaOmnium();
                _turrisMundus.AdMudum(IDMundi.MundusPortus);
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                FinireProcessumButton();
            }
        }

        private void AdPremerePergeLudum() {
            _ = PremerePergeLudum();
        }

        private async Task PremerePergeLudum() {
            if (!ConariIncipereProcessumButton()) {
                return;
            }
            try {
                _ = await _turrisSalsamenti.ArcessereNovissimus(_cancellationTokenSource.Token);
                _turrisSoniVeli.Sonare(IDSonusVeli.SubmittereAdditum);
                _curatorVela.TollereVelaOmnium();
                _turrisMundus.AdMudum(IDMundi.MundusPortus);
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                FinireProcessumButton();
            }
        }

        private void AdPremereOneraLudum() {
            _ = PremereOneraLudum();
        }

        private async Task PremereOneraLudum() {
            if (!ConariIncipereProcessumButton()) {
                return;
            }
            try {
                //Salsamentumを開く。
                await _legatusSalsamenti.Demittere(_aeAdReditumSalsamenti);
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                FinireProcessumButton();
            }
        }

        private void AdPremereOptiones() {
            PremereOptiones();
        }

        private void PremereOptiones() {
            if (!ConariIncipereProcessumButton()) {
                return;
            }
            try {
                Notarius.Memorare("未実装: PostulareOptiones");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                FinireProcessumButton();
            }
        }

        private void AdPremereExi() {
            PremereExi();
        }

        private void PremereExi() {
            if (!ConariIncipereProcessumButton()) {
                return;
            }
            try {
                Notarius.Memorare("未実装: PostulareExi");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                FinireProcessumButton();
            }
        }

        public void Liberare() {
            _cancellationTokenSource.Cancel();
        }

        // ボタンの処理を開始する。
        // 処理中の場合は全ボタンを非活性化する。
        private bool ConariIncipereProcessumButton() {
            if (_estProcessusButton) {
                return false;
            }
            _estProcessusButton = true;
            DeactivareButtons();
            return true;
        }

        private void FinireProcessumButton() {
            ApplicareStatusButton();
            _estProcessusButton = false;
        }

        // ボタンの状態を反映する。
        private void ApplicareStatusButton() {
            ActivareButtons();
            if (!_potestPergeLudum) {
                _velumIndexusPrincipalis.DeactivareButton(ButtonIndexusPrincipalis.PergeLudum);
            }
            if (!_potestOneraLudum) {
                _velumIndexusPrincipalis.DeactivareButton(ButtonIndexusPrincipalis.OneraLudum);
            }
        }

        private void ActivareButtons() {
            _velumIndexusPrincipalis.ActivareButton(ButtonIndexusPrincipalis.LudusNovus);
            _velumIndexusPrincipalis.ActivareButton(ButtonIndexusPrincipalis.PergeLudum);
            _velumIndexusPrincipalis.ActivareButton(ButtonIndexusPrincipalis.OneraLudum);
            _velumIndexusPrincipalis.ActivareButton(ButtonIndexusPrincipalis.Optiones);
            _velumIndexusPrincipalis.ActivareButton(ButtonIndexusPrincipalis.Exi);
        }

        private void DeactivareButtons() {
            _velumIndexusPrincipalis.DeactivareButton(ButtonIndexusPrincipalis.LudusNovus);
            _velumIndexusPrincipalis.DeactivareButton(ButtonIndexusPrincipalis.PergeLudum);
            _velumIndexusPrincipalis.DeactivareButton(ButtonIndexusPrincipalis.OneraLudum);
            _velumIndexusPrincipalis.DeactivareButton(ButtonIndexusPrincipalis.Optiones);
            _velumIndexusPrincipalis.DeactivareButton(ButtonIndexusPrincipalis.Exi);
        }
    }
}
