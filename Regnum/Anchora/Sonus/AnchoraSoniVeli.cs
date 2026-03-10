using UnityEngine;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.Regnum.Anchora {
    public class AnchoraSoniVeli : MonoBehaviour, IAnchoraSoniVeli {
        [SerializeField] private AudioSource _fonsSoniVeli;

        public AudioSource FonsSoniVeli => _fonsSoniVeli;

        public bool Validare() {
            if (_fonsSoniVeli == null) {
                Carnifex.Intermissio(LogTextus.AnchoraSoniVeli_ANCHORASONIVELI_FONSSONIVELI_NULL);
                return false;
            }
            return true;
        }
    }
}