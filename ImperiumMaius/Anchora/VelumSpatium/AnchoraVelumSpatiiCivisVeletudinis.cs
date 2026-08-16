using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Anchora {
    public sealed class AnchoraVelumSpatiiCivisVeletudinis : MonoBehaviour, IAnchoraVelumSpatiiCivisVeletudinis {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _intentio;
        [SerializeField] private Image _suspecta;
        [SerializeField] private TextMeshProUGUI _text;

        public bool EstActivum => estActivum();
        public bool EstActivumCorrigere => _text != null && _text.gameObject.activeSelf;

        private bool estActivum() {
            return _intentio.gameObject.activeSelf && _suspecta.gameObject.activeSelf;
        }

        public void Incarnare() {
            _intentio.gameObject.SetActive(true);
            _suspecta.gameObject.SetActive(true);
        }

        public void Spirituare() {
            _intentio.gameObject.SetActive(false);
            _suspecta.gameObject.SetActive(false);
        }

        public Vector3 Positio => _rectTransform.position;
        public Quaternion Rotatio => _rectTransform.rotation;
        public Vector3 Scala => _rectTransform.localScale;
        public bool Validare() {
            return _rectTransform != null && _intentio != null && _suspecta != null && _text != null;
        }

        public void PonoRotationem(Quaternion rotationem) {
            if (!EstActivum) return;
            _rectTransform.rotation = rotationem;
        }

        public void PonoIntentionem(float intentio) {
            if (!EstActivum) return;
            _intentio.fillAmount = Mathf.Clamp01(intentio);
        }

        public void PonoSuspectum(float suspecta) {
            if (!EstActivum) return;
            _suspecta.fillAmount = Mathf.Clamp01(suspecta);
        }

        public void IncarnareCorrigere() {
            if (_text == null) return;
            _text.gameObject.SetActive(true);
        }

        public void SpirituareCorrigere() {
            if (_text == null) return;
            _text.gameObject.SetActive(false);
        }

        public void PonoTextus(string textus) {
            if (!EstActivumCorrigere) return;
            _text.SetText(textus);
        }
    }
}
