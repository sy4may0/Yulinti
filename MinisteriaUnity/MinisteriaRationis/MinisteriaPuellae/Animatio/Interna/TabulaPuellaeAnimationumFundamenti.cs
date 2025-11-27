using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeAnimationumFundamenti {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaPuellaeAnimationumFundamenti(ConfiguratioPuellaeLuditorisFundamenti luditorisFundamenti) {
            int length = (int)IDPuellaeAnimationisFundamenti.Count;
            _animationes = new IStructuraAnimationis[length];

            _animationes[(int)IDPuellaeAnimationisFundamenti.None] = null;
            _animationes[(int)IDPuellaeAnimationisFundamenti.StandardBase] = FabricaStructuraeAnimationis.Create(
                luditorisFundamenti.BasisOrdinariae.Animatio.Evolvo(IDErrorum.TABULAPUELLAEANIMATIONUMFUNDAMENTI_STANDARD_BASE_NULL),
                luditorisFundamenti.BasisOrdinariae.TempusEvanescentiae,
                luditorisFundamenti.BasisOrdinariae.Lenitio,
                luditorisFundamenti.BasisOrdinariae.EstSimultaneum,
                luditorisFundamenti.BasisOrdinariae.EstImpeditivus
            );

            for (int i = 1; i < length; i++) {
                if (_animationes[i] == null) {
                    Errorum.Fatal(IDErrorum.TABULAPUELLAEANIMATIONUMFUNDAMENTI_PLAN_NOT_FOUND);
                }
            }
        }

        public IStructuraAnimationis Lego(IDPuellaeAnimationisFundamenti idFundamenti) => _animationes[(int)idFundamenti];
    }
}
