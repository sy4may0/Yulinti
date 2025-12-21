using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeStatusCorporis", menuName = "Yulinti/Rex/ConfiguratioPuellaeStatusCorporis")]
    public sealed class ConfiguratioPuellaeStatusCorporis : ScriptableObject, IConfiguratioPuellaeStatusCorporis {
        [SerializeField] private IDPuellaeStatusCorporis id;
        [SerializeField] private IDPuellaeModiMotus idModusMotus;
        [SerializeField] private IDPuellaeAnimationisContinuata idAnimationisIntrare;
        [SerializeField] private IDPuellaeAnimationisContinuata idAnimationisExire;
        [SerializeField] private bool ludereExire = false;
        [SerializeField] private float velocitasDesiderata = 0.0f;
        [SerializeField] private float acceleratio = 0.0f;
        [SerializeField] private float deceleratio = 0.0f;
        [SerializeField] private bool estLevigatum = false;

        public IDPuellaeStatusCorporis Id => id;
        public IDPuellaeModiMotus IdModusMotus => idModusMotus;
        public IDPuellaeAnimationisContinuata IdAnimationisIntrare => idAnimationisIntrare;
        public IDPuellaeAnimationisContinuata IdAnimationisExire => idAnimationisExire;
        public bool LudereExire => ludereExire;
        public float VelocitasDesiderata => velocitasDesiderata;
        public float Acceleratio => acceleratio;
        public float Deceleratio => deceleratio;
        public bool EstLevigatum => estLevigatum;
    }
}