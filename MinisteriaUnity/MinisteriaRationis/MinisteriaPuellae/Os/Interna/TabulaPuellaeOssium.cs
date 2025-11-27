using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeOssium {
        private readonly Transform[] _ossa;

        public TabulaPuellaeOssium(IConfiguratioPuellaeOssis config) {
            int longitudo = (int)IDPuellaeOssis.Count;
            _ossa = new Transform[longitudo];
            Transform rigRoot = config.RigRoot.Evolvo(IDErrorum.TABULAPUELLAEOSSIUM_RIG_ROOT_NULL);

            _ossa[(int)IDPuellaeOssis.Root] = rigRoot.Find(config.RootPath);
            _ossa[(int)IDPuellaeOssis.Hips] = rigRoot.Find(config.HipsPath);
            _ossa[(int)IDPuellaeOssis.RightUpperLeg] = rigRoot.Find(config.RightUpperLegPath);
            _ossa[(int)IDPuellaeOssis.RightLowerLeg] = rigRoot.Find(config.RightLowerLegPath);
            _ossa[(int)IDPuellaeOssis.RightFoot] = rigRoot.Find(config.RightFootPath);
            _ossa[(int)IDPuellaeOssis.RightToe] = rigRoot.Find(config.RightToePath);
            _ossa[(int)IDPuellaeOssis.LeftUpperLeg] = rigRoot.Find(config.LeftUpperLegPath);
            _ossa[(int)IDPuellaeOssis.LeftLowerLeg] = rigRoot.Find(config.LeftLowerLegPath);
            _ossa[(int)IDPuellaeOssis.LeftFoot] = rigRoot.Find(config.LeftFootPath);
            _ossa[(int)IDPuellaeOssis.LeftToe] = rigRoot.Find(config.LeftToePath);
            _ossa[(int)IDPuellaeOssis.RightX150pin] = rigRoot.Find(config.RightX150pinPath);
            _ossa[(int)IDPuellaeOssis.RightY90pin] = rigRoot.Find(config.RightY90pinPath);
            _ossa[(int)IDPuellaeOssis.LeftX150pin] = rigRoot.Find(config.LeftX150pinPath);
            _ossa[(int)IDPuellaeOssis.LeftY90pin] = rigRoot.Find(config.LeftY90pinPath);

            for (int i = 0; i < longitudo; i++) {
                if (_ossa[i] == null) {
                    Errorum.Fatal(IDErrorum.TABULAPUELLAEOSSIUM_BONE_NOT_FOUND);
                }
            }
        }

        public Transform Lego(IDPuellaeOssis idOssis) => _ossa[(int)idOssis];
    }
}
