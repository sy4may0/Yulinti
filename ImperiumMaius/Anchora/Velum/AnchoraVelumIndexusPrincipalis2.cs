using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using UnityEngine.UIElements;

namespace Yulinti.ImperiumMaius.Anchora {
    public class AnchoraVelumIndexusPrincipalis2 : MonoBehaviour, IAnchoraVelumIndexusPrincipalis2 {
        [SerializeField] private UIDocument _velumIndexusPrincipalis;
        [SerializeField] private VisualTreeAsset _parsPulsabulumIndexusPrincipalis;

        public UIDocument VelumIndexusPrincipalis => _velumIndexusPrincipalis;
        public VisualTreeAsset ParsPulsabulumIndexusPrincipalis => _parsPulsabulumIndexusPrincipalis;

        public bool Validare() {
            if (_velumIndexusPrincipalis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumIndexusPrincipalis_ANCHORAVELUMINDEXUSPRINCIPALIS_VELUMINDEXUSPRINCIPALIS_NULL);
                return false;
            }
            if (_parsPulsabulumIndexusPrincipalis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumIndexusPrincipalis_ANCHORAVELUMINDEXUSPRINCIPALIS_PARSPULSABULUMINDEXUSPRINCIPALIS_NULL);
                return false;
            }
            return true;
        }
    }
}