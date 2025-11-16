using UnityEngine;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public class ConfiguratioCameraPrincips : IConfiguratioCamera {
        [Header("ConfiguratioCameraPrincips/MainCamera設定")]
        [SerializeField] private Camera _camera;

        public Camera Camera => _camera;
    }
}