using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    public sealed class DuxExercitus : IPulsabilis, IPulsabilisTardus  {
        // VContainerにするけど仮で手動ビルドする。
        private readonly CenturioPuellae _centurioPuellae;

        public DuxExercitus(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporis[] configurationemCorporis,
            IConfiguratioPuellaeActionisSecundarius configuratioActionisSecundarius,
            IOstiumInputMotusLegibile osInputMotusLeg,
            IOstiumTemporisLegibile osTemporisLeg,
            IOstiumCameraLegibile osCameraLeg,
            IOstiumPuellaeAnimationesMutabile osAnimationes,
            IOstiumPuellaeLociMutabile osPuellaeLociMut,
            IOstiumPuellaeLociLegibile osPuellaeLociLeg,
            IOstiumPuellaeRelationisTerraeLegibile osPuellaeRelationisTerraeLeg,
            IOstiumPuellaeOssisMutabile osPuellaeOssisMut,
            IOstiumPuellaeOssisLegibile osPuellaeOssisLeg,
            IOstiumPuellaeFiguraePelvisMutabile osPuellaeFiguraePelvisMut,
            IOstiumPuellaeFiguraeGenusMutabile osPuellaeFiguraeGenusMut,
            IOstiumPuellaeCrinisAdiunctionisMutabile osPuellaeCrinisAdiunctionisMut
        ) {
            IMilesPuellaeActionis milesPuellaeActionis = new MilesPuellaeActionis(
                configuratioStatuum,
                configurationemCorporis,
                osInputMotusLeg,
                osTemporisLeg,
                osCameraLeg,
                osAnimationes,
                osPuellaeLociMut,
                osPuellaeLociLeg
            );
            IMilesPuellaeActionisSecundarius milesPuellaeActionisSecundarius = new MilesPuellaeActionisSecundarius(
                osPuellaeRelationisTerraeLeg,
                osPuellaeOssisMut,
                osPuellaeOssisLeg,
                configuratioActionisSecundarius
            );

            IMilesPuellaeFigurae milesPuellaeFigurae = new MilesPuellaeFigurae(
                osPuellaeOssisLeg,
                osPuellaeFiguraePelvisMut,
                osPuellaeFiguraeGenusMut
            );
            IMilesPuellaeCrinis milesPuellaeCrinis = new MilesPuellaeCrinis(
                osPuellaeCrinisAdiunctionisMut
            );

            _centurioPuellae = new CenturioPuellae(
                milesPuellaeActionis,
                milesPuellaeActionisSecundarius,
                milesPuellaeFigurae,
                milesPuellaeCrinis
            );
        }

        public void Pulsus() {
            _centurioPuellae.Pulsus();
        }

        public void PulsusTardus() {
            _centurioPuellae.PulsusTardus();
        }
    }
}