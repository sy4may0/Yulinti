using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeAnimationumFundamenti {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaPuellaeAnimationumFundamenti(IConfiguratioPuellaeAnimationisFundamenti[] config) {
            int longitudo = Enum.GetValues(typeof(IDPuellaeAnimationisFundamenti)).Length;
            _animationes = new IStructuraAnimationis[longitudo];

            _animationes[(int)IDPuellaeAnimationisFundamenti.None] = null;

            foreach (IConfiguratioPuellaeAnimationisFundamenti c in config) {
                _animationes[(int)c.Id] = FabricaStructuraeAnimationis.Create(
                    c.Animatio.Evolvo(IDErrorum.TABULAPUELLAEANIMATIONUMFUNDAMENTI_ANIMATION_NULL),
                    c.TempusEvanescentiae,
                    c.Lenitio,
                    c.EstSimultaneum,
                    c.EstImpeditivus
                );
            }

            for (int i = 1; i < longitudo; i++) {
                if (_animationes[i] == null) {
                    Errorum.Fatal(IDErrorum.TABULAPUELLAEANIMATIONUMFUNDAMENTI_CONFIG_NOT_FOUND);
                }
            }
        }

        public IStructuraAnimationis Lego(IDPuellaeAnimationisFundamenti idFundamenti) => _animationes[(int)idFundamenti];
    }
}


