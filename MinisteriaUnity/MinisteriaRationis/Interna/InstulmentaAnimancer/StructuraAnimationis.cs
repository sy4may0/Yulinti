using Animancer;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal class StructuraAnimationis : IStructuraAnimationis {
        private readonly ITransition _animatio;
        private readonly float _tempusEvanescentiae;
        private readonly Easing.Function _lenitio;
        private readonly bool _estSimultaneum;
        private readonly bool _estImpeditivus;
        private readonly bool _estCircularis;

        public StructuraAnimationis(
            ITransition animatio, 
            float tempusEvanescentiae, Easing.Function lenitio, 
            bool estSimultaneum = false, bool estImpeditivus = false,
            bool estCircularis = false
        ) {
            _animatio = animatio;
            _tempusEvanescentiae = tempusEvanescentiae;
            _lenitio = lenitio;
            _estSimultaneum = estSimultaneum;
            _estImpeditivus = estImpeditivus;
            _estCircularis = estCircularis;
        }

        public ITransition Animatio => _animatio;
        public float TempusEvanescentiae => _tempusEvanescentiae;
        public Easing.Function Lenitio => _lenitio;
        public bool EstSimultaneum => _estSimultaneum;
        public bool EstImpeditivus => _estImpeditivus;
        public bool EstCircularis => _estCircularis;
    }

    internal class StructuraAnimationisVelInjectibile : IStructuraAnimationis, IVelocitasInjectibile {
        private readonly LinearMixerTransition _animatio;
        private readonly float _tempusEvanescentiae;
        private readonly Easing.Function _lenitio;
        private readonly bool _estSimultaneum;
        private readonly bool _estImpeditivus;
        private readonly bool _estCircularis;

        public StructuraAnimationisVelInjectibile(
            LinearMixerTransition animatio,
            float tempusEvanescentiae, Easing.Function lenitio,
            bool estSimultaneum = false, bool estImpeditivus = false,
            bool estCircularis = false
        ) {
            _animatio = animatio;
            _tempusEvanescentiae = tempusEvanescentiae;
            _lenitio = lenitio;
            _estSimultaneum = estSimultaneum;
            _estImpeditivus = estImpeditivus;
            _estCircularis = estCircularis;
        }

        public ITransition Animatio => _animatio;
        public float TempusEvanescentiae => _tempusEvanescentiae;
        public Easing.Function Lenitio => _lenitio;
        public bool EstSimultaneum => _estSimultaneum;
        public bool EstImpeditivus => _estImpeditivus;
        public bool EstCircularis => _estCircularis;
        public void InjicereVelocitatem(float vel) {
            _animatio.State.Parameter = vel;
        }
    }
}
