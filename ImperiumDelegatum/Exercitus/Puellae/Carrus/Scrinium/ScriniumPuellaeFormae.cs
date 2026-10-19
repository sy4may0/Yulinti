using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ScriniumPuellaeFormae : IScriniumPuellaeFormae {
        private readonly IOstiumCarrusPuellaeFormae _ostiumCarrusPuellaeFormae;

        public ScriniumPuellaeFormae(
            IOstiumCarrusPuellaeFormae ostiumCarrusPuellaeFormae
        ) {
            _ostiumCarrusPuellaeFormae = ostiumCarrusPuellaeFormae;
        }

        public void PostulareRatioActualis(IDPuellaeFormae idFormae, float ratioActualis) {
            _ostiumCarrusPuellaeFormae.PostulareFormae(idFormae, ratioActualis);
        }
    }
}