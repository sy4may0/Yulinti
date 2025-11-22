using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeAnimationumCorporis {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaPuellaeAnimationumCorporis(ConfiguratioPuellaeLuditorisCorporis luditorisCorporis) {
            int length = (int)IDPuellaeAnimationisCorporis.Count;
            _animationes = new IStructuraAnimationis[length];

            _animationes[(int)IDPuellaeAnimationisCorporis.None] = null;
            _animationes[(int)IDPuellaeAnimationisCorporis.Crouch] = FabricaStructuraeAnimationis.Create(
                luditorisCorporis.Incubitus.Animatio,
                luditorisCorporis.Incubitus.TempusEvanescentiae,
                luditorisCorporis.Incubitus.Lenitio,
                luditorisCorporis.Incubitus.EstSimultaneum,
                luditorisCorporis.Incubitus.EstImpeditivus
            );

            for (int i = 1; i < length; i++) {
                if (_animationes[i] == null) {
                    ModeratorErrorum.Fatal($"IDPuellaeAnimationisCorporis {(IDPuellaeAnimationisCorporis)i} のアニメーションが見つかりません。ConfiguratioPuellaeLuditorisCorporisの設定を確認してください。");
                }
            }
        }

        public IStructuraAnimationis Lego(IDPuellaeAnimationisCorporis idCorporis) => _animationes[(int)idCorporis];
    }
}
