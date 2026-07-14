using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using System;

namespace Yulinti.Officia.Ministeria {
    internal sealed class TabulaRedittorPuellaeOssisCorrectorium {
        private readonly Transform[] _ossa;

        public TabulaRedittorPuellaeOssisCorrectorium(IAnchoraPuellae anchora) {
            int longitudo = Enum.GetNames(typeof(IDRedittorPuellaeOssisCorrectorium)).Length;
            _ossa = new Transform[longitudo];

            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Radix] = anchora.OsCorrectoriumRadicis;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Caput] = anchora.OsCorrectoriumCapitis;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Cervix] = anchora.OsCorrectoriumCervicis;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Spina2] = anchora.OsCorrectoriumSpinae2;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Spina1] = anchora.OsCorrectoriumSpinae1;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Spina0] = anchora.OsCorrectoriumSpinae0;
            _ossa[(int)IDRedittorPuellaeOssisCorrectorium.Pelvis] = anchora.OsCorrectoriumPelvis;

            for (int i = 0; i < longitudo; i++) {
                if (_ossa[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaRedittorPuellaeOssisCorrectorium_TABULAREDITTORPUELLAEOSSISCORRECTORIUM_BONE_NOT_FOUND);
                }
            }
        }

        public Transform Lego(IDRedittorPuellaeOssisCorrectorium idOssa) => _ossa[(int)idOssa];
    }
}