using UnityEngine;
using UnityEngine.InputSystem;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.Anchora {
    public sealed class AnchoraInput : MonoBehaviour, IAnchora, IAnchoraInput {
        [SerializeField] private InputActionReference _moveInput;
        [SerializeField] private InputActionReference _sprintInput;
        [SerializeField] private InputActionReference _crouchInput;

        public InputActionReference MoveInput => _moveInput;
        public InputActionReference SprintInput => _sprintInput;
        public InputActionReference CrouchInput => _crouchInput;

        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        public bool Validare() {
            bool result = true;
            if (_moveInput == null) {
                Errorum.Fatal(IDErrorum.ANCHORAINPUT_MOVEINPUT_NULL);
                result = false;
            }
            if (_sprintInput == null) {
                Errorum.Fatal(IDErrorum.ANCHORAINPUT_SPRINTINPUT_NULL);
                result = false;
            }
            if (_crouchInput == null) {
                Errorum.Fatal(IDErrorum.ANCHORAINPUT_CROUCHINPUT_NULL);
                result = false;
            }
            return result;
        }
    }
}
