using System.Numerics;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IPunctumViae {
        int ID { get; }
        IDPunctumViaeTypi Typus { get; }
        Vector3 Positio { get; }
    }

    public interface IOstiumPunctumViae {
        // ランダムにエントリーポイントを取得。
        ErrorAut<IPunctumViae> LegoTemere();
        // 最短エントリーポイントを取得。
        ErrorAut<IPunctumViae> LegoVicinam();

        // ランダムにDespawn地点を取得。
        ErrorAut<IPunctumViae> LegoCrematoriumTemere();
        // 最短Despawn地点を取得。
        ErrorAut<IPunctumViae> LegoCrematoriumVicinam();

        // ランダムNatorium地点を取得。
        ErrorAut<IPunctumViae> LegoNatoriumTemere();
        // 最短Natorium地点を取得。
        ErrorAut<IPunctumViae> LegoNatoriumVicinam();

        // ランダムに指定IDの地点を取得。
        ErrorAut<IPunctumViae> LegoTypumTemere(IDPunctumViaeTypi typus);
        // 最短指定IDの地点を取得。
        ErrorAut<IPunctumViae> LegoTypumVicinam(IDPunctumViaeTypi typus);
    }
}

