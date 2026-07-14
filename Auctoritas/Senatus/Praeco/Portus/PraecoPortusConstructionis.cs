using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoPortusConstructionis : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis {
        private readonly ITurrisMundus _turrisMundus;
        private readonly IVelumPortusConstructionis _velumPortusConstructionis;
        private readonly IPraecoConfirmationis _praecoConfirmationis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;

        // Operatio
        private readonly OperatioPortusConstructionis _operatioPortusConstructionis;
        private readonly IOperatioInternaPortus _operatioInternaPortus;

        private readonly CuratorVela _curatorVela;

        private readonly IOstiumSignumCancellationisLegibile _ostiumSignumCancellationisLegibile;

        private bool _estActivumUsus;

        public PraecoPortusConstructionis(
            ITurrisMundus turrisMundus,
            IVelumPortusConstructionis velumPortusConstructionis,
            IPraecoConfirmationis praecoConfirmationis,
            ITurrisInterpretationis turrisInterpretationis,
            OperatioPortusConstructionis operatioPortusConstructionis,
            IOperatioInternaPortus operatioInternaPortus,
            CuratorVela curatorVela,
            IOstiumSignumCancellationisLegibile ostiumSignumCancellationisLegibile
        ) {
            _turrisMundus = turrisMundus;
            _velumPortusConstructionis = velumPortusConstructionis;
            _praecoConfirmationis = praecoConfirmationis;
            _turrisInterpretationis = turrisInterpretationis;
            _curatorVela = curatorVela;
            _ostiumSignumCancellationisLegibile = ostiumSignumCancellationisLegibile;
            _operatioPortusConstructionis = operatioPortusConstructionis;
            _operatioInternaPortus = operatioInternaPortus;
            _operatioPortusConstructionis.Initiare(Executare);

            _estActivumUsus = true;
        }

        public void Incipere() {
            TollereInitialis();
        }

        public Task Demittere() {
            try {
                // UIを表示
                _velumPortusConstructionis.DemittereConstructionis();
                _estActivumUsus = true;
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
            return Task.CompletedTask;
        }

        public void Tollere() {
            try {
                _velumPortusConstructionis.TollereConstructionis();
                _operatioInternaPortus.ExireConstructionem();
                _estActivumUsus = true;
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        public void TollereInitialis() {
            try {
                _velumPortusConstructionis.TollereConstructionis();
                _estActivumUsus = true;
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        private void Executare(UsusPortusConstructionis usus) {
            if (usus == UsusPortusConstructionis.LapsorCorporis) {
                _ = PremereLapsorCorporis();
            } else if (usus == UsusPortusConstructionis.LapsorFaciei) {
                _ = PremereLapsorFaciei();
            } else if (usus == UsusPortusConstructionis.Subligaculum) {
                _ = PremereSubligaculum();
            } else if (usus == UsusPortusConstructionis.Tunica) {
                _ = PremereTunica();
            } else if (usus == UsusPortusConstructionis.Ornamentum) {
                _ = PremereOrnamentum();
            } else if (usus == UsusPortusConstructionis.Salsamentum) {
                _ = PremereSalsamentum();
            } else if (usus == UsusPortusConstructionis.Exi) {
                _ = PremereExi();
            }
        }

        private Task PremereLapsorCorporis() {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }
                Notarius.Memorare("未実装: PostulareLapsorCorporis");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
            return Task.CompletedTask;
        }

        private Task PremereLapsorFaciei() {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }
                Notarius.Memorare("未実装: PostulareLapsorFaciei");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
            return Task.CompletedTask;
        }

        private Task PremereSubligaculum() {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }
                Notarius.Memorare("未実装: PostulareSubligaculum");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
            return Task.CompletedTask;
        }

        private Task PremereTunica() {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }
                Notarius.Memorare("未実装: PostulareTunica");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
            return Task.CompletedTask;
        }

        private Task PremereOrnamentum() {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }
                Notarius.Memorare("未実装: PostulareOrnamentum");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
            return Task.CompletedTask;
        }

        private Task PremereSalsamentum() {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }
                Notarius.Memorare("未実装: PostulareSalsamentum");
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
            return Task.CompletedTask;
        }

        private Task PremereExi() {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }

                Tollere();
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            } finally {
                LiberareUsus();
            }
            return Task.CompletedTask;
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
            _operatioPortusConstructionis.Purgare();
        }
    }
}