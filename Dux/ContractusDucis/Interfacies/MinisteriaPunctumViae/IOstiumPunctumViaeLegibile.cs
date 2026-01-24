using System.Numerics;
using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IPunctumViaeLegibile {
        int ID { get; }
        IDPunctumViaeTypi Typus { get; }
        Vector3 Positio { get; }
        bool EstActivum { get; }
    }

    public interface IOstiumPunctumViaeLegibile {
        // ランダムにエントリーポイントを取得。
        ErrorAut<IPunctumViaeLegibile> LegoTemere();
        // 最短エントリーポイントを取得。
        ErrorAut<IPunctumViaeLegibile> LegoVicinam(Vector3 positio);

        // ランダムにDespawn地点を取得。
        ErrorAut<IPunctumViaeLegibile> LegoCrematoriumTemere();
        // 最短Despawn地点を取得。
        ErrorAut<IPunctumViaeLegibile> LegoCrematoriumVicinam(Vector3 positio);

        // ランダムNatorium地点を取得。
        ErrorAut<IPunctumViaeLegibile> LegoNatoriumTemere();
        // 最短Natorium地点を取得。
        ErrorAut<IPunctumViaeLegibile> LegoNatoriumVicinam(Vector3 positio);

        // ランダムに指定IDの地点を取得。
        ErrorAut<IPunctumViaeLegibile> LegoTypumTemere(IDPunctumViaeTypi typus);
        // 最短指定IDの地点を取得。
        ErrorAut<IPunctumViaeLegibile> LegoTypumVicinam(IDPunctumViaeTypi typus, Vector3 positio);
    }
}

