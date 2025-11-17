using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public class ConfiguratioPuellaeRelationisTerrae : IConfiguratioPuellaeRelationisTerrae {
        [Header("ConfiguratioPuellaeRelationisTerrae/足設定")]
        [SerializeField] private Transform _leftFoot;
        [SerializeField] private Transform _leftToe;
        [SerializeField] private Transform _rightFoot;
        [SerializeField] private Transform _rightToe;

        public Transform LeftFoot => _leftFoot;
        public Transform LeftToe => _leftToe;
        public Transform RightFoot => _rightFoot;
        public Transform RightToe => _rightToe;
   }
}