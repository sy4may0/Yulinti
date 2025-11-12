using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Animatio.Interna {
    public sealed class TabulaAnimationumCorporisToti {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaAnimationumCorporisToti(FukaActionLayerConfig actionLayerConfig) {
            int length = (int)FukaActionLayerAnimationID.Count;
            _animationes = new IStructuraAnimationis[length];

            _animationes[(int)FukaActionLayerAnimationID.None] = null;
            _animationes[(int)FukaActionLayerAnimationID.Crouch] = FabricaStructuraeAnimationis.Create(
                actionLayerConfig.CrouchAnimationConfig.Animation,
                actionLayerConfig.CrouchAnimationConfig.FadeTime,
                actionLayerConfig.CrouchAnimationConfig.Easing,
                actionLayerConfig.CrouchAnimationConfig.Sync,
                actionLayerConfig.CrouchAnimationConfig.IsBlocking
            );

            for (int i = 1; i < length; i++) {
                if (_animationes[i] == null) {
                    ModeratorErrorum.Fatal($"FukaActionLayerAnimationID {(FukaActionLayerAnimationID)i} のアニメーションが見つかりません。FukaActionLayerConfigの設定を確認してください。");
                }
            }
        }

        public IStructuraAnimationis Lego(FukaActionLayerAnimationID animationID) => _animationes[(int)animationID];
    }
}
