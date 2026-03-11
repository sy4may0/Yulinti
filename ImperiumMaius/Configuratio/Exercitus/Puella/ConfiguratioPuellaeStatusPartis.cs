using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeStatusPartis", menuName = "Yulinti/Configuratio/Exercitus/Puella/ConfiguratioPuellaeStatusPartis")]
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