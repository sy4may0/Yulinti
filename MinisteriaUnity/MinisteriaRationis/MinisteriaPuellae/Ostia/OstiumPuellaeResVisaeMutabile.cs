using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeResVisaeMutabile : IOstiumPuellaeResVisaeMutabile {
        private readonly MinisteriumPuellaeResVisae _miPuellaeResVisae;
        public OstiumPuellaeResVisaeMutabile(MinisteriumPuellaeResVisae miPuellaeResVisae) {
            _miPuellaeResVisae = miPuellaeResVisae;
        }

        public void ActivareCapitis() {
            _miPuellaeResVisae.ActivareCapitis();
        }
        public void ActivarePectoris() {
            _miPuellaeResVisae.ActivarePectoris();
        }
        public void ActivareNatium() {
            _miPuellaeResVisae.ActivareNatium();
        }

        public void ActivareNudusAnterior() {
            _miPuellaeResVisae.ActivareNudusAnterior();
        }
        public void ActivareNudusPosterior() {
            _miPuellaeResVisae.ActivareNudusPosterior();
        }

        public void DeactivateCapitis() {
            _miPuellaeResVisae.DeactivateCapitis();
        }
        public void DeactivatePectoris() {
            _miPuellaeResVisae.DeactivatePectoris();
        }
        public void DeactivateNatium() {
            _miPuellaeResVisae.DeactivateNatium();
        }
        public void DeactivateNudusAnterior() {
            _miPuellaeResVisae.DeactivateNudusAnterior();
        }
        public void DeactivateNudusPosterior() {
            _miPuellaeResVisae.DeactivateNudusPosterior();
        }

        public void Activare() {
            ActivareCapitis();
            ActivarePectoris();
            ActivareNatium();
            ActivareNudusAnterior();
            ActivareNudusPosterior();
        }

        public void Deactivate() {
            DeactivateCapitis();
            DeactivatePectoris();
            DeactivateNatium();
            DeactivateNudusAnterior();
            DeactivateNudusPosterior();
        }
    }
}