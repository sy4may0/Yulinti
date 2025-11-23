using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeCrinis {
        private readonly CrinisPuellae[] _crinis;

        public TabulaPuellaeCrinis(FasciculusConfigurationumPuellaeCrinis configuratio) {
            int longitudo = (int)IDPuellaeCrinis.Count;
            _crinis = new CrinisPuellae[longitudo];

            ConfiguratioPuellaeCrinis resiliens = configuratio.Resiliens;

            _crinis[(int)IDPuellaeCrinis.Resiliens] = new CrinisPuellae(
                resiliens.Crinis.EvolvareNuncium("TabulaPuellaeCrinis Resiliens Crinis is null."), resiliens.IterAdRadicem
            );

            for (int i = 0; i < longitudo; i++) {
                if (_crinis[i] == null) {
                    ModeratorErrorum.Fatal($"IDPuellaeCrinis {(IDPuellaeCrinis)i} が見つかりません。FasciculusConfigurationumPuellaeCrinisの設定を確認してください。");
                }
            }
        }

        public CrinisPuellae Lego(IDPuellaeCrinis idCrinis) => _crinis[(int)idCrinis];
    }
}

