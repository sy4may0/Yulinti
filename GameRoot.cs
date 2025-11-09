// ゲーム内唯一のMonoBehaviour。
//　Awake(), Start(), Update(), FixedUpdate(), LateUpdate()の起点となる。
using UnityEngine;
using Yulinti.UnityServices;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.CoreServices;


namespace Yulinti {
    public sealed class GameRoot : MonoBehaviour {
        [Header("GameRoot/サービス設定")]
        [SerializeField] private ServiceRootConfig _serviceConfig;

        private ServiceRoot _serviceRoot;

        private void Awake() {
            _serviceRoot = new ServiceRoot(_serviceConfig);
        }
        private void Start() {
        }
        private void Update() {
            float deltaTime = Time.deltaTime;

            // Tick Services
            _serviceRoot.Tick(deltaTime);
        }
        private void FixedUpdate() {
            float fixedDeltaTime = Time.fixedDeltaTime;

            // FixedTick Services
            _serviceRoot.FixedTick(fixedDeltaTime);
        }
        private void LateUpdate() {
        }
    }
}