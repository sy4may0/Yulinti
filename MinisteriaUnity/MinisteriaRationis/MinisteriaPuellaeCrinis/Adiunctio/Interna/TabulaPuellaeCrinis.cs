using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPuellaeCrinis {
        private readonly CrinisPuellae[] _crinis;

        public TabulaPuellaeCrinis(FasciculusConfigurationumPuellaeCrinis configuratio) {
            int longitudo = (int)IDPuellaeCrinis.Count;
            _crinis = new CrinisPuellae[longitudo];

            ConfiguratioPuellaeCrinis resiliens = configuratio.Resiliens;

            _crinis[(int)IDPuellaeCrinis.Resiliens] = new CrinisPuellae(
                resiliens.Crinis.Evolvo(IDErrorum.TABULAPUELLAECRINIS_RESILIENS_CRINIS_NULL), resiliens.IterAdRadicem
            );

            for (int i = 0; i < longitudo; i++) {
                if (_crinis[i] == null) {
                    Errorum.Fatal(IDErrorum.TABULAPUELLAECRINIS_ID_NOT_FOUND);
                }
            }
        }

        public CrinisPuellae Lego(IDPuellaeCrinis idCrinis) => _crinis[(int)idCrinis];
    }
}
