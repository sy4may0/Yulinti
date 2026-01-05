using System;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class AnimatioCivisContinuata : IAnimatioCivisContinuata {
        private readonly IDCivisAnimationisContinuata _id;
        private readonly IDCivisAnimationisStratum _stratum;
        private readonly VasculumAnimationis[] _animationes;

        public AnimatioCivisContinuata(IConfiguratioCivisAnimationisContinuata config) {
            if (config.Animationes == null || config.Animationes.Length == 0) {
                Errorum.Fatal(IDErrorum.CONFIGURATIOCIVISANIMATIONISCONTINUATA_CHILDREN_NULL_OR_EMPTY);
            }
            _id = config.Id;
            _stratum = config.Stratum;
            _animationes = new VasculumAnimationis[config.Animationes.Length];
            for (int i = 0; i < config.Animationes.Length; i++) {
                _animationes[i] = new VasculumAnimationis(
                    config.Animationes[i].Animatio,
                    config.Animationes[i].TempusEvanescentiae,
                    config.Animationes[i].Lenitio,
                    config.Animationes[i].EstSimultaneum,
                    config.Animationes[i].EstImpeditivus,
                    config.Animationes[i].EstCircularis,
                    config.Animationes[i].EstObsignatus,
                    config.Animationes[i].EstTerminare
                );
            }
        }

        public AnimatioCivisContinuata() {
            _animationes = new VasculumAnimationis[1];
            _animationes[0] = new VasculumAnimationis(
                null,
                0,
                Animancer.Easing.Function.Linear,
                false,
                false,
                false,  
                false,
                false
            );
        }

        public IDCivisAnimationisStratum Stratum => _stratum;
        public IDCivisAnimationisContinuata Id => _id;
        public VasculumAnimationis[] Animationes => _animationes;
        public void PonoAdInitium(Action adInitium) {
            _animationes[0].AdInitium = adInitium;
        }
        public void PonoAdFinem(Action adFinem) {
            _animationes[_animationes.Length - 1].AdFinem = adFinem;
        }
    }
}