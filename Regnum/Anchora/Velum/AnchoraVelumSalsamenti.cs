using UnityEngine;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using UnityEngine.UIElements;

namespace Yulinti.Regnum.Anchora {
    public class AnchoraVelumSalsamenti : MonoBehaviour, IAnchoraVelumSalsamenti {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private VisualTreeAsset _formaSalsamentumItem;

        public UIDocument UIDocument => _uiDocument;
        public VisualTreeAsset FormaSalsamentumItem => _formaSalsamentumItem;

        public bool Validare() {
            if (_uiDocument == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumSalsamenti_ANCHORAVELUMSALSAMENTI_UIDOCUMENT_NULL);
                return false;
            }

            if (_formaSalsamentumItem == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumSalsamenti_ANCHORAVELUMSALSAMENTI_FORMASALSAMENTUMITEM_NULL);
                return false;
            }

            return true;
        }
    }
}