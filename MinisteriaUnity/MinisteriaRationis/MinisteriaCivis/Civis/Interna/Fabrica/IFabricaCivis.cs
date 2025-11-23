using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface IFabricaCivis {
        public NihilAut<GameObject> ManifestatioCivis();
        public void DeletioCivis(NihilAut<GameObject> civis);
    }
}