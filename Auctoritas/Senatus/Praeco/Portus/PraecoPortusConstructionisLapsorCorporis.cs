using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoPortusConstructionisLapsorCorporis : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis {
        private readonly IVelumPortusConstructionisLapsorCorporis _velumPortusConstructionisLapsorCorporis;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private readonly IResFluidaPuellaeFormaeLegibile _resFluidaPuellaeFormaeLegibile;
        private readonly IScriniumPuellaeFormae _scriniumPuellaeFormae;

        private readonly OperatioPortusConstructionisLapsorCorporis _operatioPortusConstructionisLapsorCorporis;

        private readonly CuratorVela _curatorVela;

        private bool _estActivumUsus;

        public PraecoPortusConstructionisLapsorCorporis(
            IVelumPortusConstructionisLapsorCorporis velumPortusConstructionisLapsorCorporis,
            ITurrisInterpretationis turrisInterpretationis,
            ITurrisSoniVeli turrisSoniVeli,
            OperatioPortusConstructionisLapsorCorporis operatioPortusConstructionisLapsorCorporis,
            CuratorVela curatorVela,
            IResFluidaPuellaeFormaeLegibile resFluidaPuellaeFormaeLegibile,
            IScriniumPuellaeFormae scriniumPuellaeFormae
        ) {
            _velumPortusConstructionisLapsorCorporis = velumPortusConstructionisLapsorCorporis;
            _turrisInterpretationis = turrisInterpretationis;
            _turrisSoniVeli = turrisSoniVeli;
            _operatioPortusConstructionisLapsorCorporis = operatioPortusConstructionisLapsorCorporis;
            _curatorVela = curatorVela;
            _resFluidaPuellaeFormaeLegibile = resFluidaPuellaeFormaeLegibile;
            _scriniumPuellaeFormae = scriniumPuellaeFormae;

            _operatioPortusConstructionisLapsorCorporis.Initiare(Executare, ExecutareValoris);

            _estActivumUsus = true;
        }

        public void Incipere() {
            Tollere();
        }

        public Task Demittere() {
            try {
                _velumPortusConstructionisLapsorCorporis.DemittereLapsorCorporis();
                _estActivumUsus = true;

            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
            return Task.CompletedTask;
        }

        public void Tollere() {
            try {
                _velumPortusConstructionisLapsorCorporis.TollereLapsorCorporis();
                _estActivumUsus = true;
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        private void Executare(UsusPortusConstructionisLapsorCorporis usus) {
            return;
        }

        private void ExecutareValoris(UsusPortusConstructionisLapsorCorporis usus, float valor) {
            if (usus == UsusPortusConstructionisLapsorCorporis.LapsorCorporis) {
                _ = PremereLapsorCorporis(valor);
            }
            return;
        }

        private Task PremereLapsorCorporis(float valor) {
            try {
                if (!ConareUsus()) {
                    return Task.CompletedTask;
                }

                float currens = _resFluidaPuellaeFormaeLegibile.RatioActualis(IDPuellaeFormae.Corpus);
                if (MathF.Abs(currens - valor) < 0.01) {
                    return Task.CompletedTask;
                }
                _scriniumPuellaeFormae.PostulareRatioActualis(IDPuellaeFormae.Corpus, valor);
                _turrisSoniVeli.Sonare(IDSonusVeli.Cursor);
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
            return true;
        }

        private void LiberareUsus() {
            _estActivumUsus = true;
        }

        public void Liberare() {
            _operatioPortusConstructionisLapsorCorporis.Purgare();
        }
    }
}