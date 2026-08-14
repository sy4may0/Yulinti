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
    }
}
