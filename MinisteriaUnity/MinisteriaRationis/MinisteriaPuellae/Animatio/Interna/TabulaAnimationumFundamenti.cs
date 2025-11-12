using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Animatio.Interna {
    public sealed class TabulaAnimationumFundamenti {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaAnimationumFundamenti(FukaBaseLayerConfig baseLayerConfig) {
            int length = (int)FukaBaseLayerAnimationID.Count;
            _animationes = new IStructuraAnimationis[length];

            _animationes[(int)FukaBaseLayerAnimationID.None] = null;
            _animationes[(int)FukaBaseLayerAnimationID.StandardBase] = FabricaStructuraeAnimationis.Create(
                baseLayerConfig.StandardBaseAnimationConfig.Animation,
                baseLayerConfig.StandardBaseAnimationConfig.FadeTime,
                baseLayerConfig.StandardBaseAnimationConfig.Easing,
                baseLayerConfig.StandardBaseAnimationConfig.Sync,
                baseLayerConfig.StandardBaseAnimationConfig.IsBlocking
            );

            for (int i = 1; i < length; i++) {
                if (_animationes[i] == null) {
                    ModeratorErrorum.Fatal($"FukaBaseLayerAnimationID {(FukaBaseLayerAnimationID)i} のアニメーションプランが見つかりません。FukaBaseLayerConfigの設定を確認してください。");
                }
            }
        }

        public IStructuraAnimationis Lego(FukaBaseLayerAnimationID animationID) => _animationes[(int)animationID];
    }
}

