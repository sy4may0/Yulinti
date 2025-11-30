using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using UnityEngine;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class Ministeria : IPulsabilis, IPulsabilisPrimum, IPulsabilisFixus, IPulsabilisFixusPrimum, IPulsabilisTardus {
        private readonly FasciculusOstiorumRationis _ostiorumRationis;
        private readonly FonsTemporis _fonsTemporis;
        private readonly ITemporis _temporis;

        // Civis Test
        private readonly LuditorPunctumViae _luditorPunctumViae;
        private readonly Civis _civis;

        public Ministeria(
            IVasculumMinisterii vasculumMinisterii
        ) {
            _fonsTemporis = new FonsTemporis();
            _temporis = new Temporis(_fonsTemporis);
            _ostiorumRationis = new FasciculusOstiorumRationis(vasculumMinisterii, _temporis);

            // Civis Test
            _luditorPunctumViae = new LuditorPunctumViae(vasculumMinisterii.Civis.AnchoraPunctumViae);
            _civis = new Civis(vasculumMinisterii.Civis.AnchoraCivis[0], _luditorPunctumViae);
            _civis.Oriri();

        }

        public FasciculusOstiorumRationis OstiorumRationis => _ostiorumRationis;
        public FasciculusOstiorumPuellae Puellae => _ostiorumRationis.Puellae;
        public FasciculusOstiorumNuclei Nuclei => _ostiorumRationis.Nuclei;
        public FasciculusOstiorumInput Input => _ostiorumRationis.Input;
        public FasciculusOstiorumCamera Camera => _ostiorumRationis.Camera;


        public void PulsusPrimum() {
            // ここでDeltaTime更新。　-> 以降�EてITemporis/OstiumTemporisLegibileにアクセスする、E
            _fonsTemporis.Pulsus();
        }
        public void Pulsus() {
            _ostiorumRationis.Pulsus();

            // Civis Test
            if (_civis.EstActivum && _civis.NavMesh.EstAdPerveni(0.5f)) {
                EventusCivisLociNavMesh result = _civis.NavMesh.Migrare();
                if(result.estEvanescere) {
                    if (result.ev.EstError()) {
                        Memorator.MemorareErrorum(result.ev.ID());
                    }
                    _civis.Evanescere();
                }
            }
        }

        public void PulsusFixusPrimum() {
            // ここでFixedDeltaTime更新。　-> 以降�EてITemporis/OstiumTemporisLegibileにアクセスする、E
            _fonsTemporis.PulsusFixus();
        }

        public void PulsusFixus() {
            _ostiorumRationis.PulsusFixus();
        }

        public void PulsusTardus() {
            _ostiorumRationis.PulsusTardus();
        }
    }
}
        



