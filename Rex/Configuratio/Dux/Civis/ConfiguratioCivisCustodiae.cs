using UnityEngine;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioCivisCustodiae : IConfiguratioCivisCustodiae {
        [SerializeField] private float distantiaCustodiae = 25f;
        [SerializeField] private float distantiaCustodiaeMaxima = 3f;
        [SerializeField] private float distantiaCustodiaeAscensus = 12f;
        [SerializeField] private float precalculusDistantiaAscensus = 10f;
        [SerializeField] private float ratioVisus = 15f;
        [SerializeField] private float limenVigilantia = 50f;
        [SerializeField] private float limenDetectio = 90f;
        [SerializeField] private float consumptioVisaeDetectioSec = -10f;
        [SerializeField] private float consumptioVisaeSec = -15f;
        [SerializeField] private float tempusStudiumAmittereSec = 5f;
        [SerializeField] private float tempusStudiumAmittereMaximaSec = 10f;
        [SerializeField] private float praeruptioTempusAmittere = 12f;

        public float DistantiaCustodiae => distantiaCustodiae;
        public float DistantiaCustodiaeMaxima => distantiaCustodiaeMaxima;
        public float DistantiaCustodiaeAscensus => distantiaCustodiaeAscensus;
        public float PrecalculusDistantiaAscensus => precalculusDistantiaAscensus;
        public float RatioVisus => ratioVisus;
        public float LimenVigilantia => limenVigilantia;
        public float LimenDetectio => limenDetectio;
        public float ConsumptioVisaeDetectioSec => consumptioVisaeDetectioSec;
        public float ConsumptioVisaeSec => consumptioVisaeSec;
        public float TempusStudiumAmittereSec => tempusStudiumAmittereSec;
        public float TempusStudiumAmittereMaximaSec => tempusStudiumAmittereMaximaSec;
        public float PraeruptioTempusAmittere => praeruptioTempusAmittere;
    }
}