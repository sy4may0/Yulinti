using UnityEngine;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeStatusPartis", menuName = "Yulinti/Rex/ConfiguratioPuellaeStatusPartis")]
    public sealed class ConfiguratioPuellaeStatusPartis : ScriptableObject, IConfiguratioPuellaeStatusPartis {
        [SerializeField] private IDPuelleaStatusPartis id;
        [SerializeField] private IDPuellaeAnimationis idAnimationisIntrare;
        [SerializeField] private IDPuellaeAnimationis idAnimationis;
        [SerializeField] private IDPuellaeAnimationis idAnimationisExire;
        [SerializeField] private bool estLevigatum = false;

        public IDPuelleaStatusPartis Id => id;
        public IDPuellaeAnimationis IdAnimationisIntrare => idAnimationisIntrare;
        public IDPuellaeAnimationis IdAnimationis => idAnimationis;
        public IDPuellaeAnimationis IdAnimationisExire => idAnimationisExire;
        public bool EstLevigatum => estLevigatum;
    }
}