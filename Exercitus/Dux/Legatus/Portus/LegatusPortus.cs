using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Exercitus.Dux {
    internal sealed class LegatusPortus : ILegatus, ILegatusIncipabilis, ILegatusLiberabilis {
        private readonly ITurrisMundus _turrisMundus;
        private readonly IVelumPortus _velumPortus;
        private readonly ILegatusConfirmationis _legatusConfirmationis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;

        private readonly CuratorVela _curatorVela;

        private readonly CancellationTokenSource _cancellationTokenSource;

        // Dux -> Velumへのコールバック
        private Action _aeAdPremereProfectio;
        private Action _aeAdPremereConstructio;
        private Action _aeAdPremereTaberna;
        private Action _aeAdPremereOptiones;
        private Action _aeAdPremereExi;

        public LegatusPortus(
            ITurrisMundus turrisMundus,
            IVelumPortus velumPortus,
            ILegatusConfirmationis legatusConfirmationis,
            ITurrisInterpretationis turrisInterpretationis,
            CuratorVela curatorVela
        ) {
            _turrisMundus = turrisMundus;
            _velumPortus = velumPortus;
            _legatusConfirmationis = legatusConfirmationis;
            _turrisInterpretationis = turrisInterpretationis;
            _curatorVela = curatorVela;

            _aeAdPremereProfectio = AdPremereProfectio;
            _aeAdPremereConstructio = AdPremereConstructio;
            _aeAdPremereTaberna = AdPremereTaberna;
            _aeAdPremereOptiones = AdPremereOptiones;
            _aeAdPremereExi = AdPremereExi;

            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Incipere() {
            _velumPortus.Initare();
            _ = Demittere();
        }

        // Asyncにする必要はないけど、他のLegatusと同じようにする。
        private Task Demittere() {
            try {
                // UIを表示
                _velumPortus.DemitterePortus();

                _velumPortus.AdPremereProfectio(_aeAdPremereProfectio);
                _velumPortus.AdPremereConstructio(_aeAdPremereConstructio);
                _velumPortus.AdPremereTaberna(_aeAdPremereTaberna);
                _velumPortus.AdPremereOptiones(_aeAdPremereOptiones);
                _velumPortus.AdPremereExi(_aeAdPremereExi);

            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
            return Task.CompletedTask;
        }

        private void AdPremereProfectio() {
            _ = PremereProfectio();
        }

        private Task PremereProfectio() {
            Notarius.Memorare("未実装: PostulareProfectio");
            // 仮。本来はマップ選択画面で選択してから、シーン移動。
            _curatorVela.TollereVelaOmnium();
            _turrisMundus.AdMudum(IDMundi.MundusTestScene);
 
            return Task.CompletedTask;
        }

        private void AdPremereConstructio() {
            _ = PremereConstructio();
        }

        private Task PremereConstructio() {
            Notarius.Memorare("未実装: PostulareConstructio");
            // 未実装
            return Task.CompletedTask;
        }

        private void AdPremereTaberna() {
            _ = PremereTaberna();
        }

        private Task PremereTaberna() {
            Notarius.Memorare("未実装: PostulareTaberna");
            // 未実装
            return Task.CompletedTask;
        }

        private void AdPremereOptiones() {
            _ = PremereOptiones();
        }

        private Task PremereOptiones() {
            Notarius.Memorare("未実装: PostulareOptiones");
            // 未実装
            return Task.CompletedTask;
        }

        private void AdPremereExi() {
            _ = PremereExi();
        }

        private async Task PremereExi() {
            try {
                bool estConfirmationis = await _legatusConfirmationis.DemittereAsync(
                    _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_BUTTON_EXI_TITULUS),
                    _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_BUTTON_EXI_TEXTUS),
                    _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_BUTTON_EXI_BUTTON_ITA),
                    _turrisInterpretationis.LegoTextus(IDTextus.PORTUS_BUTTON_EXI_BUTTON_NON),
                    null,
                    null,
                    _cancellationTokenSource.Token
                );

                if (!estConfirmationis) {
                    return;
                }

                _curatorVela.TollereVelaOmnium();
                _turrisMundus.AdMudum(IDMundi.MundusMenu);
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        public void Liberare() {
            _cancellationTokenSource.Cancel();
        }
    }
}