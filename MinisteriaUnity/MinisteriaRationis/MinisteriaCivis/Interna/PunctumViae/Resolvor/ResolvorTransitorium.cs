using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;
using UnityEngine;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class ResolvorTransitorium : IResolvorPunctumViae {
        // 荳ｭ邯吝慍轤ｹ縺ｯPunctumViae縺九ｉ繝ｩ繝ｳ繝繝縺ｫ驕ｸ縺ｶ縲・
        public ErrorAut<PunctumViae> Resolvo(PunctumViae pAntecedens, PunctumViae[] pConsequens) {
            int length = pConsequens.Length;
            if (length == 0) {
                return ErrorAut<PunctumViae>.Error(IDErrorum.PUNCTUMVIAE_LENGTH_OF_P_CONSEQUENS_IS_ZERO);
            }

            if (length == 1) {
                if (!pConsequens[0].EstActivum) {
                    return ErrorAut<PunctumViae>.Error(IDErrorum.PUNCTUMVIAE_ACTIVE_WAYPOINT_NOT_FOUND);
                }
                return ErrorAut<PunctumViae>.Successus(pConsequens[0]);
            }

            Span<int> indexus = stackalloc int[length];
            int count = 0;

            for (int i = 0; i < length; i++) {
                PunctumViae pv = pConsequens[i];

                if (!pv.EstActivum) continue;
                // 蜑阪↓謌ｻ繧峨↑縺・ｈ縺・↓縺吶ｋ縲・pAntecedens縺ｯ縲√←縺薙°繧牙・逋ｺ縺励※縺薙・WayPoint縺ｫ譚･縺溘°縲・
                if (pAntecedens != null && pAntecedens.Positio == pv.Positio) continue;

                indexus[count++] = i;
            }

            if (count == 0) {
                return ErrorAut<PunctumViae>.Error(IDErrorum.PUNCTUMVIAE_ACTIVE_WAYPOINT_NOT_FOUND);
            }

            int r = UnityEngine.Random.Range(0, count);
            return ErrorAut<PunctumViae>.Successus(pConsequens[indexus[r]]);
        }
    }
}


