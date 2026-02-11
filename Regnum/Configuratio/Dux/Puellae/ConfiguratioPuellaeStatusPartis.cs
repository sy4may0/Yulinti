using UnityEngine;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeStatusPartis", menuName = "Yulinti/Rex/ConfiguratioPuellaeStatusPartis")]
    public sealed class ConfiguratioPuellaeStatusPartis : ScriptableObject, IConfiguratioPuellaeStatusPartis {
        [SerializeField] private IDPuelleaStatusPartis id;
        [SerializeField] private IDPuellaeAnimationisContinuata idAnimationisIntrare;
        [SerializeField] private IDPuellaeAnimationisContinuata idAnimationisExire;
        [SerializeField] private bool ludereExire = false;
        [SerializeField] private bool estLevigatum = false;

        public IDPuelleaStatusPartis Id => id;
        public IDPuellaeAnimationisContinuata IdAnimationisIntrare => idAnimationisIntrare;
        public IDPuellaeAnimationisContinuata IdAnimationisExire => idAnimationisExire;
        public bool LudereExire => ludereExire;
        public bool EstLevigatum => estLevigatum;
    }
}