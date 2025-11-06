using UnityEngine;
namespace Yulinti.FukaHairControllSuite
{
    [System.Serializable]
    public sealed class HairConfig
    {
        [Header("FukaHairControllSuite/Fuka髪制御設定")]
        [Tooltip("髪の毛ルート")]
        [SerializeField] private Transform _hairRoot;
        [Tooltip("頭ボーン")]
        [SerializeField] private Transform _headBone;

        public Transform HairRoot => _hairRoot;
        public Transform HeadBone => _headBone;
    }
}