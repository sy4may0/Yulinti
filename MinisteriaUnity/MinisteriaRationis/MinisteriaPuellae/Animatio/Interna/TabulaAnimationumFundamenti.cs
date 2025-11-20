using UnityEngine;
using Yulinti.MinisteriaUnity.Interna;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Animatio.Interna {
    public sealed class TabulaAnimationumFundamenti {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaAnimationumFundamenti(ConfiguratioPuellaeLuditorisFundamenti luditorisFundamenti) {
            int length = (int)IDPuellaeAnimationisFundamenti.Count;
            _animationes = new IStructuraAnimationis[length];

            _animationes[(int)IDPuellaeAnimationisFundamenti.None] = null;
            _animationes[(int)IDPuellaeAnimationisFundamenti.StandardBase] = FabricaStructuraeAnimationis.Create(
                luditorisFundamenti.BasisOrdinariae.Animatio,
                luditorisFundamenti.BasisOrdinariae.TempusEvanescentiae,
                luditorisFundamenti.BasisOrdinariae.Lenitio,
                luditorisFundamenti.BasisOrdinariae.EstSimultaneum,
                luditorisFundamenti.BasisOrdinariae.EstImpeditivus
            );

            for (int i = 1; i < length; i++) {
                if (_animationes[i] == null) {
                    ModeratorErrorum.Fatal($"IDPuellaeAnimationisFundamenti {(IDPuellaeAnimationisFundamenti)i} のアニメーションプランが見つかりません。ConfiguratioPuellaeLuditorisFundamentiの設定を確認してください。");
                }
            }
        }

        public IStructuraAnimationis Lego(IDPuellaeAnimationisFundamenti idFundamenti) => _animationes[(int)idFundamenti];
    }
}

