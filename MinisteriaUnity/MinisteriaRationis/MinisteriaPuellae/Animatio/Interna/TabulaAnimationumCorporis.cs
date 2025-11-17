using UnityEngine;
using Yulinti.MinisteriaUnity.Interna;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer;
using Yulinti.ContractusMinisterii.Puellae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Animatio.Interna {
    public sealed class TabulaAnimationumCorporis {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaAnimationumCorporis(ConfiguratioPuellaeLuditorisCorporis luditorisCorporis) {
            int length = (int)IDPuellaeAnimationisActionis.Count;
            _animationes = new IStructuraAnimationis[length];

            _animationes[(int)IDPuellaeAnimationisActionis.None] = null;
            _animationes[(int)IDPuellaeAnimationisActionis.Crouch] = FabricaStructuraeAnimationis.Create(
                luditorisCorporis.Incubitus.Animatio,
                luditorisCorporis.Incubitus.TempusEvanescentiae,
                luditorisCorporis.Incubitus.Lenitio,
                luditorisCorporis.Incubitus.EstSimultaneum,
                luditorisCorporis.Incubitus.EstImpeditivus
            );

            for (int i = 1; i < length; i++) {
                if (_animationes[i] == null) {
                    ModeratorErrorum.Fatal($"IDPuellaeAnimationisActionis {(IDPuellaeAnimationisActionis)i} のアニメーションが見つかりません。FukaActionLayerConfigの設定を確認してください。");
                }
            }
        }

        public IStructuraAnimationis Lego(IDPuellaeAnimationisActionis idActionis) => _animationes[(int)idActionis];
    }
}
