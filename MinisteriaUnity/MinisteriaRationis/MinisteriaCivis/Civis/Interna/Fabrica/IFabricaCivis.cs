using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface IFabricaCivis {
        public ErrorAut<GameObject> ManifestatioCivis();
        public void DeletioCivis(NihilAut<GameObject> civis);
    }
}