using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioPuellaeStatusCorporis {
        IDPuellaeStatusCorporis Id { get; }
        IDPuellaeAnimationis IdAnimationisIntrare { get; }
        IDPuellaeAnimationis IdAnimationisTransere { get; }
        IDPuellaeAnimationis IdAnimationisExire { get; }
        bool EstInterdictaIntrare { get; }
        bool EstInterdictaTransere { get; }
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