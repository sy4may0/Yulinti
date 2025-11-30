using UnityEngine;
using Animancer;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.Anchora {
    public sealed class AnchoraPuellae : MonoBehaviour, IAnchora, IAnchoraPuellae {
        [SerializeField] private CharacterController _characterController;

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


        public CharacterController CharacterController => _characterController;
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

        public bool Validare() {
            bool result = true;
            if (_characterController == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_CHARACTERCONTROLLER_NULL);
                result = false;
            }
            if (_animator == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_ANIMATOR_NULL);
                result = false;
            }
            if (_animancer == null) {
                Errorum.Fatal(IDErrorum.MINISTERIUMPUELLAEANIMATIONES_ANIMANCER_NULL);
                result = false;
            }
            if (_figuraCapitis == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_SKINNEDMESHRENDERER_HEAD_NULL);
                result = false;
            }
            if (_figruaPelvis == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_SKINNEDMESHRENDERER_PELVIS_NULL);
                result = false;
            }
            if (_figuraCorporis == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_SKINNEDMESHRENDERER_TORSO_NULL);
                result = false;
            }
            if (_figuraBrachiiDexter == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_SKINNEDMESHRENDERER_RIGHTARM_NULL);
                result = false;
            }
            if (_figuraBrachiiSinister == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_SKINNEDMESHRENDERER_LEFTARM_NULL);
                result = false;
            }
            if (_figuraPedisDexter == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_SKINNEDMESHRENDERER_RIGHTLEG_NULL);
                result = false;
            }
            if (_figuraPedisSinister == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_SKINNEDMESHRENDERER_LEFTLEG_NULL);
                result = false;
            }
            if (_osRadix == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_ROOT_NULL);
                result = false;
            }
            if (_osHips == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_HIPS_NULL);
                result = false;
            }
            if (_osSpine == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_SPINE_NULL);
                result = false;
            }
            if (_osSpine1 == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_SPINE1_NULL);
                result = false;
            }
            if (_osSpine2 == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_SPINE2_NULL);
                result = false;
            }
            if (_osNeck == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_NECK_NULL);
                result = false;
            }
            if (_osHead == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_HEAD_NULL);
                result = false;
            }
            if (_osLeftShoulder == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_LEFTSHOULDER_NULL);
                result = false;
            }
            if (_osLeftUpperArm == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_LEFTUPPERARM_NULL);
                result = false;
            }
            if (_osLeftLowerArm == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_LEFTLOWERARM_NULL);
                result = false;
            }
            if (_osLeftHand == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_LEFTHAND_NULL);
                result = false;
            }
            if (_osRightShoulder == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_RIGHTSHOULDER_NULL);
                result = false;
            }
            if (_osRightUpperArm == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_RIGHTUPPERARM_NULL);
                result = false;
            }
            if (_osRightLowerArm == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_RIGHTLOWERARM_NULL);
                result = false;
            }
            if (_osRightHand == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_RIGHTHAND_NULL);
                result = false;
            }
            if (_osLeftUpperLeg == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_LEFTUPPERLEG_NULL);
                result = false;
            }
            if (_osLeftLowerLeg == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_LEFTLOWERLEG_NULL);
                result = false;
            }
            if (_osLeftFoot == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_LEFTFOOT_NULL);
                result = false;
            }
            if (_osLeftToe == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_LEFTTOE_NULL);
                result = false;
            }
            if (_osRightUpperLeg == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_RIGHTUPPERLEG_NULL);
                result = false;
            }
            if (_osRightLowerLeg == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_RIGHTLOWERLEG_NULL);
                result = false;
            }
            if (_osRightFoot == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_RIGHTFOOT_NULL);
                result = false;
            }
            if (_osRightToe == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_RIGHTTOE_NULL);
                result = false;
            }
            if (_osHipsRightX150Pin == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_HIPS_RIGHT_X150PIN_NULL);
                result = false;
            }
            if (_osHipsRightY90Pin == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_HIPS_RIGHT_Y90PIN_NULL);
                result = false;
            }
            if (_osHipsLeftX150Pin == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_HIPS_LEFT_X150PIN_NULL);
                result = false;
            }
            if (_osHipsLeftY90Pin == null) {
                Errorum.Fatal(IDErrorum.ANCHORAPUELLAE_BONE_HIPS_LEFT_Y90PIN_NULL);
                result = false;
            }
            return result;
        }
    }
}
