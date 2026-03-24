using Yulinti.ImperiumDelegatum.Contractus;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class StatusPuellaeCorporisMotusQuietes : IStatusPuellaeCorporis {
        private readonly IConfiguratioPuellaeStatuum _configuratioStatuum;
        private readonly IConfiguratioPuellaeStatusCorporisMotus _configuratio;

        private readonly IOstiumCarrusPuellae _carrus;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly ITurrisIntroductionis _turrisIntroductionis;

        public StatusPuellaeCorporisMotusQuietes(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporisMotus configuratio,
            ContextusStatusPuellaeCorporis contextus
        ) {
            _configuratioStatuum = configuratioStatuum;
            _configuratio = configuratio;

            _carrus = contextus.Carrus;
            _temporis = contextus.Temporis;
            _turrisIntroductionis = contextus.Introductionis;
        }

        public IDPuellaeStatusCorporis Id => _configuratio.Id;
        public IDPuellaeAnimationis IdAnimationisIntrare => _configuratio.IdAnimationisIntrare;
        public IDPuellaeAnimationis IdAnimationisTransere => _configuratio.IdAnimationisTransere;
        public IDPuellaeAnimationis IdAnimationisExire => _configuratio.IdAnimationisExire;

        public bool EstInterdictaIntrare => _configuratio.EstInterdictaIntrare;
        public bool EstInterdictaTransere => _configuratio.EstInterdictaTransere;
        public bool EstInterdictaExire => _configuratio.EstInterdictaExire;

        public IDPuellaeStatusCorporis IdStatusProximusAutomaticus => _configuratio.IdStatusProximusAutomaticus;

        public void Intrare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _carrus.PostulareAnimationis(
                IDPuellaeAnimationisStratum.Corpus,
                IdAnimationisIntrare
            );
        }

        public void Transere(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _carrus.PostulareAnimationis(
                IDPuellaeAnimationisStratum.Corpus,
                IdAnimationisTransere
            );
        }
        
        public void Exire(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _carrus.PostulareAnimationis(
                IDPuellaeAnimationisStratum.Corpus,
                IdAnimationisExire
            );
        }

        public void Ordinare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            MotusPuellaeHorizontalis oh = InstrumentaPuellaeMotus.OrdinareMotusHorizontalis(
                _turrisIntroductionis.LegoMotus,
                0f,
                resFluida.Motus.VelocitasActualisHorizontalis,
                _configuratio.Acceleratio, _configuratio.Deceleratio,
                _configuratioStatuum.TempusLevigatumMin,
                _configuratioStatuum.TempusLevigatumMax,
                _configuratioStatuum.LimenInputQuadratum,
                _configuratio.EstLevigatum
            );
            MotusPuellaeRotationisY or = InstrumentaPuellaeMotus.OrdinareMotusSineRotationisY(
                resFluida.Motus.RotatioYActualis
            );

            _carrus.PostulareMotus(
                oh.Velocitas,
                oh.TempusLevigatum,
                or.RotatioY,
                or.TempusLevigatum
            );
            _carrus.PostulareVeletudinis(
                dtVigoris: _configuratio.ConsumptioVigorisSec * _temporis.Intervallum,
                dtPatientiae: _configuratio.ConsumptioPatientiaeSec * _temporis.Intervallum,
                dtAetheris: _configuratio.IncrementumAetherisSec * _temporis.Intervallum,
                dtIntentio: _configuratio.Intentio,
                dtClaritas: _configuratio.Claritas,
                dtSonusQuietes: _configuratio.SonusQuietes,
                dtSonusMotus: _configuratio.SonusMotus
            );
        }
    }
}