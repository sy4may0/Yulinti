using UnityEngine;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeActionisSecundarius : IConfiguratioPuellaeActionisSecundarius {
        [SerializeField] private float raycastAltitudo = 1.0f;
        [SerializeField] private float raycastDistantia = 1.0f;
        [SerializeField] private float pesYCorrectivus = 0.113f;
        [SerializeField] private float digitusPedisYCorrectivus = 0.034f;
        [SerializeField] private float maxElevatio = 0.35f;

        public float RaycastAltitudo => raycastAltitudo;
        public float RaycastDistantia => raycastDistantia;
        public float PesYCorrectivus => pesYCorrectivus;
        public float DigitusPedisYCorrectivus => digitusPedisYCorrectivus;
        public float MaxElevatio => maxElevatio;
    }
}