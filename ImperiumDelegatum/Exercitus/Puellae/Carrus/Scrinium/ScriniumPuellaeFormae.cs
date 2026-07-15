using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ScriniumPuellaeFormae : IScriniumPuellaeFormae {
        private readonly IOstiumCarrusPuellae _ostiumCarrusPuellae;

        public ScriniumPuellaeFormae(
            IOstiumCarrusPuellae ostiumCarrusPuellae
        ) {
            _ostiumCarrusPuellae = ostiumCarrusPuellae;
        }

        public void PostulareRatioActualis(IDPuellaeFormae idFormae, float ratioActualis) {
            _ostiumCarrusPuellae.PostulareFormae(idFormae, ratioActualis);
        }
    }
}