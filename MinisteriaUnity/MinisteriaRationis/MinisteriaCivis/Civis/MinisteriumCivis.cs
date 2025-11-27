using Yulinti.Nucleus;
using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivis : IDisposable {
        private readonly IFabricaCivis _fabrica;
        private readonly ICivisAtomi _civisAtomi;

        // Non Null Members
        private readonly GameObject _radixCivis;
        private readonly Transform _osCaputis;

        public MinisteriumCivis(IFabricaCivis fabrica) {
            _fabrica = fabrica;
            // てっぺんのEmptyObject。
            _civisAtomi = _fabrica.ManifestatioCivis().Evolvo();

            // Non Null Members 
            _radixCivis = _civisAtomi.RadixCivis;
            _osCaputis = _civisAtomi.Animator.Evolvo(
                IDErrorum.MINISTERIUMCIVIS_ANIMATOR_NULL 
            ).GetBoneTransform(HumanBodyBones.Head);

            if (_osCaputis == null) {
                Errorum.Fatal(IDErrorum.MINISTERIUMCIVIS_HEAD_BONE_NULL);
            }

            _civisAtomi.Deactivare();
        }

        public void Activare() {
            _civisAtomi.Activare();
        }

        public void Deactivare() {
            _civisAtomi.Deactivare();
        }

        public Vector3 LegoPositionem() => _radixCivis.transform.position;
        public Quaternion LegoRotationem() => _radixCivis.transform.rotation;
        public Vector3 LegoScalam() => _radixCivis.transform.localScale;

        public bool EstActivum() => _civisAtomi.EstActivum();

        public void PonoPositionem(Vector3 pos) => _radixCivis.transform.position = pos;
        public void PonoRotationem(Quaternion rot) => _radixCivis.transform.rotation = rot;
        public void PonoScalam(Vector3 scala) => _radixCivis.transform.localScale = scala;

        public Vector3 DirectioAspectus() => _osCaputis.forward;

        public void Dispose() {
            _fabrica.DeletioCivis(_civisAtomi);
        }
    }
}
