using Yulinti.Nucleus.Instrumentarium;
using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumMaius.Anchora {
    public sealed class AnchoraPuellaeCrinisBasis : MonoBehaviour, IAnchora, IAnchoraPuellaeCrinisBasis {
        [SerializeField] private GameObject _ens;
        [SerializeField] private IDPuellaeCrinisBasis _idCrinis;

        public IDPuellaeCrinisBasis Typus => _idCrinis;

        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        public bool Validare() {
            bool result = true;
            if (_ens == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellaeCrinisBasis_ANCHORAPUELLAE_CRINIS_BASIS_INSTANCE_NULL);
                result = false;
            }
            return result;
        }

        public void Activare() {
            if (_ens == null) return;
            if (_ens.activeSelf) return;
            _ens.SetActive(true);
        }

        public void Deactivare() {
            if (_ens == null) return;
            if (!_ens.activeSelf) return;
            _ens.SetActive(false);
        }
    }
}
