using UnityEngine;

namespace Yulinti.GlobalSetting {
    [CreateAssetMenu(fileName = "NPCSetting", menuName = "GlobalSetting/NPCSetting")]
    public class NPCSetting : ScriptableObject {
        [SerializeField] private int _maxNPCs = 100;

        public int MaxNPCs => _maxNPCs;
    }
}