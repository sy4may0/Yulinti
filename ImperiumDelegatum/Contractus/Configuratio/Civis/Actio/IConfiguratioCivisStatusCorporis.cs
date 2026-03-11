using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioCivisStatusCorporis {
        IDCivisStatusCorporis Id { get; }
        IDCivisAnimationis IdAnimationisIntrare { get; }
        IDCivisAnimationis IdAnimationisTransere { get; }
        IDCivisAnimationis IdAnimationisExire { get; }
        bool EstInterdictaIntrare { get; }
        bool EstInterdictaTransere { get; }
        bool EstInterdictaExire { get; }

        IDCivisStatusCorporis IDStatusProximusAutomaticus { get; }

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
