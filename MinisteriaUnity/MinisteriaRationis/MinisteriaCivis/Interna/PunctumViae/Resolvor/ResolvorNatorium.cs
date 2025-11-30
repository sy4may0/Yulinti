using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;
using UnityEngine;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class ResolvorNatorium : IResolvorPunctumViae {
        // 起点。pAntecedensがnullである前提でランダムに選ぶ、E
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


