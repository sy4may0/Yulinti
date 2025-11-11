using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public sealed class FukaRootConfig {
        [SerializeField] private FukaBoneConfig _fukaBoneConfig;
        [SerializeField] private FukaCharacterControllerConfig _fukaCharacterControllerConfig;
        [SerializeField] private FukaAnimationConfig _fukaAnimationConfig;
        [SerializeField] private FukaCorrectiveShapeConfig _fukaCorrectiveShapeConfig;
        [SerializeField] private FukaGrounderConfig _fukaGrounderConfig;

        public FukaBoneConfig FukaBoneConfig => _fukaBoneConfig;
        public FukaCharacterControllerConfig FukaCharacterControllerConfig => _fukaCharacterControllerConfig;
        public FukaAnimationConfig FukaAnimationConfig => _fukaAnimationConfig;
        public FukaCorrectiveShapeConfig FukaCorrectiveShapeConfig => _fukaCorrectiveShapeConfig;
        public FukaGrounderConfig FukaGrounderConfig => _fukaGrounderConfig;
    }
}