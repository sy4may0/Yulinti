using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using System;

namespace Yulinti.Officia.Ministeria {
    internal sealed class TabulaRedittorPuellaeFigurae {
        private readonly SkinnedMeshRenderer[] _figurae;

        public TabulaRedittorPuellaeFigurae(IAnchoraPuellae anchora) {
            int longitudo = Enum.GetNames(typeof(IDRedittorPuellaeFigurae)).Length;
            _figurae = new SkinnedMeshRenderer[longitudo];

            for (int i = 0; i < longitudo; i++) {
                if (_figurae[i] == null) {
                    Carnifex.Intermissio(LogTextus.TabulaRedittorPuellaeFigurae_TABULAREDITTORPUELLAEFIGURAE_SKINNED_MESH_RENDERER_NOT_FOUND);
                }
            }
        }

        public SkinnedMeshRenderer Lego(IDRedittorPuellaeFigurae idFigurae) => _figurae[(int)idFigurae];
    }
}