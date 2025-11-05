using UnityEngine;
using Yulinti.CharacterControllSuite;
using Yulinti.ServiceSuite;

public class Orchestrator : MonoBehaviour {
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private InputConfig _inputConfig;
    [SerializeField] private CameraConfig _cameraConfig;

    private PlayerController _playerController;
    private MoveInputProvider _moveInputProvider;
    private CameraProvider _cameraProvider;

    private PlayerRuntime _playerRuntime;
    private PlayerRuntimeReadOnly _playerRuntimeRO;
    private PlayerRuntimeCommands _playerRuntimeWO;

    private void Awake() {
        _moveInputProvider = new MoveInputProvider(_inputConfig);
        _cameraProvider = new CameraProvider(_cameraConfig);

        _playerRuntime = new PlayerRuntime(Time.fixedDeltaTime);
        _playerRuntimeRO = new PlayerRuntimeReadOnly(_playerRuntime);
        _playerRuntimeWO = new PlayerRuntimeCommands(_playerRuntime);

        _playerController = new PlayerController(
            _playerConfig,
            _moveInputProvider,
            _cameraProvider
        );
    }

    private void Start() {
        _playerController.Initialize();
    }

    private void Update() {
        // DeltaTimeを更新
        _playerRuntime.DeltaTime = Time.deltaTime;

        _playerController.Tick(_playerRuntimeRO, _playerRuntimeWO);
    }

    private void LateUpdate() {
        _playerController.LateTick();
    }
}

