using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoPortus : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis {
        private readonly ITurrisMundus _turrisMundus;
        private readonly IVelumPortus _velumPortus;
        private readonly IPraecoConfirmationis _legatusConfirmationis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;

        private readonly CuratorVela _curatorVela;

        private readonly IOstiumSignumCancellationisLegibile _ostiumSignumCancellationisLegibile;

        // Dux -> Velumへのコールバック
        private Action _aeAdPremereProfectio;
        private Action _aeAdPremereConstructio;
        private Action _aeAdPremereTaberna;
        private Action _aeAdPremereOptiones;
        private Action _aeAdPremereExi;

        public PraecoPortus(
            ITurrisMundus turrisMundus,
            IVelumPortus velumPortus,
            IPraecoConfirmationis legatusConfirmationis,
            ITurrisInterpretationis turrisInterpretationis,
            CuratorVela curatorVela,
            IOstiumSignumCancellationisLegibile ostiumSignumCancellationisLegibile
        ) {
            _turrisMundus = turrisMundus;
            _velumPortus = velumPortus;
            _legatusConfirmationis = legatusConfirmationis;
            _turrisInterpretationis = turrisInterpretationis;
            _curatorVela = curatorVela;
            _ostiumSignumCancellationisLegibile = ostiumSignumCancellationisLegibile;

            _aeAdPremereProfectio = AdPremereProfectio;
            _aeAdPremereConstructio = AdPremereConstructio;
            _aeAdPremereTaberna = AdPremereTaberna;
            _aeAdPremereOptiones = AdPremereOptiones;
            _aeAdPremereExi = AdPremereExi;

        }

        public void Incipere() {
            _ = Demittere();
        }

        // Asyncにする必要はないけど、他のPraecoと同じようにする。
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
            _turrisMundus.AdMundum(IDMundi.MundusTestScene);
 
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
                    IDSonusVeli.Submittere,
                    IDSonusVeli.Exire,
                    _ostiumSignumCancellationisLegibile.Signum
                );

                if (!estConfirmationis) {
                    return;
                }

                _curatorVela.TollereVelaOmnium();
                _turrisMundus.AdMundum(IDMundi.MundusMenu);
            } catch (OperationCanceledException) {
                //キャンセルしてよい。何もしない。
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        public void Liberare() { }
    }
}