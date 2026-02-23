using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Exercitus.Dux {
    internal sealed class LegatusIndexusPrincipalis : ILegatus, ILegatusIncipabilis, ILegatusLiberabilis {
        private readonly ITurrisMundus _turrisMundus;
        private readonly IVelumIndexusPrincipalis _velumIndexusPrincipalis;
        private readonly IVelumSalsamenti _velumSalsamenti;
        private readonly ITurrisSalsamenti _turrisSalsamenti;

        private readonly CancellationTokenSource _cancellationTokenSource;

        // Dux -> Velumへのコールバック
        private Action _aeAdPremereLudusNovus;
        private Action _aeAdPremerePergeLudum;
        private Action _aeAdPremereOneraLudum;
        private Action _aeAdPremereOptiones;
        private Action _aeAdPremereExi;

        public LegatusIndexusPrincipalis(
            ITurrisMundus turrisMundus,
            IVelumIndexusPrincipalis velumIndexusPrincipalis,
            IVelumSalsamenti velumSalsamenti,
            ITurrisSalsamenti turrisSalsamenti
        ) {
            _turrisMundus = turrisMundus;
            _velumIndexusPrincipalis = velumIndexusPrincipalis;
            _velumSalsamenti = velumSalsamenti;
            _turrisSalsamenti = turrisSalsamenti;

            _aeAdPremereLudusNovus = AdPremereLudusNovus;
            _aeAdPremerePergeLudum = AdPremerePergeLudum;
            _aeAdPremereOneraLudum = AdPremereOneraLudum;
            _aeAdPremereOptiones = AdPremereOptiones;
            _aeAdPremereExi = AdPremereExi;

            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Incipere() {
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
                if (longitudoManualis <= 0 && longitudoAutomaticus <= 0) {
                    _velumIndexusPrincipalis.DeactivateButton(ButtonIndexusPrincipalis.OneraLudum);
                }

                // 最新セーブデータが無ければContinueを無効化。
                if (!estNovissimus) {
                    _velumIndexusPrincipalis.DeactivateButton(ButtonIndexusPrincipalis.PergeLudum);
                }
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        private void AdPremereLudusNovus() {
            _ = LudusNovus();
        }

        private async Task LudusNovus() {
            try {
                _ = await _turrisSalsamenti.Creare(_cancellationTokenSource.Token);
                _turrisMundus.AdMudum(IDMundi.MundusTestScene);
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        private void AdPremerePergeLudum() {
            _ = PergeLudum();
        }

        private async Task PergeLudum() {
            try {
                _ = await _turrisSalsamenti.ArcessereNovissimus(_cancellationTokenSource.Token);
                _turrisMundus.AdMudum(IDMundi.MundusTestScene);
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        private void AdPremereOneraLudum() {
            //Salsamentumを開く。
            _velumSalsamenti.DemittereSalsamenti();
        }

        private void AdPremereOptiones() {
            Notarius.Memorare("未実装: PostulareOptiones");
        }

        private void AdPremereExi() {
            Notarius.Memorare("未実装: PostulareExi");
        }

        public void Liberare() {
            _cancellationTokenSource.Cancel();
        }
    }
}