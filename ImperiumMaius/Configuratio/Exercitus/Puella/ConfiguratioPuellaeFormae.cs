using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.Officia.Instrumentarium;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeFormae", menuName = "Yulinti/Configuratio/Exercitus/Puella/ConfiguratioPuellaeFormae")]
    public sealed class ConfiguratioPuellaeFormae : ScriptableObject, IConfiguratioPuellaeFormae {
        [SerializeField] private IDPuellaeFormae id;
        [SerializeField] private Vector3 magnitudoMaxima;
        [SerializeField] private Vector3 magnitudoMedia;
        [SerializeField] private Vector3 magnitudoMinima;
        [SerializeField] private IDPuellaeOssis[] ossa;

        public IDPuellaeFormae Id => id;
        public System.Numerics.Vector3 MagnitudoMaxima => InterpresNumeri.ToNumerics(magnitudoMaxima);
        public System.Numerics.Vector3 MagnitudoMedia => InterpresNumeri.ToNumerics(magnitudoMedia);
        public System.Numerics.Vector3 MagnitudoMinima => InterpresNumeri.ToNumerics(magnitudoMinima);
        public IDPuellaeOssis[] Ossa => ossa;
    }
}