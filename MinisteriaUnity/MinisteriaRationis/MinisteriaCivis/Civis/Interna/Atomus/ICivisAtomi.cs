using UnityEngine.AI;
using UnityEngine;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface ICivisAtomi {
        public GameObject RadixCivis { get; }
        public NihilAut<GameObject> Civis { get; }
        public NihilAut<CharacterController> CharacterController { get; }
        public NihilAut<Animator> Animator { get; }
        public NihilAut<SkinnedMeshRenderer> Figura { get; }
        public NihilAut<NavMeshAgent> NavMeshAgent { get; }

        public void Activare();
        public void Deactivare();
        public bool EstActivum();
        public void Dispose();
    }
}