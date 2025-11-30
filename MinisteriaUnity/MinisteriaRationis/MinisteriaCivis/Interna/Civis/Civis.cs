using UnityEngine;
using UnityEngine.AI;
using Cysharp.Threading.Tasks;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class Civis : ICivis {
        private IAnchoraCivis _anchora;
        private ICivisLociNavMesh _civisLociNavMesh;

        public Civis(IAnchoraCivis anchora, LuditorPunctumViae luditorPunctumViae) {
            _anchora = anchora;
            _civisLociNavMesh = new CivisLociNavMesh(luditorPunctumViae, anchora);
        }

        // Spawn
        public void Oriri() {
            OririAsync().Forget(e => Memorator.MemorareException(e));
        }

        public async UniTask OririAsync() {
            await _anchora.Manifestatio();
            bool result = _anchora.ValidareManifestatio();

            if (!result) {
                _anchora.Deleto();
                Memorator.MemorareErrorum(IDErrorum.CIVIS_INSTANTIATE_FAILED);
            }

            NavMesh.Activare();
            EventusCivisLociNavMesh incipere = NavMesh.IncipereMigrare();
            if (incipere.ev.EstError()) {
                Memorator.MemorareErrorum(incipere.ev.ID());
            }
            if (incipere.estEvanescere) {
                Evanescere();
            }
            
        }

        // Despawn
        public void Evanescere() {
            _anchora.Deleto();
        }

        public ICivisLociNavMesh NavMesh => _civisLociNavMesh;

        // インスタンスは生�EされてぁE��か、E
        public bool EstActivum => _anchora.EstEns;
        public Vector3 LegoPositionem => _anchora.Positio;
        public Quaternion LegoRotationem => _anchora.Rotatio;
        public Vector3 LegoScalam => _anchora.Scala;
    }
}


