using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Auctoritas.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Auctoritas.Senatus {
    internal sealed class PraecoPortusConstructionisOrnamenti : IPraeco, IPraecoIncipabilis, IPraecoLiberabilis {
        private readonly IVelumPortusConstructionisOrnamenti _velumPortusConstructionisOrnamenti;
        private readonly ITurrisInterpretationis _turrisInterpretationis;
        private readonly ITurrisSoniVeli _turrisSoniVeli;

        private readonly OperatioPortusConstructionisOrnamenti _operatioPortusConstructionisOrnamenti;

        private readonly CuratorVela _curatorVela;

        private bool _estActivumUsus;

        public PraecoPortusConstructionisOrnamenti(
            IVelumPortusConstructionisOrnamenti velumPortusConstructionisOrnamenti,
            ITurrisInterpretationis turrisInterpretationis,
            ITurrisSoniVeli turrisSoniVeli,
            OperatioPortusConstructionisOrnamenti operatioPortusConstructionisOrnamenti,
            CuratorVela curatorVela
        ) {
            _velumPortusConstructionisOrnamenti = velumPortusConstructionisOrnamenti;
            _turrisInterpretationis = turrisInterpretationis;
            _turrisSoniVeli = turrisSoniVeli;
            _operatioPortusConstructionisOrnamenti = operatioPortusConstructionisOrnamenti;
            _curatorVela = curatorVela;
            _operatioPortusConstructionisOrnamenti.Initiare(Executare, ExecutareValoris);

            _estActivumUsus = true;
        }

        public void Incipere() {
            Tollere();
        }

        public Task Demittere() {
            try {
                _velumPortusConstructionisOrnamenti.DemittereOrnamenti();
                _estActivumUsus = true;

            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
            return Task.CompletedTask;
        }

        public void Tollere() {
            try {
                _velumPortusConstructionisOrnamenti.TollereOrnamenti();
                _estActivumUsus = true;
            } catch (Exception e) {
                Carnifex.Intermissio(e);
            }
        }

        private void Executare(UsusPortusConstructionisOrnamenti usus) {
            return;
        }

        private void ExecutareValoris(UsusPortusConstructionisOrnamenti usus, float valor) {
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
            _operatioPortusConstructionisOrnamenti.Purgare();
        }
    }
}
