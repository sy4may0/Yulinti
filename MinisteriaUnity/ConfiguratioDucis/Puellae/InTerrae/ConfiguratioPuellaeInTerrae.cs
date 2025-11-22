using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.ConfiguratioDucis {
    [System.Serializable]
    public class ConfiguratioPuellaeInTerrae {
        [Header("ConfiguratioPuellaeInTerrae/Cast位置設定")]
        [SerializeField] private float _raycastAltitudo = 1.0f;
        [SerializeField] private float _raycastDistantia = 1.0f;

        [Header("ConfiguratioPuellaeInTerrae/足補正高度")]
        [SerializeField] private float _pesYCorrectivus = 0.113f;
        [SerializeField] private float _digitusPedisYCorrectivus = 0.034f;

        public float RaycastAltitudo => _raycastAltitudo;
        public float RaycastDistantia => _raycastDistantia;
        public float PesYCorrectivus => _pesYCorrectivus;
        public float DigitusPedisYCorrectivus => _digitusPedisYCorrectivus;
    }
}
