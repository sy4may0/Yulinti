using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoPortusConstructionisSalsamenti : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis {
        private readonly IVelumPortusConstructionisSalsamenti _velumPortusConstructionisSalsamenti;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private readonly OperatioPortusConstructionisSalsamenti _operatioPortusConstructionisSalsamenti;

        private readonly CuratorVela _curatorVela;

        private bool _estActivumUsus;

        public PraecoPortusConstructionisSalsamenti(
            IVelumPortusConstructionisSalsamenti velumPortusConstructionisSalsamenti,
            ITurrisInterpretationis turrisInterpretationis,
            ITurrisSoniVeli turrisSoniVeli,
            OperatioPortusConstructionisSalsamenti operatioPortusConstructionisSalsamenti,
            CuratorVela curatorVela
        ) {
            _velumPortusConstructionisSalsamenti = velumPortusConstructionisSalsamenti;
            _turrisInterpretationis = turrisInterpretationis;
            _turrisSoniVeli = turrisSoniVeli;
            _operatioPortusConstructionisSalsamenti = operatioPortusConstructionisSalsamenti;
            _curatorVela = curatorVela;
            _operatioPortusConstructionisSalsamenti.Initiare(Executare, ExecutareValoris);

            _estActivumUsus = true;
        }

        public void Incipere() {
            Tollere();
        }

        public Task Demittere() {
            try {
                _velumPortusConstructionisSalsamenti.DemittereSalsamenti();
                _estActivumUsus = true;

            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
            return Task.CompletedTask;
        }

        public void Tollere() {
            try {
                _velumPortusConstructionisSalsamenti.TollereSalsamenti();
                _estActivumUsus = true;
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        private void Executare(UsusPortusConstructionisSalsamenti usus) {
            return;
        }

        private void ExecutareValoris(UsusPortusConstructionisSalsamenti usus, float valor) {
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
            _operatioPortusConstructionisSalsamenti.Purgare();
        }
    }
}
