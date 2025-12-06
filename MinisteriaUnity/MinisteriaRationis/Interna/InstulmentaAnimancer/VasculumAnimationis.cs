using Animancer;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class VasculumAnimationis {
        private readonly ITransition _animatio;
        private readonly float _tempusEvanescentiae;
        private readonly Easing.Function _lenitio;
        private readonly bool _estSimulataneum;
        private readonly bool _estImpeditivus;
        private readonly bool _estCircularis;
        private readonly bool _estObsignatus;
        public Action AdInitium {get; set;}
        public Action AdFinem {get; set;}

        public VasculumAnimationis(
            ITransition animatio,
            float tempusEvanescentiae = 0.25f,
            Easing.Function lenitio = Easing.Function.Linear,
            bool estSimulataneum = false,
            bool estImpeditivus = false,
            bool estCircularis = false,
            bool estObsignatus = false
        ) {
            _animatio = animatio;
            _tempusEvanescentiae = tempusEvanescentiae;
            _lenitio = lenitio;
            _estSimulataneum = estSimulataneum;
            _estImpeditivus = estImpeditivus;
            _estCircularis = estCircularis;
            _estObsignatus = estObsignatus;
        }

        public ITransition Animatio => _animatio;
        public float TempusEvanescentiae => _tempusEvanescentiae;
        public Easing.Function Lenitio => _lenitio;
        public bool EstSimulataneum => _estSimulataneum;
        public bool EstImpeditivus => _estImpeditivus;
        public bool EstCircularis => _estCircularis;
        public bool EstObsignatus => _estObsignatus;
    }
}