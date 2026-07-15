using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoPortusConstructionisTunicae : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis {
        private readonly IVelumPortusConstructionisTunicae _velumPortusConstructionisTunicae;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private readonly OperatioPortusConstructionisTunicae _operatioPortusConstructionisTunicae;

        private readonly CuratorVela _curatorVela;

        private bool _estActivumUsus;

        public PraecoPortusConstructionisTunicae(
            IVelumPortusConstructionisTunicae velumPortusConstructionisTunicae,
            ITurrisInterpretationis turrisInterpretationis,
            ITurrisSoniVeli turrisSoniVeli,
            OperatioPortusConstructionisTunicae operatioPortusConstructionisTunicae,
            CuratorVela curatorVela
        ) {
            _velumPortusConstructionisTunicae = velumPortusConstructionisTunicae;
            _turrisInterpretationis = turrisInterpretationis;
            _turrisSoniVeli = turrisSoniVeli;
            _operatioPortusConstructionisTunicae = operatioPortusConstructionisTunicae;
            _curatorVela = curatorVela;
            _operatioPortusConstructionisTunicae.Initiare(Executare, ExecutareValoris);

            _estActivumUsus = true;
        }

        public void Incipere() {
            Tollere();
        }

        public Task Demittere() {
            try {
                _velumPortusConstructionisTunicae.DemittereTunicae();
                _estActivumUsus = true;

            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
            return Task.CompletedTask;
        }

        public void Tollere() {
            try {
                _velumPortusConstructionisTunicae.TollereTunicae();
                _estActivumUsus = true;
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        private void Executare(UsusPortusConstructionisTunicae usus) {
            return;
        }

        private void ExecutareValoris(UsusPortusConstructionisTunicae usus, float valor) {
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
            _operatioPortusConstructionisTunicae.Purgare();
        }
    }
}
