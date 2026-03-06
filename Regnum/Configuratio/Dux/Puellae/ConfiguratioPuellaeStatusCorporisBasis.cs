using UnityEngine;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    public abstract class ConfiguratioPuellaeStatusCorporisBasis : ScriptableObject, IConfiguratioPuellaeStatusCorporis {
        [SerializeField] private IDPuellaeStatusCorporis id;
        [SerializeField] private IDPuellaeAnimationis idAnimationisIntrare;
        [SerializeField] private IDPuellaeAnimationis idAnimationis;
        [SerializeField] private IDPuellaeAnimationis idAnimationisExire;
        [SerializeField] private float consumptioVigorisSec;
        [SerializeField] private float consumptioPatientiaeSec;
        [SerializeField] private float incrementumAetherisSec;
        [SerializeField] private float intentio;
        [SerializeField] private float claritas;
        [SerializeField] private float sonusQuietes;
        [SerializeField] private float sonusMotus;

        public IDPuellaeStatusCorporis Id => id;
        public IDPuellaeAnimationis IdAnimationisIntrare => idAnimationisIntrare;
        public IDPuellaeAnimationis IdAnimationis => idAnimationis;
        public IDPuellaeAnimationis IdAnimationisExire => idAnimationisExire;

        public float ConsumptioVigorisSec => consumptioVigorisSec;
        public float ConsumptioPatientiaeSec => consumptioPatientiaeSec;
        public float IncrementumAetherisSec => incrementumAetherisSec;
        public float Intentio => intentio;
        public float Claritas => claritas;
        public float SonusQuietes => sonusQuietes;
        public float SonusMotus => sonusMotus;
    }
}