using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioCivisStatusCorporisNavmesh", menuName = "Yulinti/Rex/ConfiguratioCivisStatusCorporisNavmesh")]
    public class ConfiguratioCivisStatusCorporisNavmesh : ConfiguratioCivisStatusCorporisBasis, IConfiguratioCivisStatusCorporisNavmesh {
        [SerializeField] private IDCivisStatusCorporisModiNavmesh idModiNavmesh;
        [SerializeField] private IDPunctumViaeTypi typusPunctumViae;
        [SerializeField] private float velocitasDesiderata;
        [SerializeField] private float acceleratio;
        [SerializeField] private int velocitasRotationis;
        [SerializeField] private float distantiaDeaccelerationis;


        public IDCivisStatusCorporisModiNavmesh IdModiNavmesh => idModiNavmesh;
        public IDPunctumViaeTypi TypusPunctumViae => typusPunctumViae;
        public float VelocitasDesiderata => velocitasDesiderata;
        public float Acceleratio => acceleratio;
        public int VelocitasRotationis => velocitasRotationis;
        public float DistantiaDeaccelerationis => distantiaDeaccelerationis;
    }
}