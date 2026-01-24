using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeStatusCorporis {
        IDPuellaeStatusCorporis Id { get; }
        IDPuellaeAnimationisContinuata IdAnimationisIntrare { get; }
        IDPuellaeAnimationisContinuata IdAnimationisExire { get; }
        bool LudereExire { get; }

        float ConsumptioVigorisSec { get; }
        float ConsumptioPatientiaeSec { get; }
        float IncrementumAetherisSec { get; }
        float Intentio { get; }
        float Claritas { get; }
        float SonusQuietes { get; }
        float SonusMotus { get; }
    }
}