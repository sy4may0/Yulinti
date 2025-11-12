using Animancer;

namespace Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer {
    public interface IStructuraAnimationis {
        ITransition Animatio { get; }
        float TempusEvanescentiae { get; }
        Easing.Function Lenitio { get; }
        bool EstSimultaneum { get; }
        bool EstImpeditivus { get; }
    }

    public interface IStructuraAnimationisVelInjectibile {
        void InjicereVelocitatem(float vel);
    }
}