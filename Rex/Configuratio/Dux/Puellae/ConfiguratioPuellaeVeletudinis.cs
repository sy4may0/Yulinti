using UnityEngine;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeVeletudinis : IConfiguratioPuellaeVeletudinis {
        [SerializeField] private float limenExhauritaVigoris = 0f;
        [SerializeField] private float limenRefectaVigoris = 0.3f;
        [SerializeField] private float limenExhauritaPatientiae = 0.00001f;
        [SerializeField] private float limenRefectaPatientiae = 0.3f;
        [SerializeField] private float velocitasSoniMaxima = 3.0f;

        public float LimenExhauritaVigoris => limenExhauritaVigoris;
        public float LimenRefectaVigoris => limenRefectaVigoris;
        public float LimenExhauritaPatientiae => limenExhauritaPatientiae;
        public float LimenRefectaPatientiae => limenRefectaPatientiae;
        public float VelocitasSoniMaxima => velocitasSoniMaxima;
    }
}