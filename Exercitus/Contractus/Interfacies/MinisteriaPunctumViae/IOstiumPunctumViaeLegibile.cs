using System.Numerics;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IPunctumViaeLegibile {
        int ID { get; }
        IDPunctumViaeTypi Typus { get; }
        Vector3 Positio { get; }
        bool EstActivum { get; }
    }

    public interface IOstiumPunctumViaeLegibile {
        // ランダムにエントリーポイントを取得。
        bool ConareLegoTemere(out IPunctumViaeLegibile punctumViae);
        // 最短エントリーポイントを取得。
        bool ConareLegoVicinam(Vector3 positio, out IPunctumViaeLegibile punctumViae);

        // ランダムにDespawn地点を取得。
        bool ConareLegoCrematoriumTemere(out IPunctumViaeLegibile punctumViae);
        // 最短Despawn地点を取得。
        bool ConareLegoCrematoriumVicinam(Vector3 positio, out IPunctumViaeLegibile punctumViae);

        // ランダムNatorium地点を取得。
        bool ConareLegoNatoriumTemere(out IPunctumViaeLegibile punctumViae);
        // 最短Natorium地点を取得。
        bool ConareLegoNatoriumVicinam(Vector3 positio, out IPunctumViaeLegibile punctumViae);

        // ランダムに指定IDの地点を取得。
        bool ConareLegoTypumTemere(IDPunctumViaeTypi typus, out IPunctumViaeLegibile punctumViae);
        // 最短指定IDの地点を取得。
        bool ConareLegoTypumVicinam(IDPunctumViaeTypi typus, Vector3 positio, out IPunctumViaeLegibile punctumViae);
    }
}

