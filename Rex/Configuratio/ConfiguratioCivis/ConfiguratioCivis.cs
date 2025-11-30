using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioCivis", menuName = "Yulinti/Rex/ConfiguratioCivis")]
    public sealed class ConfiguratioCivis : ScriptableObject, IConfiguratioCivis {
        [SerializeField] private float _distantiaPelveni = 0.4f;
        
        public float DistantiaPelveni => _distantiaPelveni;
    }
}
