using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.ContractusMinisterii.Puellae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Os.Interna {
    public sealed class TabulaOssium {
        private readonly Transform[] _ossa;

        public TabulaOssium(IFukaBoneConfig boneConfig) {
            int longitudo = (int)IDPuellaeOssis.Count;
            _ossa = new Transform[longitudo];
            Transform rigRoot = boneConfig.RigRoot;

            _ossa[(int)IDPuellaeOssis.Root] = rigRoot.Find(boneConfig.RootPath);
            _ossa[(int)IDPuellaeOssis.Hips] = rigRoot.Find(boneConfig.HipsPath);
            _ossa[(int)IDPuellaeOssis.RightUpperLeg] = rigRoot.Find(boneConfig.RightUpperLegPath);
            _ossa[(int)IDPuellaeOssis.RightLowerLeg] = rigRoot.Find(boneConfig.RightLowerLegPath);
            _ossa[(int)IDPuellaeOssis.RightFoot] = rigRoot.Find(boneConfig.RightFootPath);
            _ossa[(int)IDPuellaeOssis.LeftUpperLeg] = rigRoot.Find(boneConfig.LeftUpperLegPath);
            _ossa[(int)IDPuellaeOssis.LeftLowerLeg] = rigRoot.Find(boneConfig.LeftLowerLegPath);
            _ossa[(int)IDPuellaeOssis.LeftFoot] = rigRoot.Find(boneConfig.LeftFootPath);
            _ossa[(int)IDPuellaeOssis.RightX150pin] = rigRoot.Find(boneConfig.RightX150pinPath);
            _ossa[(int)IDPuellaeOssis.RightY90pin] = rigRoot.Find(boneConfig.RightY90pinPath);
            _ossa[(int)IDPuellaeOssis.LeftX150pin] = rigRoot.Find(boneConfig.LeftX150pinPath);
            _ossa[(int)IDPuellaeOssis.LeftY90pin] = rigRoot.Find(boneConfig.LeftY90pinPath);

            for (int i = 0; i < longitudo; i++) {
                if (_ossa[i] == null) {
                    ModeratorErrorum.Fatal($"IDPuellaeOssis {(IDPuellaeOssis)i} が見つかりません。IFukaBoneConfigのパス設定を確認してください。");
                }
            }
        }

        public Transform Lego(IDPuellaeOssis idOssis) => _ossa[(int)idOssis];
        public void PonoPositionem(
            IDPuellaeOssis idOssis, Vector3 positio
        ) => _ossa[(int)idOssis].position = positio;
        public void PonoRotationem(
            IDPuellaeOssis idOssis, Quaternion rotatio
        ) => _ossa[(int)idOssis].rotation = rotatio;
        public void PonoScalam(
            IDPuellaeOssis idOssis, Vector3 scala
        ) => _ossa[(int)idOssis].localScale = scala;
    }
}