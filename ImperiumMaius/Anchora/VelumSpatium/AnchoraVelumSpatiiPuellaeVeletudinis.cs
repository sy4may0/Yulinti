using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Anchora {
    public sealed class AnchoraVelumSpatiiPuellaeVeletudinis : MonoBehaviour, IAnchoraVelumSpatiiPuellaeVeletudinis {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _vigor;
        [SerializeField] private Image _patientia;
        [SerializeField] private TextMeshProUGUI _text;

        public bool EstActivum => estActivum();
        public bool EstActivumCorrigere => _text.gameObject.activeSelf;

        private bool estActivum() {
            return _vigor.gameObject.activeSelf && _patientia.gameObject.activeSelf;
        }

        public void Incarnare() {
            _vigor.gameObject.SetActive(true);
            _patientia.gameObject.SetActive(true);
        }

        public void Spirituare() {
            _vigor.gameObject.SetActive(false);
            _patientia.gameObject.SetActive(false);
        }

        public Vector3 Positio => _rectTransform.position;
        public Quaternion Rotatio => _rectTransform.rotation;
        public Vector3 Scala => _rectTransform.localScale;
        public bool Validare() {
            return _rectTransform != null && _vigor != null && _patientia != null;
        }

        public void PonoRotationem(Quaternion rotationem) {
            if (!EstActivum) return;
            _rectTransform.rotation = rotationem;
        }

        public void PonoVigorem(float vigor) {
            if (!EstActivum) return;
            _vigor.fillAmount = Mathf.Clamp01(vigor);
        }

        public void PonoPatientiam(float patientia) {
            if (!EstActivum) return;
            _patientia.fillAmount = Mathf.Clamp01(patientia);
        }

        public void IncarnareCorrigere() {
            _text.gameObject.SetActive(true);
        }

        public void SpirituareCorrigere() {
            _text.gameObject.SetActive(false);
        }

        public void PonoTextus(string textus) {
            if (!EstActivumCorrigere) return;
            _text.SetText(textus);
        }
    }
}
