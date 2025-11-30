using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeOssium {
        private readonly Transform[] _ossa;

        public TabulaPuellaeOssium(IAnchoraPuellae anchoraPuellae) {
            int longitudo = Enum.GetNames(typeof(IDPuellaeOssis)).Length;
            _ossa = new Transform[longitudo];

            _ossa[(int)IDPuellaeOssis.Root] = anchoraPuellae.OsRadix;
            _ossa[(int)IDPuellaeOssis.Hips] = anchoraPuellae.OsHips;
            _ossa[(int)IDPuellaeOssis.RightUpperLeg] = anchoraPuellae.OsRightUpperLeg;
            _ossa[(int)IDPuellaeOssis.RightLowerLeg] = anchoraPuellae.OsRightLowerLeg;
            _ossa[(int)IDPuellaeOssis.RightFoot] = anchoraPuellae.OsRightFoot;
            _ossa[(int)IDPuellaeOssis.RightToe] = anchoraPuellae.OsRightToe;
            _ossa[(int)IDPuellaeOssis.LeftUpperLeg] = anchoraPuellae.OsLeftUpperLeg;
            _ossa[(int)IDPuellaeOssis.LeftLowerLeg] = anchoraPuellae.OsLeftLowerLeg;
            _ossa[(int)IDPuellaeOssis.LeftFoot] = anchoraPuellae.OsLeftFoot;
            _ossa[(int)IDPuellaeOssis.LeftToe] = anchoraPuellae.OsLeftToe;
            _ossa[(int)IDPuellaeOssis.RightX150pin] = anchoraPuellae.OsHipsRightX150Pin;
            _ossa[(int)IDPuellaeOssis.RightY90pin] = anchoraPuellae.OsHipsRightY90Pin;
            _ossa[(int)IDPuellaeOssis.LeftX150pin] = anchoraPuellae.OsHipsLeftX150Pin;
            _ossa[(int)IDPuellaeOssis.LeftY90pin] = anchoraPuellae.OsHipsLeftY90Pin;

            for (int i = 0; i < longitudo; i++) {
                if (_ossa[i] == null) {
                    Errorum.Fatal(IDErrorum.TABULAPUELLAEOSSIUM_BONE_NOT_FOUND);
                }
            }
        }

        public Transform Lego(IDPuellaeOssis idOssis) => _ossa[(int)idOssis];
    }
}



