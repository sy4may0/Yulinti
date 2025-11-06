using UnityEngine;

namespace Yulinti.CharacterControllSuite {
    public sealed class PlayerConfig : ScriptableObject {
        [SerializeField] private StateConfigCommon _stateConfigCommon;
        [SerializeField] private AnimationConfigCommon _animationConfigCommon;
        [SerializeField] private StateConfig _stateConfig;
        [SerializeField] private MoverConfig _moverConfig;
        [SerializeField] private GrounderConfig _grounderConfig;

        public StateConfigCommon StateConfigCommon => _stateConfigCommon;
        public AnimationConfigCommon AnimationConfigCommon => _animationConfigCommon;
        public StateConfig StateConfig => _stateConfig;
        public MoverConfig MoverConfig => _moverConfig;
        public GrounderConfig GrounderConfig => _grounderConfig;

    }
}