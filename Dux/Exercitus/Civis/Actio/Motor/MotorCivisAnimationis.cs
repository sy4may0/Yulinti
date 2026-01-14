using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MotorCivisAnimationis {
        private readonly IOstiumCivisAnimationesMutabile _ostiumCivisAnimationesMutabile;

        public MotorCivisAnimationis(
            IOstiumCivisAnimationesMutabile ostiumCivisAnimationesMutabile
        ) {
            _ostiumCivisAnimationesMutabile = ostiumCivisAnimationesMutabile;
        }

        public void InitiarePreadefinitus(
            int idCivis,
            IDCivisAnimationisContinuata idPreadefinitus
        ) {
            _ostiumCivisAnimationesMutabile.Postulare(
                idCivis,
                idPreadefinitus,
                null,
                null
            );
        }

        public void ApplicareAnimationis(
            in OrdinatioCivisAnimationis ordinatio
        ) {
            if (ordinatio.EstCogere) {
                _ostiumCivisAnimationesMutabile.Cogere(
                    ordinatio.IdCivis,
                    ordinatio.IdAnimationis,
                    ordinatio.AdInitium,
                    ordinatio.AdFinem
                );
            } else {
                _ostiumCivisAnimationesMutabile.Postulare(
                    ordinatio.IdCivis,
                    ordinatio.IdAnimationis,
                    ordinatio.AdInitium,
                    ordinatio.AdFinem
                );
            }
        }

        public void InjicereVelocitatem(int idCivis, float velocitas) {
            _ostiumCivisAnimationesMutabile.InjicereVelocitatem(idCivis, velocitas);
        }

        public void Purgere(int idCivis) {
            _ostiumCivisAnimationesMutabile.Purgere(idCivis);
        }
    }
}
