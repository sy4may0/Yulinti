using UnityEngine;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioCivisCustodiae : IConfiguratioCivisCustodiae {
        [SerializeField] private float distantiaCustodiae = 15f;
        [SerializeField] private float distantiaCustodiaeMaxima = 3f;
        [SerializeField] private float limenVigilantia = 30f;
        [SerializeField] private float limenDetectio = 90f;
        [SerializeField] private float consumptioVisaeSec = -5f;

        public float DistantiaCustodiae => distantiaCustodiae;
        public float DistantiaCustodiaeMaxima => distantiaCustodiaeMaxima;
        public float LimenVigilantia => limenVigilantia;
        public float LimenDetectio => limenDetectio;
        public float ConsumptioVisaeSec => consumptioVisaeSec;
    }
}