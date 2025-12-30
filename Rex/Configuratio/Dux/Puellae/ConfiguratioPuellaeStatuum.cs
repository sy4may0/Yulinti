using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeStatuum : IConfiguratioPuellaeStatuum {
        [SerializeField] private float limenInputQuadratum = 0.001f;
        [SerializeField] private float tempusLevigatumRotationis = 0.3f;
        [SerializeField] private float tempusLevigatumMax = 1.0f;
        [SerializeField] private float tempusLevigatumMin = 0.05f;
        [SerializeField] private float acceleratioGravitatis = -9.81f;
        [SerializeField] private float velocitasContactus = -9.81f;
        [SerializeField] private float velocitasVerticalisMax = -50.0f;
        [SerializeField] private IDPuellaeAnimationisContinuata idAnimationisPraedefinitus;
        [SerializeField] private ConfiguratioPuellaeStatusCorporis[] statusCorporum;
        [SerializeField] private ConfiguratioPuellaeStatusPartis[] statusPartium;
        [SerializeField] private ConfiguratioPuellaeStatusCorporisBasis[] statuumCorporis;

        public float LimenInputQuadratum => limenInputQuadratum;
        public float TempusLevigatumRotationis => tempusLevigatumRotationis;
        public float TempusLevigatumMax => tempusLevigatumMax;
        public float TempusLevigatumMin => tempusLevigatumMin;
        public float AcceleratioGravitatis => acceleratioGravitatis;
        public float VelocitasContactus => velocitasContactus;
        public float VelocitasVerticalisMax => velocitasVerticalisMax;
        public IDPuellaeAnimationisContinuata IdAnimationisPraedefinitus => idAnimationisPraedefinitus;
        public IConfiguratioPuellaeStatusCorporis[] StatusCorporum => statusCorporum;
        public IConfiguratioPuellaeStatusPartis[] StatusPartium => statusPartium;
        public IConfiguratioPuellaeStatusCorporis2[] StatuumCorporis => statuumCorporis;
    }
}