using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public class ConfiguratioCameraPrincips : IConfiguratioCamera {
        [Header("ConfiguratioCameraPrincips/MainCamera設定")]
        [SerializeField] private Camera _camera;

        public NihilAut<Camera> Camera => new NihilAut<Camera>(_camera);
    }
}
