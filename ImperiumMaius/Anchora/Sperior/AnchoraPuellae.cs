using Yulinti.Nucleus.Instrumentarium;
using UnityEngine;
using UnityEngine.AI;
using Animancer;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumMaius.Anchora {
    public sealed class AnchoraPuellae : MonoBehaviour, IAnchora, IAnchoraPuellae {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        [SerializeField] private Animator _animator;
        [SerializeField] private AnimancerComponent _animancer;

        [SerializeField] private SkinnedMeshRenderer _figuraCapitis;
        [SerializeField] private SkinnedMeshRenderer _figruaPelvis;
        [SerializeField] private SkinnedMeshRenderer _figuraCorporis;
        [SerializeField] private SkinnedMeshRenderer _figuraBrachiiDexter;
        [SerializeField] private SkinnedMeshRenderer _figuraBrachiiSinister;
        [SerializeField] private SkinnedMeshRenderer _figuraPedisDexter;
        [SerializeField] private SkinnedMeshRenderer _figuraPedisSinister;

        [SerializeField] private Transform _osRadix;

        // 蜈ｨ繝懊・繝ｳ
        [SerializeField] private Transform _osHips;
        [SerializeField] private Transform _osSpine;
        [SerializeField] private Transform _osSpine1;
        [SerializeField] private Transform _osSpine2;
        [SerializeField] private Transform _osNeck;
        [SerializeField] private Transform _osHead;
        [SerializeField] private Transform _osLeftShoulder;
        [SerializeField] private Transform _osLeftUpperArm;
        [SerializeField] private Transform _osLeftLowerArm;
        [SerializeField] private Transform _osLeftHand;
        [SerializeField] private Transform _osRightShoulder;
        [SerializeField] private Transform _osRightUpperArm;
        [SerializeField] private Transform _osRightLowerArm;
        [SerializeField] private Transform _osRightHand;
        [SerializeField] private Transform _osLeftUpperLeg;
        [SerializeField] private Transform _osLeftLowerLeg;
        [SerializeField] private Transform _osLeftFoot;
        [SerializeField] private Transform _osLeftToe;
        [SerializeField] private Transform _osRightUpperLeg;
        [SerializeField] private Transform _osRightLowerLeg;
        [SerializeField] private Transform _osRightFoot;
        [SerializeField] private Transform _osRightToe;

        // 險育ｮ礼畑繝懊・繝ｳ
        [SerializeField] private Transform _osHipsRightX150Pin;
        [SerializeField] private Transform _osHipsRightY90Pin;
        [SerializeField] private Transform _osHipsLeftX150Pin;
        [SerializeField] private Transform _osHipsLeftY90Pin;

        [SerializeField] private Transform _resVisaeCapitisDexter;
        [SerializeField] private Transform _resVisaeCapitisSinister;
        [SerializeField] private Transform _resVisaePectorisDexter;
        [SerializeField] private Transform _resVisaePectorisSinister;
        [SerializeField] private Transform _resVisaeNatiumDexter;
        [SerializeField] private Transform _resVisaeNatiumSinister;

        [SerializeField] private Transform _resNudusPectoris;
        [SerializeField] private Transform _resNudusCatellus;
        [SerializeField] private Transform _resNudusNatium;

        [SerializeField] private Transform _osCorrectoriumRadicis;
        [SerializeField] private Transform _osCorrectoriumCapitis;
        [SerializeField] private Transform _osCorrectoriumCervicis;
        [SerializeField] private Transform _osCorrectoriumSpinae2;
        [SerializeField] private Transform _osCorrectoriumSpinae1;
        [SerializeField] private Transform _osCorrectoriumSpinae0;
        [SerializeField] private Transform _osCorrectoriumPelvis;
        [SerializeField] private Transform _osCorrectoriumUmeriDexter;
        [SerializeField] private Transform _osCorrectoriumBracchiiDexter;
        [SerializeField] private Transform _osCorrectoriumAntebracchiiDexter;
        [SerializeField] private Transform _osCorrectoriumManusDexter;
        [SerializeField] private Transform _osCorrectoriumUmeriSinister;
        [SerializeField] private Transform _osCorrectoriumBracchiiSinister;
        [SerializeField] private Transform _osCorrectoriumAntebracchiiSinister;
        [SerializeField] private Transform _osCorrectoriumManusSinister;
        [SerializeField] private Transform _osCorrectoriumFemurisDexter;
        [SerializeField] private Transform _osCorrectoriumCrurisDexter;
        [SerializeField] private Transform _osCorrectoriumPedisDexter;
        [SerializeField] private Transform _osCorrectoriumDigitiPedisDexter;
        [SerializeField] private Transform _osCorrectoriumFemurisSinister;
        [SerializeField] private Transform _osCorrectoriumCrurisSinister;
        [SerializeField] private Transform _osCorrectoriumPedisSinister;
        [SerializeField] private Transform _osCorrectoriumDigitiPedisSinister;
        [SerializeField] private Transform _osCorrectoriumPectorissDexter;
        [SerializeField] private Transform _osCorrectoriumPectorissSinister;
        [SerializeField] private Transform _osCorrectoriumNatisDexter;
        [SerializeField] private Transform _osCorrectoriumNatisSinister;
        [SerializeField] private Transform _osCorrectoriumVenter;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public Animator Animator => _animator;
        public AnimancerComponent Animancer => _animancer;

        public SkinnedMeshRenderer FiguraCapitis => _figuraCapitis;
        public SkinnedMeshRenderer FiguraPelvis => _figruaPelvis;
        public SkinnedMeshRenderer FiguraCorporis => _figuraCorporis;
        public SkinnedMeshRenderer FiguraBrachiiDexter => _figuraBrachiiDexter;
        public SkinnedMeshRenderer FiguraBrachiiSinister => _figuraBrachiiSinister;
        public SkinnedMeshRenderer FiguraPedisDexter => _figuraPedisDexter;
        public SkinnedMeshRenderer FiguraPedisSinister => _figuraPedisSinister;

        public Transform OsRadix => _osRadix;

        public Transform OsHips => _osHips;
        public Transform OsSpine => _osSpine;
        public Transform OsSpine1 => _osSpine1;
        public Transform OsSpine2 => _osSpine2;
        public Transform OsNeck => _osNeck;
        public Transform OsHead => _osHead;
        public Transform OsLeftShoulder => _osLeftShoulder;
        public Transform OsLeftUpperArm => _osLeftUpperArm;
        public Transform OsLeftLowerArm => _osLeftLowerArm;
        public Transform OsLeftHand => _osLeftHand;
        public Transform OsRightShoulder => _osRightShoulder;
        public Transform OsRightUpperArm => _osRightUpperArm;
        public Transform OsRightLowerArm => _osRightLowerArm;
        public Transform OsRightHand => _osRightHand;
        public Transform OsLeftUpperLeg => _osLeftUpperLeg;
        public Transform OsLeftLowerLeg => _osLeftLowerLeg;
        public Transform OsLeftFoot => _osLeftFoot;
        public Transform OsLeftToe => _osLeftToe;
        public Transform OsRightUpperLeg => _osRightUpperLeg;
        public Transform OsRightLowerLeg => _osRightLowerLeg;
        public Transform OsRightFoot => _osRightFoot;
        public Transform OsRightToe => _osRightToe;

        public Transform OsHipsRightX150Pin => _osHipsRightX150Pin;
        public Transform OsHipsRightY90Pin => _osHipsRightY90Pin;
        public Transform OsHipsLeftX150Pin => _osHipsLeftX150Pin;
        public Transform OsHipsLeftY90Pin => _osHipsLeftY90Pin;

        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        // 頭の視認ポイント
        public Transform ResVisaeCapitisDexter => _resVisaeCapitisDexter;
        public Transform ResVisaeCapitisSinister => _resVisaeCapitisSinister;
        // 胸の視認ポイント
        public Transform ResVisaePectorisDexter => _resVisaePectorisDexter;
        public Transform ResVisaePectorisSinister => _resVisaePectorisSinister;
        // ケツの視認ポイント
        public Transform ResVisaeNatiumDexter => _resVisaeNatiumDexter;
        public Transform ResVisaeNatiumSinister => _resVisaeNatiumSinister;

        // 露出判定用ポイント
        public Transform ResNudusPectoris => _resNudusPectoris;
        public Transform ResNudusCatellus => _resNudusCatellus;
        public Transform ResNudusNatium => _resNudusNatium;

        public Transform OsCorrectoriumRadicis => _osCorrectoriumRadicis;
        public Transform OsCorrectoriumCapitis => _osCorrectoriumCapitis;
        public Transform OsCorrectoriumCervicis => _osCorrectoriumCervicis;
        public Transform OsCorrectoriumSpinae2 => _osCorrectoriumSpinae2;
        public Transform OsCorrectoriumSpinae1 => _osCorrectoriumSpinae1;
        public Transform OsCorrectoriumSpinae0 => _osCorrectoriumSpinae0;
        public Transform OsCorrectoriumPelvis => _osCorrectoriumPelvis;
        public Transform OsCorrectoriumUmeriDexter => _osCorrectoriumUmeriDexter;
        public Transform OsCorrectoriumBracchiiDexter => _osCorrectoriumBracchiiDexter;
        public Transform OsCorrectoriumAntebracchiiDexter => _osCorrectoriumAntebracchiiDexter;
        public Transform OsCorrectoriumManusDexter => _osCorrectoriumManusDexter;
        public Transform OsCorrectoriumUmeriSinister => _osCorrectoriumUmeriSinister;
        public Transform OsCorrectoriumBracchiiSinister => _osCorrectoriumBracchiiSinister;
        public Transform OsCorrectoriumAntebracchiiSinister => _osCorrectoriumAntebracchiiSinister;
        public Transform OsCorrectoriumManusSinister => _osCorrectoriumManusSinister;
        public Transform OsCorrectoriumFemurisDexter => _osCorrectoriumFemurisDexter;
        public Transform OsCorrectoriumCrurisDexter => _osCorrectoriumCrurisDexter;
        public Transform OsCorrectoriumPedisDexter => _osCorrectoriumPedisDexter;
        public Transform OsCorrectoriumDigitiPedisDexter => _osCorrectoriumDigitiPedisDexter;
        public Transform OsCorrectoriumFemurisSinister => _osCorrectoriumFemurisSinister;
        public Transform OsCorrectoriumCrurisSinister => _osCorrectoriumCrurisSinister;
        public Transform OsCorrectoriumPedisSinister => _osCorrectoriumPedisSinister;
        public Transform OsCorrectoriumDigitiPedisSinister => _osCorrectoriumDigitiPedisSinister;
        public Transform OsCorrectoriumPectorissDexter => _osCorrectoriumPectorissDexter;
        public Transform OsCorrectoriumPectorissSinister => _osCorrectoriumPectorissSinister;
        public Transform OsCorrectoriumNatisDexter => _osCorrectoriumNatisDexter;
        public Transform OsCorrectoriumNatisSinister => _osCorrectoriumNatisSinister;
        public Transform OsCorrectoriumVenter => _osCorrectoriumVenter;

        public bool Validare() {
            bool result = true;
            if (_navMeshAgent == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_NAVMESHAGENT_NULL);
                result = false;
            }
            if (_animator == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_ANIMATOR_NULL);
                result = false;
            }
            if (_animancer == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_MINISTERIUMPUELLAEANIMATIONES_ANIMANCER_NULL);
                result = false;
            }
            if (_figuraCapitis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_SKINNEDMESHRENDERER_HEAD_NULL);
                result = false;
            }
            if (_figruaPelvis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_SKINNEDMESHRENDERER_PELVIS_NULL);
                result = false;
            }
            if (_figuraCorporis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_SKINNEDMESHRENDERER_TORSO_NULL);
                result = false;
            }
            if (_figuraBrachiiDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_SKINNEDMESHRENDERER_RIGHTARM_NULL);
                result = false;
            }
            if (_figuraBrachiiSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_SKINNEDMESHRENDERER_LEFTARM_NULL);
                result = false;
            }
            if (_figuraPedisDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_SKINNEDMESHRENDERER_RIGHTLEG_NULL);
                result = false;
            }
            if (_figuraPedisSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_SKINNEDMESHRENDERER_LEFTLEG_NULL);
                result = false;
            }
            if (_osRadix == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_ROOT_NULL);
                result = false;
            }
            if (_osHips == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_HIPS_NULL);
                result = false;
            }
            if (_osSpine == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_SPINE_NULL);
                result = false;
            }
            if (_osSpine1 == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_SPINE1_NULL);
                result = false;
            }
            if (_osSpine2 == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_SPINE2_NULL);
                result = false;
            }
            if (_osNeck == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_NECK_NULL);
                result = false;
            }
            if (_osHead == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_HEAD_NULL);
                result = false;
            }
            if (_osLeftShoulder == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_LEFTSHOULDER_NULL);
                result = false;
            }
            if (_osLeftUpperArm == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_LEFTUPPERARM_NULL);
                result = false;
            }
            if (_osLeftLowerArm == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_LEFTLOWERARM_NULL);
                result = false;
            }
            if (_osLeftHand == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_LEFTHAND_NULL);
                result = false;
            }
            if (_osRightShoulder == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_RIGHTSHOULDER_NULL);
                result = false;
            }
            if (_osRightUpperArm == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_RIGHTUPPERARM_NULL);
                result = false;
            }
            if (_osRightLowerArm == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_RIGHTLOWERARM_NULL);
                result = false;
            }
            if (_osRightHand == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_RIGHTHAND_NULL);
                result = false;
            }
            if (_osLeftUpperLeg == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_LEFTUPPERLEG_NULL);
                result = false;
            }
            if (_osLeftLowerLeg == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_LEFTLOWERLEG_NULL);
                result = false;
            }
            if (_osLeftFoot == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_LEFTFOOT_NULL);
                result = false;
            }
            if (_osLeftToe == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_LEFTTOE_NULL);
                result = false;
            }
            if (_osRightUpperLeg == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_RIGHTUPPERLEG_NULL);
                result = false;
            }
            if (_osRightLowerLeg == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_RIGHTLOWERLEG_NULL);
                result = false;
            }
            if (_osRightFoot == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_RIGHTFOOT_NULL);
                result = false;
            }
            if (_osRightToe == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_RIGHTTOE_NULL);
                result = false;
            }
            if (_osHipsRightX150Pin == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_HIPS_RIGHT_X150PIN_NULL);
                result = false;
            }
            if (_osHipsRightY90Pin == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_HIPS_RIGHT_Y90PIN_NULL);
                result = false;
            }
            if (_osHipsLeftX150Pin == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_HIPS_LEFT_X150PIN_NULL);
                result = false;
            }
            if (_osHipsLeftY90Pin == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_HIPS_LEFT_Y90PIN_NULL);
                result = false;
            }

            if (_resVisaeCapitisDexter == null || _resVisaeCapitisSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_VISAE_CAPITIS_NULL);
                result = false;
            }
            if (_resVisaePectorisDexter == null || _resVisaePectorisSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_VISAE_PECTORIS_NULL);
                result = false;
            }
            if (_resVisaeNatiumDexter == null || _resVisaeNatiumSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_VISAE_NATIUM_NULL);
                result = false;
            }
            if (_resNudusPectoris == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_NUDUS_PECTORIS_NULL);
                result = false;
            }
            if (_resNudusCatellus == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_NUDUS_CATELLUS_NULL);
                result = false;
            }
            if (_resNudusNatium == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_NUDUS_NATIUM_NULL);
                result = false;
            }
            if (_osCorrectoriumRadicis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_RADICIS_NULL);
                result = false;
            }
            if (_osCorrectoriumCapitis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_CAPITIS_NULL);
                result = false;
            }
            if (_osCorrectoriumCervicis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_CERVICIS_NULL);
                result = false;
            }
            if (_osCorrectoriumSpinae2 == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_SPINAE2_NULL);
                result = false;
            }
            if (_osCorrectoriumSpinae1 == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_SPINAE1_NULL);
                result = false;
            }
            if (_osCorrectoriumSpinae0 == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_SPINAE0_NULL);
                result = false;
            }
            if (_osCorrectoriumPelvis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_PELVIS_NULL);
                result = false;
            }
            if (_osCorrectoriumUmeriDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_UMERI_DEXTER_NULL);
                result = false;
            }
            if (_osCorrectoriumBracchiiDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_BRACCHII_DEXTER_NULL);
                result = false;
            }
            if (_osCorrectoriumAntebracchiiDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_ANTEBRACCHII_DEXTER_NULL);
                result = false;
            }
            if (_osCorrectoriumManusDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_MANUS_DEXTER_NULL);
                result = false;
            }
            if (_osCorrectoriumUmeriSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_UMERI_SINISTER_NULL);
                result = false;
            }
            if (_osCorrectoriumBracchiiSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_BRACCHII_SINISTER_NULL);
                result = false;
            }
            if (_osCorrectoriumAntebracchiiSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_ANTEBRACCHII_SINISTER_NULL);
                result = false;
            }
            if (_osCorrectoriumManusSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_MANUS_SINISTER_NULL);
                result = false;
            }
            if (_osCorrectoriumFemurisDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_FEMURIS_DEXTER_NULL);
                result = false;
            }
            if (_osCorrectoriumCrurisDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_CRURIS_DEXTER_NULL);
                result = false;
            }
            if (_osCorrectoriumPedisDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_PEDIS_DEXTER_NULL);
                result = false;
            }
            if (_osCorrectoriumDigitiPedisDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_DIGITI_PEDIS_DEXTER_NULL);
                result = false;
            }
            if (_osCorrectoriumFemurisSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_FEMURIS_SINISTER_NULL);
                result = false;
            }
            if (_osCorrectoriumCrurisSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_CRURIS_SINISTER_NULL);
                result = false;
            }
            if (_osCorrectoriumPedisSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_PEDIS_SINISTER_NULL);
                result = false;
            }
            if (_osCorrectoriumDigitiPedisSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_DIGITI_PEDIS_SINISTER_NULL);
                result = false;
            }
            if (_osCorrectoriumPectorissDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_PECTORISS_DEXTER_NULL);
                result = false;
            }
            if (_osCorrectoriumPectorissSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_PECTORISS_SINISTER_NULL);
                result = false;
            }
            if (_osCorrectoriumNatisDexter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_NATIS_DEXTER_NULL);
                result = false;
            }
            if (_osCorrectoriumNatisSinister == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_NATIS_SINISTER_NULL);
                result = false;
            }
            if (_osCorrectoriumVenter == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPuellae_ANCHORAPUELLAE_BONE_CORRECTORIUM_VENTER_NULL);
                result = false;
            }
            return result;
        }
    }
}
