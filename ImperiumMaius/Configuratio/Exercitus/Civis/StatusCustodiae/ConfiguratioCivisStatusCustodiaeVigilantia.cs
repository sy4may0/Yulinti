using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisStatusCustodiaeVigilantia",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/StatusCustodiae/Vigilantia")]
    public sealed class ConfiguratioCivisStatusCustodiaeVigilantia : ScriptableObject, IConfiguratioCivisStatusCustodiaeVigilantia {
        [Header("Intuitus(注視)へ向かう Studium 減衰(毎秒)")]
        [Tooltip("1/deminutioStudiumAdIntuitusSec 秒で Vigilantiaステートが終了する。")]
        [SerializeField] private float deminutioStudiumAdIntuitusSec = 0.5f;

        public float DeminutioStudiumAdIntuitusSec => deminutioStudiumAdIntuitusSec;
    }
}
