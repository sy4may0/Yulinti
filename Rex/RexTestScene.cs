using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.Exercitus;

namespace Yulinti.Rex {
    public sealed class RexTestScene : MonoBehaviour {
        [SerializeField] private ResolvorAnchorae _resolvorAnchorae;
        [SerializeField] private Configuratio _configuratio;

        private DuxExercitus _dux;

        private void Awake() {
            _resolvorAnchorae.Resolvo();
            _resolvorAnchorae.Validare();
        }

        private void Start() {
        }

        private void Update() {
        }

        private void FixedUpdate() {
        }

        private void LateUpdate() {
        }
    }
}
