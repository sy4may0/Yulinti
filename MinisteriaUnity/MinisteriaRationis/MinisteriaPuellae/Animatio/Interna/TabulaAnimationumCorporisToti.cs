using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer;
using Yulinti.ContractusMinisterii.Puellae;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Animatio.Interna {
    public sealed class TabulaAnimationumCorporisToti {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaAnimationumCorporisToti(FukaActionLayerConfig actionLayerConfig) {
            int length = (int)IDPuellaeAnimationisActionis.Count;
            _animationes = new IStructuraAnimationis[length];

            _animationes[(int)IDPuellaeAnimationisActionis.None] = null;
            _animationes[(int)IDPuellaeAnimationisActionis.Crouch] = FabricaStructuraeAnimationis.Create(
                actionLayerConfig.CrouchAnimationConfig.Animation,
                actionLayerConfig.CrouchAnimationConfig.FadeTime,
                actionLayerConfig.CrouchAnimationConfig.Easing,
                actionLayerConfig.CrouchAnimationConfig.Sync,
                actionLayerConfig.CrouchAnimationConfig.IsBlocking
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
