using Animancer;

namespace Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer {
    public class StructuraAnimationis : IStructuraAnimationis {
        private readonly ITransition _animatio;
        private readonly float _tempusEvanescentiae;
        private readonly Easing.Function _lenitio;
        private readonly bool _estSimultaneum;
        private readonly bool _estImpeditivus;

        public StructuraAnimationis(
            ITransition animatio, 
            float tempusEvanescentiae, Easing.Function lenitio, 
            bool estSimultaneum = false, bool estImpeditivus = false)
        {
            _animatio = animatio;
            _tempusEvanescentiae = tempusEvanescentiae;
            _lenitio = lenitio;
            _estSimultaneum = estSimultaneum;
            _estImpeditivus = estImpeditivus;
        }

        public ITransition Animatio => _animatio;
        public float TempusEvanescentiae => _tempusEvanescentiae;
        public Easing.Function Lenitio => _lenitio;
        public bool EstSimultaneum => _estSimultaneum;
        public bool EstImpeditivus => _estImpeditivus;
    }

    public class StructuraAnimationisVelInjectibile : IStructuraAnimationisVelInjectibile {
        private readonly LinearMixerTransition _animatio;
        private readonly float _tempusEvanescentiae;
        private readonly Easing.Function _lenitio;
        private readonly bool _estSimultaneum;
        private readonly bool _estImpeditivus;

        public StructuraAnimationisVelInjectibile(
            LinearMixerTransition animatio,
            float tempusEvanescentiae, Easing.Function lenitio,
            bool estSimultaneum = false, bool estImpeditivus = false)
        {
            _animatio = animatio;
            _tempusEvanescentiae = tempusEvanescentiae;
            _lenitio = lenitio;
            _estSimultaneum = estSimultaneum;
            _estImpeditivus = estImpeditivus;
        }

        public ITransition Animatio => _animatio;
        public float TempusEvanescentiae => _tempusEvanescentiae;
        public Easing.Function Lenitio => _lenitio;
        public bool EstSimultaneum => _estSimultaneum;
        public bool EstImpeditivus => _estImpeditivus;
        public void InjicereVelocitatem(float vel) {
            _animatio.State.Parameter = vel;
        }
    }
}
