using Yulinti.Nucleus;
using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using System;

// 注意 MinisteriumCivisはUpdate()内で生成される。エラーで落としたり重い処理をコンストラクタに入れるな。
namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivis : IDisposable {
        private readonly GameObject _civis;
        private readonly Transform _tCivis;
        private readonly Transform _osCaputis;
        private readonly IFabricaCivis _fabrica;

        private MinisteriumCivis(
            GameObject civis,
            Transform tCivis,
            Transform osCaputis,
            IFabricaCivis fabrica
        ) {
            _civis = civis;
            _tCivis = tCivis;
            _osCaputis = osCaputis;
            _fabrica = fabrica;
        }

        public static ErrorAut<MinisteriumCivis> CreareInstantia(IFabricaCivis fabrica) {
            ErrorAut<GameObject> t = fabrica.ManifestatioCivis();
            if (t.Error()) {
                return ErrorAut<MinisteriumCivis>.Error(t.ID());
            }

            GameObject civis = t.Evolvare();

            if (civis.transform == null) {
                return ErrorAut<MinisteriumCivis>.Error(IDErrorum.MINISTERIUMCIVIS_CIVIS_TRANSFORM_NULL);
            }
            Transform tCivis = civis.transform;

            Animator animator = civis.GetComponent<Animator>();
            if (animator == null) {
                return ErrorAut<MinisteriumCivis>.Error(IDErrorum.MINISTERIUMCIVIS_ANIMATOR_NULL);
            }

            Transform osCaputis = animator.GetBoneTransform(HumanBodyBones.Head);

            if (osCaputis == null) {
                return ErrorAut<MinisteriumCivis>.Error(IDErrorum.MINISTERIUMCIVIS_HEAD_BONE_NULL);
            }

            return ErrorAut<MinisteriumCivis>.Successus(new MinisteriumCivis(civis, tCivis, osCaputis, fabrica));
        }

        public Vector3 LegoPositionem() => _tCivis.position;
        public Quaternion LegoRotationem() => _tCivis.rotation;
        public Vector3 LegoScalam() => _tCivis.localScale;

        public void PonoPositionem(Vector3 pos) => _tCivis.position = pos;
        public void PonoRotationem(Quaternion rot) => _tCivis.rotation = rot;
        public void PonoScalam(Vector3 scala) => _tCivis.localScale = scala;

        public Vector3 DirectioAspectus() => _osCaputis.forward;

        public void Dispose() {
            _fabrica.DeletioCivis(_civis);
        }
    }
}