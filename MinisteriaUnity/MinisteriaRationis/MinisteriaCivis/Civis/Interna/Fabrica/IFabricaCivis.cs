using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface IFabricaCivis {
        public ErrorAut<ICivisAtomi> ManifestatioCivis();
        public void DeletioCivis(ICivisAtomi civis);
    }
}