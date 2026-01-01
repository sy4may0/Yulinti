using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MotorPuellaeAnimationis {
        private readonly IOstiumPuellaeAnimationesMutabile _ostiumPuellaeAnimationesMutabile;

        public MotorPuellaeAnimationis(
            IOstiumPuellaeAnimationesMutabile ostiumPuellaeAnimationesMutabile
        ) {
            _ostiumPuellaeAnimationesMutabile = ostiumPuellaeAnimationesMutabile;
        }

        public void InitiarePreadefinitus(
            IDPuellaeAnimationisContinuata idPreadefinitus
        ) {
            _ostiumPuellaeAnimationesMutabile.Postulare(
                idPreadefinitus, null, null);
        }

        public void ApplicareAnimationis(
            OrdinatioPuellaeAnimationis ordinatio
        ) {
            if (ordinatio.EstCogere) {
                _ostiumPuellaeAnimationesMutabile.Cogere(ordinatio.IdAnimationis, ordinatio.AdInitium, ordinatio.AdFinem);
            } else {
                _ostiumPuellaeAnimationesMutabile.Postulare(ordinatio.IdAnimationis, ordinatio.AdInitium, ordinatio.AdFinem); }
        }

        public void InjicereVelocitatem(float velocitas) {
            _ostiumPuellaeAnimationesMutabile.InjicereVelocitatem(velocitas);
        }
    }
}