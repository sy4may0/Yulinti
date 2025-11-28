using UnityEngine;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ConfiguratioMinisterii {
    [System.Serializable]
    public class ConfiguratioPunctumViae {
        [Header("ConfiguratioPunctumViae/WayPointのGameObjectリスト")]
        [SerializeField] private GameObject[] _punctaViae;
        
        public NihilAut<GameObject[]> PunctaViae => new NihilAut<GameObject[]>(_punctaViae);
    }
}