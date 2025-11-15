using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public sealed class FukaCorrectiveShapeConfig {
        [SerializeField] private FukaHipsCorrectiveShapeConfig _hipsCorrectiveShapeConfig;
        [SerializeField] private FukaRightKneeCorrectiveShapeConfig _rightKneeCorrectiveShapeConfig;
        [SerializeField] private FukaLeftKneeCorrectiveShapeConfig _leftKneeCorrectiveShapeConfig;

        public FukaHipsCorrectiveShapeConfig HipsCorrectiveShapeConfig => _hipsCorrectiveShapeConfig;
        public FukaRightKneeCorrectiveShapeConfig RightKneeCorrectiveShapeConfig => _rightKneeCorrectiveShapeConfig;
        public FukaLeftKneeCorrectiveShapeConfig LeftKneeCorrectiveShapeConfig => _leftKneeCorrectiveShapeConfig;
    }
}
        