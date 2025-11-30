using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class ResolvorCrematorium : IResolvorPunctumViae {
        // 終点。次のWayPointは存在しなぁE��E
        public ErrorAut<PunctumViae> Resolvo(PunctumViae pAntecedens, PunctumViae[] pConsequens) {
            // 引数は未使用、E
            _ = pAntecedens;
            _ = pConsequens;    

            // 終点なのでnullを返す
            return ErrorAut<PunctumViae>.Successus(null);
        }
    }
}


