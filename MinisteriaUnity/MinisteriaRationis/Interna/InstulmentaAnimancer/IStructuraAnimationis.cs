using Animancer;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface IStructuraAnimationis {
        ITransition Animatio { get; }
        float TempusEvanescentiae { get; }
        Easing.Function Lenitio { get; }
        bool EstSimultaneum { get; }
        bool EstImpeditivus { get; }
        bool EstCircularis { get; }
    }
}


