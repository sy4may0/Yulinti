using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeStatusPartis", menuName = "Yulinti/Rex/ConfiguratioPuellaeStatusPartis")]
    public sealed class ConfiguratioPuellaeStatusPartis : ScriptableObject, IConfiguratioPuellaeStatusPartis {
        [SerializeField] private IDStatusPartis id;
        [SerializeField] private IDPuellaeAnimationisContinuata idAnimationisIntrare;
        [SerializeField] private IDPuellaeAnimationisContinuata idAnimationisExire;
        [SerializeField] private bool ludereExire = false;
        [SerializeField] private bool estLevigatum = false;

        public IDStatusPartis Id => id;
        public IDPuellaeAnimationisContinuata IdAnimationisIntrare => idAnimationisIntrare;
        public IDPuellaeAnimationisContinuata IdAnimationisExire => idAnimationisExire;
        public bool LudereExire => ludereExire;
        public bool EstLevigatum => estLevigatum;
    }
}