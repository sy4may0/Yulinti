using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Instrumentarium;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisPersonae",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/Personae/CivisPersonae")]
    public sealed class ConfiguratioCivisPersonae : ScriptableObject, IConfiguratioCivisPersonae {
        [Header("PersonaID")]
        [SerializeField] private IDCivisPersonae idCivisPersonae;
        [Header("生成確率Weight(大きいほど高確率)")]
        [SerializeField] private int pondusGenerationis;
        [Header("初期体力[min, max]")]
        [SerializeField] private Vector2 vitaeInitialis;
        [Header("視力基準値[min, max]")]
        [SerializeField] private Vector2 visusBasis;
        [Header("聴力基準値[min, max]")]
        [SerializeField] private Vector2 auditusBasis;
        [Header("Anomalia許容量最大[min, max]")]
        [SerializeField] private Vector2 torelantiaAnomaliaeMaxima;
        [Header("Anomalia許容量最小[min, max]")]
        [SerializeField] private Vector2 torelantiaAnomaliaeMinima;

        public IDCivisPersonae IDCivisPersonae => idCivisPersonae;
        public int PondusGenerationis => pondusGenerationis;
        public System.Numerics.Vector2 VitaInitialis => InterpresNumeri.ToNumerics(vitaeInitialis);
        public System.Numerics.Vector2 VisusBasis => InterpresNumeri.ToNumerics(visusBasis);
        public System.Numerics.Vector2 AuditusBasis => InterpresNumeri.ToNumerics(auditusBasis);
        public System.Numerics.Vector2 TorelantiaAnomaliaeMaxima => InterpresNumeri.ToNumerics(torelantiaAnomaliaeMaxima);
        public System.Numerics.Vector2 TorelantiaAnomaliaeMinima => InterpresNumeri.ToNumerics(torelantiaAnomaliaeMinima);
    }
}