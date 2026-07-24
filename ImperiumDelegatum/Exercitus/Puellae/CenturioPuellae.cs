using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class CenturioPuellae : ICenturio, ICenturioIncipabilis, ICenturioPulsabilis, ICenturioPulsabilisTardus {
        private readonly MilesPuellaeActionis _milesPuellaeActionis;
        private readonly MilesPuellaeCrinis _milesPuellaeCrinis;
        private readonly MilesPuellaeFigurae _milesPuellaeFigurae;
        private readonly MilesPuellaeVestitae _milesPuellaeVestitae;
        private readonly MilesPuellaeVeletudinisMaxima _milesPuellaeVeletudinisMaxima;
        private readonly MilesPuellaeVeletudinisAnomaliae _milesPuellaeVeletudinisAnomaliae;

        // Carrus
        private readonly CarrusPuellae _carrusPuellae;

        // ResFluidaファサード
        private readonly IResFluidaPuellaeLegibile _resFluidaLegibile;

        // VContainer注入
        public CenturioPuellae(
            MilesPuellaeActionis milesPuellaeActionis,
            MilesPuellaeCrinis milesPuellaeCrinis,
            MilesPuellaeFigurae milesPuellaeFigurae,
            MilesPuellaeVestitae milesPuellaeVestitae,
            MilesPuellaeVeletudinisMaxima milesPuellaeVeletudinisMaxima,
            MilesPuellaeVeletudinisAnomaliae milesPuellaeVeletudinisAnomaliae,
            IResFluidaPuellaeLegibile resFluidaLegibile,
            CarrusPuellae carrusPuellae
        ) {
            _milesPuellaeActionis = milesPuellaeActionis;
            _milesPuellaeCrinis = milesPuellaeCrinis;
            _milesPuellaeFigurae = milesPuellaeFigurae;
            _milesPuellaeVestitae = milesPuellaeVestitae;
            _milesPuellaeVeletudinisMaxima = milesPuellaeVeletudinisMaxima;
            _milesPuellaeVeletudinisAnomaliae = milesPuellaeVeletudinisAnomaliae;
            _resFluidaLegibile = resFluidaLegibile;
            _carrusPuellae = carrusPuellae;
        }

        public void Incipere() {
            _carrusPuellae.Initare();
            _carrusPuellae.Primum();
            _milesPuellaeActionis.Initare(_resFluidaLegibile);
            _milesPuellaeCrinis.Initare();
            _milesPuellaeVestitae.Initare();
            _milesPuellaeVeletudinisMaxima.Initare();
            _milesPuellaeVeletudinisAnomaliae.Initare();
            _carrusPuellae.ConfirmareIncipabilis();
        }

        public void Pulsus() {
            // Carrus初期化実行
            _carrusPuellae.Primum();

            // VeletudinisMaxima計画
            _milesPuellaeVeletudinisMaxima.Ordinare();

            // VeletudinisAnomaliae計画
            _milesPuellaeVeletudinisAnomaliae.Ordinare();

            // Actionis計画
            _milesPuellaeActionis.MutareStatus(_resFluidaLegibile);
            _milesPuellaeActionis.Ordinare(_resFluidaLegibile);
            _milesPuellaeVestitae.Ordinare(_resFluidaLegibile);

            // Carrus適用(Ordinatio実行)
            _carrusPuellae.Confirmare();
        }

        public void PulsusTardus() {
            // Figurae計画
            _milesPuellaeFigurae.Ordinare();

            // Carrus適用(Ordinatio実行)
            _carrusPuellae.ConfirmareTardus();
        }

    }
}
