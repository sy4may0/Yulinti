using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class CenturioPuellae : ICenturio, ICenturioIncipabilis, ICenturioPulsabilis, ICenturioPulsabilisTardus {
        private readonly MilesPuellaeActionis _milesPuellaeActionis;
        private readonly MilesPuellaeCrinis _milesPuellaeCrinis;
        private readonly MilesPuellaeFigurae _milesPuellaeFigurae;

        // Carrus
        private readonly CarrusPuellae _carrusPuellae;

        // ResFluidaファサード
        private readonly IResFluidaPuellaeLegibile _resFluidaLegibile;

        // VContainer注入
        public CenturioPuellae(
            MilesPuellaeActionis milesPuellaeActionis,
            MilesPuellaeCrinis milesPuellaeCrinis,
            MilesPuellaeFigurae milesPuellaeFigurae,
            IResFluidaPuellaeLegibile resFluidaLegibile,
            CarrusPuellae carrusPuellae
        ) {
            _milesPuellaeActionis = milesPuellaeActionis;
            _milesPuellaeCrinis = milesPuellaeCrinis;
            _milesPuellaeFigurae = milesPuellaeFigurae;
            _resFluidaLegibile = resFluidaLegibile;
            _carrusPuellae = carrusPuellae;
        }

        public void Incipere() {
            _carrusPuellae.Primum();
            _milesPuellaeActionis.Initare(_resFluidaLegibile);
            _milesPuellaeCrinis.Initare();
            _carrusPuellae.ConfirmareIncipabilis();
        }

        public void Pulsus() {
            // Carrus初期化実行
            _carrusPuellae.Primum();

            // Ordinatio計画
            _milesPuellaeActionis.MutareStatus(_resFluidaLegibile);
            _milesPuellaeActionis.Ordinare(_resFluidaLegibile);

            // Carrus適用(Ordinatio実行)
            _carrusPuellae.Confirmare();
        }

        public void PulsusTardus() {
            // Ordinatio計画
            _milesPuellaeFigurae.Ordinare();

            // Carrus適用(Ordinatio実行)
            _carrusPuellae.ConfirmareTardus();
        }

    }
}
