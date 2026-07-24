using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisCustodiaeStatusVigilantia",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/CustodiaeStatus/Vigilantia")]
    public sealed class ConfiguratioCivisCustodiaeStatusVigilantia : ScriptableObject, IConfiguratioCivisCustodiaeStatusVigilantia {
        [Header("Intuitus(注視)へ向かう Studium 減衰(毎秒)")]
        [Tooltip("1/deminutioStudiumAdIntuitusSec 秒で Vigilantiaステートが終了する。")]
        [SerializeField] private float deminutioStudiumAdIntuitusSec = 0.5f;

        public float DeminutioStudiumAdIntuitusSec => deminutioStudiumAdIntuitusSec;
    }
}
