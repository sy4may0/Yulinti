using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public class ConfiguratioPuellaeRelationisTerrae : IConfiguratioPuellaeRelationisTerrae {
        [Header("ConfiguratioPuellaeRelationisTerrae/足設定")]
        [SerializeField] private Transform _leftFoot;
        [SerializeField] private Transform _leftToe;
        [SerializeField] private Transform _rightFoot;
        [SerializeField] private Transform _rightToe;
        [SerializeField] private LayerMask _raycastStratum;

        public NihilAut<Transform> LeftFoot => new NihilAut<Transform>(_leftFoot);
        public NihilAut<Transform> LeftToe => new NihilAut<Transform>(_leftToe);
        public NihilAut<Transform> RightFoot => new NihilAut<Transform>(_rightFoot);
        public NihilAut<Transform> RightToe => new NihilAut<Transform>(_rightToe);
        public NihilAut<LayerMask> RaycastStratum => new NihilAut<LayerMask>(_raycastStratum);
    }
}
