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
        private readonly IPraecoConfirmationis _praecoConfirmationis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;

        // 下位Praeco
        private readonly PraecoPortusConstructionis _praecoPortusConstructionis;

        // Operatio
        private readonly OperatioPortus _operatioPortus;

        private readonly CuratorVela _curatorVela;

        private readonly IOstiumSignumCancellationisLegibile _ostiumSignumCancellationisLegibile;

        private bool _estActivumUsus;

        public PraecoPortus(
            ITurrisMundus turrisMundus,
            IVelumPortus velumPortus,
            IPraecoConfirmationis praecoConfirmationis,
            ITurrisInterpretationis turrisInterpretationis,
            OperatioPortus operatioPortus,
            CuratorVela curatorVela,
            IOstiumSignumCancellationisLegibile ostiumSignumCancellationisLegibile,
            PraecoPortusConstructionis praecoPortusConstructionis
        ) {
            _turrisMundus = turrisMundus;
            _velumPortus = velumPortus;
            _praecoConfirmationis = praecoConfirmationis;
            _turrisInterpretationis = turrisInterpretationis;
            _curatorVela = curatorVela;
            _ostiumSignumCancellationisLegibile = ostiumSignumCancellationisLegibile;
            _operatioPortus = operatioPortus;
            _praecoPortusConstructionis = praecoPortusConstructionis;
            _operatioPortus.Initiare(Executare, ExireConstructionem);

            _estActivumUsus = true;
        }

        public void Incipere() {
            _ = Demittere();
        }

        // Asyncにする必要はないけど、他のPraecoと同じようにする。
        private Task Demittere() {
            try {
                // UIを表示
                _velumPortus.DemitterePortus();
                _estActivumUsus = true;
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
            return Task.CompletedTask;
        }

        private void Executare(UsusPortus usus) {
            if (usus == UsusPortus.Profectio) {
                _ = PremereProfectio();
            } else if (usus == UsusPortus.Constructio) {
                _ = PremereConstructio();
            } else if (usus == UsusPortus.Taberna) {
                _ = PremereTaberna();
            } else if (usus == UsusPortus.Optiones) {
                _ = PremereOptiones();
            } else if (usus == UsusPortus.Exi) {
                _ = PremereExi();
            }
        }
        
        private void ExireConstructionem() {
            // Constructioを閉じた際、Portusを再表示する。
            _velumPortus.DemitterePortus();
        }

        private Task PremereProfectio() {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }
                Notarius.Memorare("未実装: PostulareProfectio");
                // 仮。本来はマップ選択画面で選択してから、シーン移動。
                _curatorVela.TollereVelaOmnium();
                _turrisMundus.AdMundum(IDMundi.MundusTestScene);
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
            return Task.CompletedTask;
        }

        private Task PremereConstructio() {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }

                // Constructioを開き、Portusを閉じる。
                _ = _praecoPortusConstructionis.Demittere();
                _velumPortus.TollerePortus();

            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
            // 未実装
            return Task.CompletedTask;
        }

        private Task PremereTaberna() {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }
                Notarius.Memorare("未実装: PostulareTaberna");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
            // 未実装
            return Task.CompletedTask;
        }

        private Task PremereOptiones() {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }
                Notarius.Memorare("未実装: PostulareOptiones");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
            // 未実装
            return Task.CompletedTask;
        }

        private async Task PremereExi() {
            try {
                if (!ConareUsus()) {
                    return;
                }
                bool estConfirmationis = await _praecoConfirmationis.DemittereAsync(
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

        public void Liberare() {
            _operatioPortus.Purgare();
        }
    }
}
