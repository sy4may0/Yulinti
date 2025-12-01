using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeAnimationumPartis {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaPuellaeAnimationumPartis(IConfiguratioPuellaeAnimationisPartis[] config) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeAnimationisPartis)).Length;
            _animationes = new IStructuraAnimationis[longitudo];

            _animationes[(int)IDPuellaeAnimationisPartis.None] = null;

            foreach (IConfiguratioPuellaeAnimationisPartis c in config) {
                _animationes[(int)c.ID] = FabricaStructuraeAnimationis.Create(
                    c.Animatio.Evolvo(IDErrorum.TABULAPUELLAEANIMATIONUMPARTIS_ANIMATION_NULL),
                    c.TempusEvanescentiae,
                    c.Lenitio,
                    c.EstSimultaneum,
                    c.EstImpeditivus
                );
            }

            for (int i = 1; i < longitudo; i++) {
                if (_animationes[i] == null) {
                    Errorum.Fatal(IDErrorum.TABULAPUELLAEANIMATIONUMPARTIS_CONFIG_NOT_FOUND);
                }
            }
        }

        public IStructuraAnimationis Lego(IDPuellaeAnimationisPartis idPartis) => _animationes[(int)idPartis];
    }
}


