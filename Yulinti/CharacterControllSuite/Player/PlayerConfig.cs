using UnityEngine;

namespace Yulinti.CharacterControllSuite {
    public sealed class PlayerConfig : ScriptableObject {
        [SerializeField] private PlayerStateConfigCommon _stateConfigCommon;
        [SerializeField] private PlayerAnimationConfigCommon _animationConfigCommon;
        [SerializeField] private PlayerStateConfig _stateConfig;
        [SerializeField] private MoverConfig _moverConfig;
        [SerializeField] private GrounderConfig _grounderConfig;

        public PlayerStateConfigCommon StateConfigCommon => _stateConfigCommon;
        public PlayerAnimationConfigCommon AnimationConfigCommon => _animationConfigCommon;
        public PlayerStateConfig StateConfig => _stateConfig;
        public MoverConfig MoverConfig => _moverConfig;
        public GrounderConfig GrounderConfig => _grounderConfig;

    }
}