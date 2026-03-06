using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
    public sealed class NewOstiumPuellaeAnimationisMutabile : NewIOstiumPuellaeAnimationisMutabile {
        private readonly NewMinisteriumPuellaeAnimationis _ministeriumPuellaeAnimationis;

        public NewOstiumPuellaeAnimationisMutabile(NewMinisteriumPuellaeAnimationis ministeriumPuellaeAnimationis) {
            _ministeriumPuellaeAnimationis = ministeriumPuellaeAnimationis;
        }

        public bool EstExhibens(IDPuellaeAnimationisStratum stratum) {
            return _ministeriumPuellaeAnimationis.EstExhibens(stratum);
        }
        public bool EstDesinens(IDPuellaeAnimationisStratum stratum) {
            return _ministeriumPuellaeAnimationis.EstDesinens(stratum);
        }
        public bool EstExhibensIterans(IDPuellaeAnimationisStratum stratum) {
            return _ministeriumPuellaeAnimationis.EstExhibensIterans(stratum);
        }
        public void Exhibere(IDPuellaeAnimationisStratum stratum, NewIDPuellaeAnimationis id) {
            _ministeriumPuellaeAnimationis.Exhibere(stratum, id);
        }
        public void Desinere(IDPuellaeAnimationisStratum stratum) {
            _ministeriumPuellaeAnimationis.Desinere(stratum);
        }
        public void InjicereVelocitatem(float vel) {
            _ministeriumPuellaeAnimationis.InjicereVelocitatem(vel);
        }
        public void Purgere(IDPuellaeAnimationisStratum stratum) {
            _ministeriumPuellaeAnimationis.Purgere(stratum);
        }
    }
}