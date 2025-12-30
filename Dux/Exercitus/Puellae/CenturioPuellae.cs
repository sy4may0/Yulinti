using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class CenturioPuellae : ICenturio, ICenturioPulsabilis, ICenturioPulsabilisTardus {
        private readonly MilesPuellaeActionis _milesPuellaeActionis;

        private readonly ResolutorPuellaeVeletudinis _resolutorVeletudinis;

        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly ContextusPuellaeResFluidaLegibile _contextusResFluida;

        private ResFluidaPuellaeVeletudinis _resFluidaVeletudinis;
        private ResFluidaPuellaeMotus _resFluidaMotus;

        // VContainer注入
        public CenturioPuellae(
            IConfiguratioExercitusPuellae configuratio,
            IOstiumTemporisLegibile temporis,
            IOstiumCameraLegibile camera,
            IOstiumInputMotusLegibile inputMotus,
            IOstiumPuellaeLociLegibile puellaeLoci,
            IOstiumPuellaeRelationisTerraeLegibile relationisTerrae,
            IOstiumPuellaeOssisLegibile ossis,
            IOstiumPuellaeAnimationesMutabile osAnimationesMut,
            IOstiumPuellaeLociMutabile osLociMut
        ) {
            _resFluidaVeletudinis = new ResFluidaPuellaeVeletudinis();
            _resFluidaMotus = new ResFluidaPuellaeMotus();

            _contextusResFluida = new ContextusPuellaeResFluidaLegibile(
                _resFluidaVeletudinis,
                _resFluidaMotus
            );
            _contextusOstiorum = new ContextusPuellaeOstiorumLegibile(
                configuratio,
                temporis,
                camera,
                inputMotus,
                puellaeLoci,
                relationisTerrae,
                ossis
            );
            _resolutorVeletudinis = new ResolutorPuellaeVeletudinis();

            _milesPuellaeActionis = new MilesPuellaeActionis(
                _contextusOstiorum,
                osAnimationesMut,
                osLociMut
            );
        }

        public void Pulsus() {
            _milesPuellaeActionis.OrdinareActionis(_contextusResFluida);
            _milesPuellaeActionis.ApplicareActionis(_contextusResFluida);
            _milesPuellaeActionis.RenovareResFluidaMotus(ref _resFluidaMotus);
            _resolutorVeletudinis.Resolvere(
                _milesPuellaeActionis.OrdinareVeletudinis(_contextusResFluida)
            );
            _milesPuellaeActionis.InjicereVelocitatis();
        }

        public void PulsusTardus() {
            _resolutorVeletudinis.Applicare(
                ref _resFluidaVeletudinis
            );
        }

    }
}
