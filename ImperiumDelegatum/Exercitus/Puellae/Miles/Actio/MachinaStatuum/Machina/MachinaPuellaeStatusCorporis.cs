using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal enum PhasisMachinaPuellaeStatusCorporis {
        Incipalis,
        Intrans,
        Transeo,
        TranseoDesinere,
        Exiens
    }

    internal sealed class MachinaPuellaeStatusCorporis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly TabulaPuellaeStatuum _tabulaPuellaeStatuum;
        private readonly IConfiguratioPuellaeStatuum _configuratioStatuum;
        private readonly ResolutorPuellaeRamorumCorporis _resolutorRamorumCorporis;

        private PhasisMachinaPuellaeStatusCorporis _phasisActualis;

        private IDPuellaeStatusCorporis _idStatusActualis;
        private IDPuellaeStatusCorporis _idStatusProximus;

        public MachinaPuellaeStatusCorporis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IConfiguratioPuellaeStatuum configuratioStatuum
        ) {
            _contextusOstiorum = contextusOstiorum;
            _configuratioStatuum = configuratioStatuum;
            _tabulaPuellaeStatuum = new TabulaPuellaeStatuum(_configuratioStatuum);
            _resolutorRamorumCorporis = new ResolutorPuellaeRamorumCorporis(_contextusOstiorum);

            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Incipalis;
            _idStatusActualis = IDPuellaeStatusCorporis.Nihil;
            _idStatusProximus = IDPuellaeStatusCorporis.Nihil;
        }

        private bool EstExhibensCorpus() {
            return _contextusOstiorum.Animationis.EstExhibens(IDPuellaeAnimationisStratum.Corpus);
        }

        private bool EstExhibensAutIteransCorpus() {
            return
                _contextusOstiorum.Animationis.EstExhibens(IDPuellaeAnimationisStratum.Corpus) ||
                _contextusOstiorum.Animationis.EstExhibensIterans(IDPuellaeAnimationisStratum.Corpus);
        }

        private bool EstDesinensCorpus() {
            return _contextusOstiorum.Animationis.EstDesinens(IDPuellaeAnimationisStratum.Corpus);
        }

        private IStatusPuellaeCorporis LegereStatusActualis() {
            if (_idStatusActualis == IDPuellaeStatusCorporis.Nihil) {
                return null;
            }
            return _tabulaPuellaeStatuum.Legere(_idStatusActualis);
        }

        private IStatusPuellaeCorporis LegereStatusProximus() {
            if (_idStatusProximus == IDPuellaeStatusCorporis.Nihil) {
                return null;
            }
            return _tabulaPuellaeStatuum.Legere(_idStatusProximus);
        }

        private void Incipere(
            IResFluidaPuellaeLegibile resFluida
        ) {
            if (_idStatusProximus != IDPuellaeStatusCorporis.Nihil) {
                MutareIntrans(resFluida);
                return;
            }

            if (_idStatusActualis != IDPuellaeStatusCorporis.Nihil) {
                IStatusPuellaeCorporis statusActualis = LegereStatusActualis();
                if (statusActualis == null) {
                    Notarius.Memorare(LogTextus.MachinaPuellaeStatusCorporis_MACHINAPUELLAESTATUSCORPORIS_STATUS_NOT_FOUND);
                    _idStatusProximus = _configuratioStatuum.IDStatusCorporisIncipalis;
                } else {
                    _idStatusProximus = statusActualis.IdStatusProximusAutomaticus;
                }

                MutareIntrans(resFluida);
                return;
            }

            _idStatusProximus = _configuratioStatuum.IDStatusCorporisIncipalis;
            MutareIntrans(resFluida);
        }

        private void Intrare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            IStatusPuellaeCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            bool habetProximum = _idStatusProximus != IDPuellaeStatusCorporis.Nihil;
            bool estExhibens = EstExhibensCorpus();
            bool estDesinens = EstDesinensCorpus();

            if (!habetProximum && estExhibens) {
                return;
            }

            if (habetProximum && estExhibens) {
                if (statusActualis.EstInterdictaIntrare) {
                    return;
                }
                if (statusActualis.EstInterdictaTransere) {
                    MutareTranseo(resFluida);
                    return;
                }
                if (statusActualis.EstInterdictaExire) {
                    MutareExiens(resFluida);
                    return;
                }

                MutareIncipalis(resFluida);
                return;
            }

            if (habetProximum && estDesinens) {
                if (statusActualis.EstInterdictaTransere) {
                    MutareTranseo(resFluida);
                    return;
                }
                if (statusActualis.EstInterdictaExire) {
                    MutareExiens(resFluida);
                    return;
                }

                MutareIncipalis(resFluida);
                return;
            }

            if (!habetProximum && estDesinens) {
                MutareTranseo(resFluida);
                return;
            }
        }

        private void Transere(
            IResFluidaPuellaeLegibile resFluida
        ) {
            IStatusPuellaeCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            bool habetProximum = _idStatusProximus != IDPuellaeStatusCorporis.Nihil;
            bool estExhibensAutIterans = EstExhibensAutIteransCorpus();
            bool estDesinens = EstDesinensCorpus();

            if (!habetProximum && estExhibensAutIterans) {
                return;
            }

            if (habetProximum && estExhibensAutIterans) {
                if (statusActualis.EstInterdictaTransere) {
                    return;
                }
                if (statusActualis.EstInterdictaExire) {
                    MutareExiens(resFluida);
                    return;
                }

                MutareIncipalis(resFluida);
                return;
            }

            if (habetProximum && estDesinens) {
                if (statusActualis.EstInterdictaExire) {
                    MutareExiens(resFluida);
                    return;
                }

                MutareIncipalis(resFluida);
                return;
            }

            if (!habetProximum && estDesinens) {
                MutareExiens(resFluida);
                return;
            }
        }

        private void TransereDesinere(
            IResFluidaPuellaeLegibile resFluida
        ) {
            IStatusPuellaeCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            if (_idStatusProximus == IDPuellaeStatusCorporis.Nihil) {
                return;
            }

            if (statusActualis.EstInterdictaExire) {
                MutareExiens(resFluida);
                return;
            }

            MutareIncipalis(resFluida);
        }

        private void Exiens(
            IResFluidaPuellaeLegibile resFluida
        ) {
            IStatusPuellaeCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            bool habetProximum = _idStatusProximus != IDPuellaeStatusCorporis.Nihil;
            bool estExhibens = EstExhibensCorpus();
            bool estDesinens = EstDesinensCorpus();

            if (!habetProximum && estExhibens) {
                return;
            }

            if (habetProximum && estExhibens) {
                if (statusActualis.EstInterdictaExire) {
                    return;
                }

                MutareIncipalis(resFluida);
                return;
            }

            if (habetProximum && estDesinens) {
                MutareIncipalis(resFluida);
                return;
            }

            if (!habetProximum && estDesinens) {
                MutareIncipalis(resFluida);
                return;
            }
        }

        // 実際に現在ステートを切り替えるのはここだけ。
        private void MutareIntrans(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _idStatusActualis = _idStatusProximus;
            _idStatusProximus = IDPuellaeStatusCorporis.Nihil;
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Intrans;

            IStatusPuellaeCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            statusActualis.Intrare(_contextusOstiorum, resFluida);

            // Intrare / Exire に Desinere は許可しない。
            if (statusActualis.IdAnimationisIntrare == IDPuellaeAnimationis.Desinere) {
                Notarius.Memorare(LogTextus.MachinaPuellaeStatusCorporis_MACHINAPUELLAESTATUSCORPORIS_IDANIMATIONISINTRARE_DESINERE_INVALID);
                MutareTranseo(resFluida);
                return;
            }

            if (statusActualis.IdAnimationisIntrare == IDPuellaeAnimationis.Nihil) {
                MutareTranseo(resFluida);
                return;
            }
        }

        private void MutareTranseo(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Transeo;

            IStatusPuellaeCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            statusActualis.Transere(_contextusOstiorum, resFluida);

            // Transere は以下のように扱う。
            // Nihil     : フェーズを即スキップして Exiens
            // Desinere : 停止維持フェーズへ
            // それ以外  : Transeo のままアニメーション監視
            if (statusActualis.IdAnimationisTransere == IDPuellaeAnimationis.Nihil) {
                MutareExiens(resFluida);
                return;
            }

            if (statusActualis.IdAnimationisTransere == IDPuellaeAnimationis.Desinere) {
                MutareTranseoDesinere(resFluida);
                return;
            }
        }

        private void MutareTranseoDesinere(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.TranseoDesinere;

            IStatusPuellaeCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            statusActualis.Transere(_contextusOstiorum, resFluida);

            if (statusActualis.IdAnimationisTransere == IDPuellaeAnimationis.Nihil) {
                MutareExiens(resFluida);
                return;
            }

            if (statusActualis.IdAnimationisTransere != IDPuellaeAnimationis.Desinere) {
                MutareTranseo(resFluida);
                return;
            }
        }
        private void MutareExiens(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Exiens;

            IStatusPuellaeCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            statusActualis.Exire(_contextusOstiorum, resFluida);

            if (statusActualis.IdAnimationisExire == IDPuellaeAnimationis.Desinere) {
                Notarius.Memorare(LogTextus.MachinaPuellaeStatusCorporis_MACHINAPUELLAESTATUSCORPORIS_IDANIMATIONISEXIRE_DESINERE_INVALID);
                MutareIncipalis(resFluida);
                return;
            }

            if (statusActualis.IdAnimationisExire == IDPuellaeAnimationis.Nihil) {
                MutareIncipalis(resFluida);
                return;
            }
        }

        private void MutareIncipalis(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Incipalis;
        }

        private void MutareIncipalisCumPurgere() {
            _idStatusActualis = IDPuellaeStatusCorporis.Nihil;
            _idStatusProximus = IDPuellaeStatusCorporis.Nihil;
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Incipalis;
        }

        public void Mutare(IResFluidaPuellaeLegibile resFluida) {
            // 予約済みなら上書きしない。
            if (_idStatusProximus != IDPuellaeStatusCorporis.Nihil) {
                return;
            }

            _idStatusProximus = _resolutorRamorumCorporis.Resolvere(_idStatusActualis, resFluida);
        }

        public void ConfirmareMutare(IResFluidaPuellaeLegibile resFluida) {
            if (_phasisActualis == PhasisMachinaPuellaeStatusCorporis.Incipalis) {
                Incipere(resFluida);
                return;
            }
            if (_phasisActualis == PhasisMachinaPuellaeStatusCorporis.Intrans) {
                Intrare(resFluida);
                return;
            }
            if (_phasisActualis == PhasisMachinaPuellaeStatusCorporis.Transeo) {
                Transere(resFluida);
                return;
            }
            if (_phasisActualis == PhasisMachinaPuellaeStatusCorporis.TranseoDesinere) {
                TransereDesinere(resFluida);
                return;
            }
            if (_phasisActualis == PhasisMachinaPuellaeStatusCorporis.Exiens) {
                Exiens(resFluida);
                return;
            }
        }

        public void Ordinare(IResFluidaPuellaeLegibile resFluida) {
            IStatusPuellaeCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                return;
            }

            statusActualis.Ordinare(_contextusOstiorum, resFluida);
        }
    }
}