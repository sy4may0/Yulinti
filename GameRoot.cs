// ゲーム内唯一のMonoBehaviour。
//　Awake(), Start(), Update(), FixedUpdate(), LateUpdate()の起点となる。
using UnityEngine;
using Yulinti.UnityServices;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaNuclei.ModeratorErrorum;


namespace Yulinti {
    public sealed class GameRoot : MonoBehaviour {
        [Header("GameRoot/サービス設定")]
        [SerializeField] private ServiceRootConfig _serviceConfig;

        private ServiceRoot _serviceRoot;
        private float _deltaTime;
        private float _fixedDeltaTime;

        private void Awake() {
            _serviceRoot = new ServiceRoot(_serviceConfig);
        }
        private void Start() {
        }
        private void Update() {
            _deltaTime = Time.deltaTime;

            // Tick Services
            _serviceRoot.Tick(_deltaTime);
        }
        private void FixedUpdate() {
            _fixedDeltaTime = Time.fixedDeltaTime;

            // FixedTick Services
            _serviceRoot.FixedTick(_fixedDeltaTime);
        }
        private void LateUpdate() {
            // LateTick Services
            _serviceRoot.LateTick(_deltaTime);
        }
    }
}