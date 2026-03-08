using UnityEngine;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using Yulinti.Unity.Instrumentarium;

namespace Yulinti.Regnum.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeStatuum : IConfiguratioPuellaeStatuum {
        [SerializeField] private float limenInputQuadratum = 0.001f;
        [SerializeField] private float tempusLevigatumRotationis = 0.3f;
        [SerializeField] private float tempusLevigatumMax = 1.0f;
        [SerializeField] private float tempusLevigatumMin = 0.05f;
        [SerializeField] private float acceleratioGravitatis = -9.81f;
        [SerializeField] private float velocitasContactus = -9.81f;
        [SerializeField] private float velocitasVerticalisMax = -50.0f;
        [SerializeField] private IDPuellaeAnimationis idAnimationisPraedefinitus;
        [SerializeField] private ConfiguratioPuellaeStatusCorporisBasis[] statuumCorporis;
        [SerializeField] private ConfiguratioPuellaeStatusPartis[] statuumPartium;
        [SerializeField] private UnityEngine.Vector3 positioIncipalis;
        [SerializeField] private UnityEngine.Quaternion rotatioIncipalis;
        [SerializeField] private IDPuellaeStatusCorporis idStatusCorporisIncipalis = IDPuellaeStatusCorporis.Quies;
        [SerializeField] private float limenVelocitatisIntransQuietes = 0.01f;



        public float LimenInputQuadratum => limenInputQuadratum;
        public float TempusLevigatumRotationis => tempusLevigatumRotationis;
        public float TempusLevigatumMax => tempusLevigatumMax;
        public float TempusLevigatumMin => tempusLevigatumMin;
        public float AcceleratioGravitatis => acceleratioGravitatis;
        public float VelocitasContactus => velocitasContactus;
        public float VelocitasVerticalisMax => velocitasVerticalisMax;
        public IDPuellaeAnimationis IdAnimationisPraedefinitus => idAnimationisPraedefinitus;
        public IConfiguratioPuellaeStatusCorporis[] StatuumCorporis => statuumCorporis;
        public IConfiguratioPuellaeStatusPartis[] StatuumPartium => statuumPartium;

        public System.Numerics.Vector3 PositioIncipalis => InterpresNumeri.ToNumerics(positioIncipalis);
        public System.Numerics.Quaternion RotatioIncipalis => InterpresNumeri.ToNumerics(rotatioIncipalis);

        public IDPuellaeStatusCorporis IDStatusCorporisIncipalis => idStatusCorporisIncipalis;
        public float LimenVelocitatisIntransQuietes => limenVelocitatisIntransQuietes;
    }
}
