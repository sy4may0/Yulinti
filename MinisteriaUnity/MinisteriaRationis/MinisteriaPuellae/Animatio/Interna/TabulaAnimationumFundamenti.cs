using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.ContractusMinisterii.Puellae;
using Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Animatio.Interna {
    public sealed class TabulaAnimationumFundamenti {
        private readonly IStructuraAnimationis[] _animationes;

        public TabulaAnimationumFundamenti(FukaBaseLayerConfig baseLayerConfig) {
            int length = (int)IDPuellaeAnimationisBasis.Count;
            _animationes = new IStructuraAnimationis[length];

            _animationes[(int)IDPuellaeAnimationisBasis.None] = null;
            _animationes[(int)IDPuellaeAnimationisBasis.StandardBase] = FabricaStructuraeAnimationis.Create(
                baseLayerConfig.StandardBaseAnimationConfig.Animation,
                baseLayerConfig.StandardBaseAnimationConfig.FadeTime,
                baseLayerConfig.StandardBaseAnimationConfig.Easing,
                baseLayerConfig.StandardBaseAnimationConfig.Sync,
                baseLayerConfig.StandardBaseAnimationConfig.IsBlocking
            );

            for (int i = 1; i < length; i++) {
                if (_animationes[i] == null) {
                    ModeratorErrorum.Fatal($"IDPuellaeAnimationisBasis {(IDPuellaeAnimationisBasis)i} のアニメーションプランが見つかりません。FukaBaseLayerConfigの設定を確認してください。");
                }
            }
        }

        public IStructuraAnimationis Lego(IDPuellaeAnimationisBasis idBasis) => _animationes[(int)idBasis];
    }
}

