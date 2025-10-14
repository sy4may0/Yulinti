using UnityEngine;
using UnityEngine.InputSystem;

namespace Yulinti.CharacterController
{
    [System.Serializable]
    public class InputProvider
    {
        [SerializeField] private InputActionReference _moveInput;
        [SerializeField] private InputActionReference _sprintInput;
        [SerializeField] private InputActionReference _crouchInput;

        public Vector2 Move  => _moveInput?.action?.enabled  == true ? _moveInput.action.ReadValue<Vector2>() : Vector2.zero;
        public bool   Sprint => _sprintInput?.action?.enabled == true && _sprintInput.action.IsPressed();
        public bool   Crouch => _crouchInput?.action?.enabled == true && _crouchInput.action.IsPressed();
    }

    [System.Serializable]
    public class CameraProvider
    {
        [SerializeField] private Camera _camera;
        public Camera Camera => _camera;
        public Quaternion YawRotation
        {
            get
            {
                if (!_camera) return Quaternion.identity;
                var e = _camera.transform.eulerAngles;
                return Quaternion.Euler(0f, e.y, 0f);
            }
        }
        public Vector3 RightXZ   => (YawRotation * Vector3.right).normalized;
        public Vector3 ForwardXZ => (YawRotation * Vector3.forward).normalized;
    }
}