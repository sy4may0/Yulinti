using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioPuellaeStatusCorporis {
        IDPuellaeStatusCorporis Id { get; }
        IDPuellaeAnimationis IdAnimationisIntrare { get; }
        IDPuellaeAnimationis IdAnimationis { get; }
        IDPuellaeAnimationis IdAnimationisExire { get; }
        bool EstInterdicta { get; }
        bool EstInterdictaIntrare { get; }
        bool EstInterdictaExire { get; }

        IDPuellaeStatusCorporis IdStatusProximusAutomaticus { get; }

        float ConsumptioVigorisSec { get; }
        float ConsumptioPatientiaeSec { get; }
        float IncrementumAetherisSec { get; }
        float Intentio { get; }
        float Claritas { get; }
        float SonusQuietes { get; }
        float SonusMotus { get; }
    }
}