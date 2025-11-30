using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal struct EventusCivisLociNavMesh {
        public readonly ErrorAut<IDPunctumViaeTypi> ev;
        public readonly bool estEvanescere; 

        public EventusCivisLociNavMesh(ErrorAut<IDPunctumViaeTypi> ev, bool estEvanescere) {
            this.ev = ev;
            this.estEvanescere = estEvanescere;
        }
    }
 
    internal interface ICivisLociNavMesh {
        bool EstAdPerveni(float distantia);
        bool EstMigrare { get; }
        void Activare();
        void Deactivare();
        void Transporto(Vector3 positio);
        EventusCivisLociNavMesh IncipereMigrare();
        EventusCivisLociNavMesh Migrare();
        IDPunctumViaeTypi TypusAntecedens { get; }
        IDPunctumViaeTypi TypusConsequens { get; }
   }
}


