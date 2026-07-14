using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoPortusConstructionisSubligaculi : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis {
        private readonly IVelumPortusConstructionisSubligaculi _velumPortusConstructionisSubligaculi;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private readonly OperatioPortusConstructionisSubligaculi _operatioPortusConstructionisSubligaculi;

        private readonly CuratorVela _curatorVela;

        private bool _estActivumUsus;

        public PraecoPortusConstructionisSubligaculi(
            IVelumPortusConstructionisSubligaculi velumPortusConstructionisSubligaculi,
            ITurrisInterpretationis turrisInterpretationis,
            ITurrisSoniVeli turrisSoniVeli,
            OperatioPortusConstructionisSubligaculi operatioPortusConstructionisSubligaculi,
            CuratorVela curatorVela
        ) {
            _velumPortusConstructionisSubligaculi = velumPortusConstructionisSubligaculi;
            _turrisInterpretationis = turrisInterpretationis;
            _turrisSoniVeli = turrisSoniVeli;
            _operatioPortusConstructionisSubligaculi = operatioPortusConstructionisSubligaculi;
            _curatorVela = curatorVela;
            _operatioPortusConstructionisSubligaculi.Initiare(Executare, ExecutareValoris);

            _estActivumUsus = true;
        }

        public void Incipere() {
            Tollere();
        }

        public Task Demittere() {
            try {
                _velumPortusConstructionisSubligaculi.DemittereSubligaculi();
                _estActivumUsus = true;

            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
            return Task.CompletedTask;
        }

        public void Tollere() {
            try {
                _velumPortusConstructionisSubligaculi.TollereSubligaculi();
                _estActivumUsus = true;
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        private void Executare(UsusPortusConstructionisSubligaculi usus) {
            return;
        }

        private void ExecutareValoris(UsusPortusConstructionisSubligaculi usus, float valor) {
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
            _operatioPortusConstructionisSubligaculi.Purgare();
        }
    }
}
