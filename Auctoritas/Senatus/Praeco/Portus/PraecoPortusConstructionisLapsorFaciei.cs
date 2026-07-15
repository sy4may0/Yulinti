using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoPortusConstructionisLapsorFaciei : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis {
        private readonly IVelumPortusConstructionisLapsorFaciei _velumPortusConstructionisLapsorFaciei;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private readonly OperatioPortusConstructionisLapsorFaciei _operatioPortusConstructionisLapsorFaciei;

        private readonly CuratorVela _curatorVela;

        private bool _estActivumUsus;

        public PraecoPortusConstructionisLapsorFaciei(
            IVelumPortusConstructionisLapsorFaciei velumPortusConstructionisLapsorFaciei,
            ITurrisInterpretationis turrisInterpretationis,
            ITurrisSoniVeli turrisSoniVeli,
            OperatioPortusConstructionisLapsorFaciei operatioPortusConstructionisLapsorFaciei,
            CuratorVela curatorVela
        ) {
            _velumPortusConstructionisLapsorFaciei = velumPortusConstructionisLapsorFaciei;
            _turrisInterpretationis = turrisInterpretationis;
            _turrisSoniVeli = turrisSoniVeli;
            _operatioPortusConstructionisLapsorFaciei = operatioPortusConstructionisLapsorFaciei;
            _curatorVela = curatorVela;
            _operatioPortusConstructionisLapsorFaciei.Initiare(Executare, ExecutareValoris);

            _estActivumUsus = true;
        }

        public void Incipere() {
            Tollere();
        }

        public Task Demittere() {
            try {
                _velumPortusConstructionisLapsorFaciei.DemittereLapsorFaciei();
                _estActivumUsus = true;

            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
            return Task.CompletedTask;
        }

        public void Tollere() {
            try {
                _velumPortusConstructionisLapsorFaciei.TollereLapsorFaciei();
                _estActivumUsus = true;
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        private void Executare(UsusPortusConstructionisLapsorFaciei usus) {
            return;
        }

        private void ExecutareValoris(UsusPortusConstructionisLapsorFaciei usus, float valor) {
            return;
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
            _operatioPortusConstructionisLapsorFaciei.Purgare();
        }
    }
}
