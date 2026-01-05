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
        public void DeactivateCapitis() {
            _miPuellaeResVisae.DeactivateCapitis();
        }
        public void DeactivatePectoris() {
            _miPuellaeResVisae.DeactivatePectoris();
        }
        public void DeactivateNatium() {
            _miPuellaeResVisae.DeactivateNatium();
        }

        public void Activare() {
            ActivareCapitis();
            ActivarePectoris();
            ActivareNatium();
        }

        public void Deactivate() {
            DeactivateCapitis();
            DeactivatePectoris();
            DeactivateNatium();
        }
    }
}