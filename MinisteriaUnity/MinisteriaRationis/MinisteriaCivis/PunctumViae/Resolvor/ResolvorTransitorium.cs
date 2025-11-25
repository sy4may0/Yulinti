namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class ResolvorTransitorium : IResolvorPunctumViae {
        // 中継地点はIpunctumViaeからランダムに選ぶ。
        public ErrorAut<IPunctumViae> Resolvo(IPunctumViae pAntecedens, IPunctumViae[] pConsequens) {
            int length = pConsequens.Length;
            if (length == 0) {
                return ErrorAut<IPunctumViae>.Error(IDErrorum.PUNCTUMVIAE_LENGTH_OF_P_CONSEQUENS_IS_ZERO);
            }

            if (length == 1) {
                if (!pConsequens[0].EstActivum) {
                    return ErrorAut<IPunctumViae>.Error(IDErrorum.PUNCTUMVIAE_ACTIVE_WAYPOINT_NOT_FOUND);
                }
                return ErrorAut<IPunctumViae>.Successus(pConsequens[0]);
            }

            Span<int> indexus = stackalloc int[length];
            int count = 0;

            for (int i = 0; i < length; i++) {
                IPunctumViae pv = pConsequens[i];

                if (!pv.EstActivum) continue;
                // 前に戻らないようにする。(pAntecendensは、どこから出発してこのWayPointに来たか。)
                if (pAntecedens.Positio == pv.Positio) continue;

                indexus[count++] = i;
            }

            if (count == 0) {
                return ErrorAut<IPunctumViae>.Error(IDErrorum.PUNCTUMVIAE_ACTIVE_WAYPOINT_NOT_FOUND);
            }

            int r = Random.Shared.Next(count);
            return ErrorAut<IPunctumViae>.Successus(pConsequens[indexus[r]]);
        }
    }
}