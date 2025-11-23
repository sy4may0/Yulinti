using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeOssis : IConfiguratioPuellaeOssis {
        [Header("ConfiguratioPuellaeOssis/RigRootボーン設定")]
        [SerializeField] private Transform _rigRoot;

        [Header("ConfiguratioPuellaeOssis/ボーンパス設定")]
        [SerializeField] private string _rootPath = "root";
        [SerializeField] private string _hipsPath = "root/Hips";
        [SerializeField] private string _rightUpperLegPath = "root/Hips/RightUpperLeg";
        [SerializeField] private string _rightLowerLegPath = "root/Hips/RightUpperLeg/RightLowerLeg";
        [SerializeField] private string _rightFootPath = "root/Hips/RightUpperLeg/RightLowerLeg/RightFoot";
        [SerializeField] private string _rightToePath = "root/Hips/RightUpperLeg/RightLowerLeg/RightFoot/toes_01.r";
        [SerializeField] private string _leftUpperLegPath = "root/Hips/LeftUpperLeg";
        [SerializeField] private string _leftLowerLegPath = "root/Hips/LeftUpperLeg/LeftLowerLeg";
        [SerializeField] private string _leftFootPath = "root/Hips/LeftUpperLeg/LeftLowerLeg/LeftFoot";
        [SerializeField] private string _leftToePath = "root/Hips/LeftUpperLeg/LeftLowerLeg/LeftFoot/toes_01.l";
        [SerializeField] private string _rightX150pinPath = "root/Hips/LegJointX150.r";
        [SerializeField] private string _rightY90pinPath = "root/Hips/LegJointY90.r";
        [SerializeField] private string _leftX150pinPath = "root/Hips/LegJointX150.l";
        [SerializeField] private string _leftY90pinPath = "root/Hips/LegJointY90.l";

        public NihilAut<Transform> RigRoot => new NihilAut<Transform>(_rigRoot);
        public string RootPath => _rootPath;
        public string HipsPath => _hipsPath;
        public string RightUpperLegPath => _rightUpperLegPath;
        public string RightLowerLegPath => _rightLowerLegPath;
        public string RightFootPath => _rightFootPath;
        public string RightToePath => _rightToePath;
        public string LeftUpperLegPath => _leftUpperLegPath;
        public string LeftLowerLegPath => _leftLowerLegPath;
        public string LeftFootPath => _leftFootPath;
        public string LeftToePath => _leftToePath;
        public string RightX150pinPath => _rightX150pinPath;
        public string RightY90pinPath => _rightY90pinPath;
        public string LeftX150pinPath => _leftX150pinPath;
        public string LeftY90pinPath => _leftY90pinPath;
    }
}
