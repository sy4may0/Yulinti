using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    public abstract class ConfiguratioPuellaeStatusCorporisBasis : ScriptableObject, IConfiguratioPuellaeStatusCorporis {
        [SerializeField] private IDPuellaeStatusCorporis id;
        [SerializeField] private IDPuellaeAnimationisContinuata idAnimationisIntrare;
        [SerializeField] private IDPuellaeAnimationisContinuata idAnimationisExire;
        [SerializeField] private bool ludereExire;
        [SerializeField] private float consumptioVigorisSec;
        [SerializeField] private float consumptioPatientiaeSec;
        [SerializeField] private float incrementumAetherisSec;
        [SerializeField] private float intentio;

        public IDPuellaeStatusCorporis Id => id;
        public IDPuellaeAnimationisContinuata IdAnimationisIntrare => idAnimationisIntrare;
        public IDPuellaeAnimationisContinuata IdAnimationisExire => idAnimationisExire;
        public bool LudereExire => ludereExire;

        public float ConsumptioVigorisSec => consumptioVigorisSec;
        public float ConsumptioPatientiaeSec => consumptioPatientiaeSec;
        public float IncrementumAetherisSec => incrementumAetherisSec;
        public float Intentio => intentio;
    }
}