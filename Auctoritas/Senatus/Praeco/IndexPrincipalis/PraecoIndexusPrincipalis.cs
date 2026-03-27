using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

// !!! 必ずセーブデータロード後にAdMundumすること。 !!!
// !!! 遅延ロードは想定しない。 !!!

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoIndexusPrincipalis : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis, IOperatioIndexusPrincipalis {
        private readonly ITurrisMundus _turrisMundus;
        private readonly IVelumIndexusPrincipalis _velumIndexusPrincipalis;
        private readonly IPraecoConfirmationis _legatusConfirmationis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSalsamenti _turrisSalsamenti;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private readonly CuratorVela _curatorVela;

        // 下位Praeco
        private readonly PraecoSalsamenti _legatusSalsamenti;

        private readonly IOstiumSignumCancellationisLegibile _ostiumSignumCancellationisLegibile;

        // PraecoSalsamentiのDemittereへのコールバック
        private Action _aeAdReditumSalsamenti;

        private bool _potestPergeLudum;
        private bool _potestOneraLudum;

        private bool _estActivumUsus;

        public PraecoIndexusPrincipalis(
            ITurrisMundus turrisMundus,
            IVelumIndexusPrincipalis velumIndexusPrincipalis,
            ITurrisSoniVeli turrisSoniVeli,
            ITurrisInterpretationis turrisInterpretationis,
            ITurrisSalsamenti turrisSalsamenti,
            IPraecoConfirmationis legatusConfirmationis,
            PraecoSalsamenti legatusSalsamenti,
            CuratorVela curatorVela,
            IOstiumSignumCancellationisLegibile ostiumSignumCancellationisLegibile
        ) {
            _turrisMundus = turrisMundus;
            _velumIndexusPrincipalis = velumIndexusPrincipalis;
            _turrisSoniVeli = turrisSoniVeli;
            _turrisInterpretationis = turrisInterpretationis;
            _turrisSalsamenti = turrisSalsamenti;
            _legatusConfirmationis = legatusConfirmationis;
            _legatusSalsamenti = legatusSalsamenti;
            _curatorVela = curatorVela;
            _ostiumSignumCancellationisLegibile = ostiumSignumCancellationisLegibile;

            _aeAdReditumSalsamenti = AdReditumSalsamenti;
            _estActivumUsus = true;

        }

        public void Incipere() {
            // Fire-and-forget。Task.Runは使わない＝呼び出し元（Unityメインスレッド）のコンテキストで継続が動くようにする。
            _ = Demittere();
        }


        private async Task Demittere() {
            // ここがasync起点。try/catchで囲う。
            try {
                // LongitudoとNovissimusを取得。
                int longitudoManualis = await _turrisSalsamenti.LongitudoManualis(_ostiumSignumCancellationisLegibile.Signum);
                int longitudoAutomaticus = await _turrisSalsamenti.LongitudoAutomaticus(_ostiumSignumCancellationisLegibile.Signum);
                bool estNovissimus = await _turrisSalsamenti.EstNovissimus(_ostiumSignumCancellationisLegibile.Signum);

                // UIを表示
                _velumIndexusPrincipalis.DemittereIndexusPrincipalis();

                // データが無ければロードボタンを無効。
                _potestOneraLudum = longitudoManualis > 0 || longitudoAutomaticus > 0;

                // 最新セーブデータが無ければContinueを無効化。
                _potestPergeLudum = estNovissimus;
                ApplicareStatusUsus();
                _estActivumUsus = true;
            // これをキャンセルは異常のため、OperationCanceledExceptionはCarnifexで落とす。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        public void Executare(UsusIndexusPrincipalis usus) {
            if (usus == UsusIndexusPrincipalis.LudusNovus) {
                _ = PremereLudusNovus();
            } else if (usus == UsusIndexusPrincipalis.PergeLudum) {
                _ = PremerePergeLudum();
            } else if (usus == UsusIndexusPrincipalis.OneraLudum) {
                _ = PremereOneraLudum();
            } else if (usus == UsusIndexusPrincipalis.Optiones) {
                PremereOptiones();
            } else if (usus == UsusIndexusPrincipalis.Exi) {
                PremereExi();
            }
        }

        // SalsamentiからCancelでタイトルに戻った際に実行する関数。
        private void AdReditumSalsamenti() {
            _ = ReditumSalsamenti();
        }

        // Salsamentiでセーブデータが更新されるため、ボタンの状態を更新する。
        private async Task ReditumSalsamenti() {
            try {
                _estActivumUsus = false;
                // LongitudoとNovissimusを取得。
                int longitudoManualis = await _turrisSalsamenti.LongitudoManualis(_ostiumSignumCancellationisLegibile.Signum);
                int longitudoAutomaticus = await _turrisSalsamenti.LongitudoAutomaticus(_ostiumSignumCancellationisLegibile.Signum);
                bool estNovissimus = await _turrisSalsamenti.EstNovissimus(_ostiumSignumCancellationisLegibile.Signum);

                // データが無ければロードボタンを無効。
                _potestOneraLudum = longitudoManualis > 0 || longitudoAutomaticus > 0;

                // 最新セーブデータが無ければContinueを無効化。
                _potestPergeLudum = estNovissimus;
                ApplicareStatusUsus();
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                _estActivumUsus = true;
            }
        }

        private async Task PremereLudusNovus() {
            try {
                if (!ConareUsus()) {
                    return;
                }
                bool estConfirmationis = await _legatusConfirmationis.DemittereAsync(
                    _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_TITULUS),
                    _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_TEXTUS),
                    _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_BUTTON_ITA),
                    _turrisInterpretationis.LegoTextus(IDTextus.INDEXUS_PRINCIPALIS_LUDUS_NOVUS_BUTTON_NON),
                    null,
                    null,
                    IDSonusVeli.SubmittereAdditum,
                    IDSonusVeli.Exire,
                    _ostiumSignumCancellationisLegibile.Signum
                );

                if (!estConfirmationis) {
                    return;
                }

                _ = await _turrisSalsamenti.Creare(_ostiumSignumCancellationisLegibile.Signum);
                // UIを消す
                _curatorVela.TollereVelaOmnium();
                _turrisMundus.AdMundum(IDMundi.MundusPortus);
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
        }

        private async Task PremerePergeLudum() {
            try {
                if (!ConareUsus()) {
                    return;
                }
                _ = await _turrisSalsamenti.ArcessereNovissimus(_ostiumSignumCancellationisLegibile.Signum);
                _turrisSoniVeli.Sonare(IDSonusVeli.SubmittereAdditum);
                _curatorVela.TollereVelaOmnium();
                _turrisMundus.AdMundum(IDMundi.MundusPortus);
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
        }

        private async Task PremereOneraLudum() {
            try {
                if (!ConareUsus()) {
                    return;
                }
                //Salsamentumを開く。
                await _legatusSalsamenti.Demittere(_aeAdReditumSalsamenti);
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
        }

        private void PremereOptiones() {
            try {
                if (!ConareUsus()) {
                    return;
                }
                Notarius.Memorare("未実装: PostulareOptiones");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
        }

        private void PremereExi() {
            try {
                if (!ConareUsus()) {
                    return;
                }
                Notarius.Memorare("未実装: PostulareExi");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
        }

        private bool ConareUsus() {
            if (!_estActivumUsus) {
                return false;
            }
            _estActivumUsus = false;
            return true;
        }
        private void LiberareUsus() {
            _estActivumUsus = true;
        }

        public void Liberare() { }

        // ボタンの状態を反映する。
        private void ApplicareStatusUsus() {
            _velumIndexusPrincipalis.PonoPermissionemUsus(UsusIndexusPrincipalis.LudusNovus, true);
            _velumIndexusPrincipalis.PonoPermissionemUsus(UsusIndexusPrincipalis.PergeLudum, true);
            _velumIndexusPrincipalis.PonoPermissionemUsus(UsusIndexusPrincipalis.OneraLudum, true);
            _velumIndexusPrincipalis.PonoPermissionemUsus(UsusIndexusPrincipalis.Optiones, true);
            _velumIndexusPrincipalis.PonoPermissionemUsus(UsusIndexusPrincipalis.Exi, true);
            if (!_potestPergeLudum) {
                _velumIndexusPrincipalis.PonoPermissionemUsus(
                    UsusIndexusPrincipalis.PergeLudum, false
                );
            }
            if (!_potestOneraLudum) {
                _velumIndexusPrincipalis.PonoPermissionemUsus(
                    UsusIndexusPrincipalis.OneraLudum, false
                );
            }
        }
    }
}
