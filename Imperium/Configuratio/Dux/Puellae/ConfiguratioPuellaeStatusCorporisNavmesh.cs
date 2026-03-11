using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Imperium.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeStatusCorporisNavmesh", menuName = "Yulinti/Rex/ConfiguratioPuellaeStatusCorporisNavmesh")]
    public sealed class ConfiguratioPuellaeStatusCorporisNavmesh : ConfiguratioPuellaeStatusCorporisBasis, IConfiguratioPuellaeStatusCorporisNavmesh {
        [SerializeField] private IDPuellaeStatusCorporisModiNavmesh idModiNavmesh;
        [SerializeField] private float velocitasDesiderata;
        [SerializeField] private float acceleratio;
        [SerializeField] private int velocitasRotationis;
        [SerializeField] private float distantiaDeaccelerationis;

        public IDPuellaeStatusCorporisModiNavmesh IdModiNavmesh => idModiNavmesh;
        public float VelocitasDesiderata => velocitasDesiderata;
        public float Acceleratio => acceleratio;
        public int VelocitasRotationis => velocitasRotationis;
        public float DistantiaDeaccelerationis => distantiaDeaccelerationis;
    }
}