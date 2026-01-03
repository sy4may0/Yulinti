using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesCivisVeletudinis {
        private readonly ResolutorCivisVeletudinis _resolutorVeletudinis;

        public MilesCivisVeletudinis(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IOstiumCivisMutabile ostiumCivisMut
        ) {
            _resolutorVeletudinis = new ResolutorCivisVeletudinis(
                contextusOstiorum,
                ostiumCivisMut
            );
        }

        public void InitarePhantasma(ResFluidaCivisVeletudinis resFluida) {
            _resolutorVeletudinis.InitarePhantasma(resFluida);
        }

        public void Addo(OrdinatioCivisVeletudinisValoris ordinatio) {
            _resolutorVeletudinis.Addo(ordinatio);
        }

        public void Applicare(ResFluidaCivisVeletudinis resFluida) {
            _resolutorVeletudinis.Applicare(resFluida);
        }

        public void RenovereDomina(ResFluidaCivisVeletudinis resFluida) {
            _resolutorVeletudinis.RenovereDomina(resFluida);
        }

        public void Incarnare(int id) {
            _resolutorVeletudinis.Incarnare(id);
        }

        public void Spirituare(int id) {
            _resolutorVeletudinis.Spirituare(id);
        }

        public void ApplicareMors(
            OrdinatioCivisVeletudinisMortis ordinatio,
            ResFluidaCivisVeletudinis resFluida
        ) {
            _resolutorVeletudinis.ApplicareMors(ordinatio, resFluida);
        }

        public void Servatum(int id, ResFluidaCivisVeletudinis resFluida) {
            _resolutorVeletudinis.Servatum(id, resFluida);
        }

        public void LiberareServatum(int id, ResFluidaCivisVeletudinis resFluida) {
            _resolutorVeletudinis.LiberareServatum(id, resFluida);
        }

    }
}