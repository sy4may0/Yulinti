using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioCivisStatusCorporis {
        IDCivisStatusCorporis Id { get; }
        IDCivisAnimationisContinuata IdAnimationisIntrare { get; }
        IDCivisAnimationisContinuata IdAnimationisExire { get; }
        bool LudereExire { get; }

        // ライフタイム消費量
        float ConsumptioVitae { get; }

        // 視力
        float Visus { get; }
        // 視認範囲 -> 使ってない。使うなら倍率に変える。
        float VisusDistantia { get; }

        // 聴力
        float Auditus { get; }
        // 聴認範囲 -> 使ってない。使うなら倍率に変える。
        float AuditusDistantia { get; }
    }
}