using UnityEngine;
using Yulinti.MinisteriaUnity.Interna;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.ContractusMinisterii.Puellae;
using Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Animatio.Interna {
    public sealed class TabulaAnimationumFundamenti {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaAnimationumFundamenti(ConfiguratioPuellaeLuditorisFundamenti luditorisFundamenti) {
            int length = (int)IDPuellaeAnimationisBasis.Count;
            _animationes = new IStructuraAnimationis[length];

            _animationes[(int)IDPuellaeAnimationisBasis.None] = null;
            _animationes[(int)IDPuellaeAnimationisBasis.StandardBase] = FabricaStructuraeAnimationis.Create(
                luditorisFundamenti.BasisOrdinariae.Animatio,
                luditorisFundamenti.BasisOrdinariae.TempusEvanescentiae,
                luditorisFundamenti.BasisOrdinariae.Lenitio,
                luditorisFundamenti.BasisOrdinariae.EstSimultaneum,
                luditorisFundamenti.BasisOrdinariae.EstImpeditivus
            );

            for (int i = 1; i < length; i++) {
                if (_animationes[i] == null) {
                    ModeratorErrorum.Fatal($"IDPuellaeAnimationisBasis {(IDPuellaeAnimationisBasis)i} のアニメーションプランが見つかりません。ConfiguratioPuellaeLuditorisFundamentiの設定を確認してください。");
                }
            }
        }

        public IStructuraAnimationis Lego(IDPuellaeAnimationisBasis idBasis) => _animationes[(int)idBasis];
    }
}

