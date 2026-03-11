using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using UnityEngine.UIElements;

namespace Yulinti.Imperium.Anchora {
    public class AnchoraVelumIndexusPrincipalis : MonoBehaviour, IAnchoraVelumIndexusPrincipalis {
        [SerializeField] private UIDocument _uiDocument;

        public UIDocument UIDocument => _uiDocument;

        public bool Validare() {
            if (_uiDocument == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumIndexusPrincipalis_ANCHORAVELUMINDEXUSPRINCIPALIS_UIDOCUMENT_NULL);
                return false;
            }
            return true;
        }
    }
}