using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal enum PhasisMachinaCivisStatusCorporis {
        Incipalis,
        Intrans,
        Transeo,
        TranseoDesinere,
        Exiens
    }

    internal sealed class MachinaCivisStatuumCorporis {
        private readonly int _idCivis;
        private readonly IConfiguratioCivisStatuum _configuratioStatuum;
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IOstiumCivisAnimationesLegibile _animationis;

        private readonly ContextusRamusCivis _contextusRamusCivis;
        private readonly ContextusStatusCivisCorporis _contextusStatusCivisCorporis;

        private readonly TabulaCivisStatuum _tabulaCivisStatuum;
        private readonly ResolutorCivisRamorumCorporis _resolutorRamorumCorporis;

        private PhasisMachinaCivisStatusCorporis _phasisActualis;

        private IDCivisStatusCorporis _idStatusActualis;
        private IDCivisStatusCorporis _idStatusProximus;

        public MachinaCivisStatuumCorporis(
            int idCivis,
            IOstiumCarrusCivis carrus,
            IOstiumCivisAnimationesLegibile animationis,
            ContextusRamusCivis contextusRamusCivis,
            ContextusStatusCivisCorporis contextusStatusCivisCorporis,
            IConfiguratioCivisStatuum configuratioStatuum
        ) {
            _idCivis = idCivis;
            _carrus = carrus;
            _animationis = animationis;
            _contextusRamusCivis = contextusRamusCivis;
            _configuratioStatuum = configuratioStatuum;
            _contextusStatusCivisCorporis = contextusStatusCivisCorporis;
            _tabulaCivisStatuum = new TabulaCivisStatuum(_configuratioStatuum, contextusStatusCivisCorporis);
            _resolutorRamorumCorporis = new ResolutorCivisRamorumCorporis(_contextusRamusCivis);

            _phasisActualis = PhasisMachinaCivisStatusCorporis.Incipalis;
            _idStatusActualis = IDCivisStatusCorporis.Nihil;
            _idStatusProximus = IDCivisStatusCorporis.Nihil;
        }

        public void Initare(IResFluidaCivisLegibile resFluida) {
            _phasisActualis = PhasisMachinaCivisStatusCorporis.Incipalis;
            _idStatusActualis = IDCivisStatusCorporis.Nihil;
            _idStatusProximus = IDCivisStatusCorporis.Nihil;
        }

        private bool EstExhibensCorpus() {
            return _animationis.EstExhibens(_idCivis, IDCivisAnimationisStratum.Corpus);
        }

        private bool EstExhibensAutIteransCorpus() {
            return
                _animationis.EstExhibens(_idCivis, IDCivisAnimationisStratum.Corpus) ||
                _animationis.EstExhibensIterans(_idCivis, IDCivisAnimationisStratum.Corpus);
        }

        private bool EstDesinensCorpus() {
            return _animationis.EstDesinens(_idCivis, IDCivisAnimationisStratum.Corpus);
        }

        private IStatusCivisCorporis LegereStatusActualis() {
            if (_idStatusActualis == IDCivisStatusCorporis.Nihil) {
                return null;
            }
            return _tabulaCivisStatuum.Legere(_idStatusActualis);
        }

        private IStatusCivisCorporis LegereStatusProximus() {
            if (_idStatusProximus == IDCivisStatusCorporis.Nihil) {
                return null;
            }
            return _tabulaCivisStatuum.Legere(_idStatusProximus);
        }

        private void Incipere(
            IResFluidaCivisLegibile resFluida
        ) {
            if (_idStatusProximus != IDCivisStatusCorporis.Nihil) {
                MutareIntrans(resFluida);
                return;
            }

            if (_idStatusActualis != IDCivisStatusCorporis.Nihil) {
                IStatusCivisCorporis statusActualis = LegereStatusActualis();
                if (statusActualis == null) {
                    Notarius.Memorare(LogTextus.MachinaCivisStatuumCorporis_MACHINACIVISSTATUUMCORPORIS_STATUS_NOT_FOUND);
                    _idStatusProximus = _configuratioStatuum.IDStatusCorporisIncipalis;
                } else {
                    _idStatusProximus = statusActualis.IDStatusProximusAutomaticus;
                }

                MutareIntrans(resFluida);
                return;
            }

            _idStatusProximus = _configuratioStatuum.IDStatusCorporisIncipalis;
            MutareIntrans(resFluida);
        }

        private void Intrare(
            IResFluidaCivisLegibile resFluida
        ) {
            IStatusCivisCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            bool habetProximum = _idStatusProximus != IDCivisStatusCorporis.Nihil;
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
            IResFluidaCivisLegibile resFluida
        ) {
            IStatusCivisCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            bool habetProximum = _idStatusProximus != IDCivisStatusCorporis.Nihil;
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
            IResFluidaCivisLegibile resFluida
        ) {
            IStatusCivisCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            if (_idStatusProximus == IDCivisStatusCorporis.Nihil) {
                return;
            }

            if (statusActualis.EstInterdictaExire) {
                MutareExiens(resFluida);
                return;
            }

            MutareIncipalis(resFluida);
        }

        private void Exiens(
            IResFluidaCivisLegibile resFluida
        ) {
            IStatusCivisCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            bool habetProximum = _idStatusProximus != IDCivisStatusCorporis.Nihil;
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
            IResFluidaCivisLegibile resFluida
        ) {
            _idStatusActualis = _idStatusProximus;
            _idStatusProximus = IDCivisStatusCorporis.Nihil;
            _phasisActualis = PhasisMachinaCivisStatusCorporis.Intrans;

            IStatusCivisCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            statusActualis.Intrare(_idCivis, resFluida);

            // Intrare / Exire に Desinere は許可しない。
            if (statusActualis.IdAnimationisIntrare == IDCivisAnimationis.Desinere) {
                Notarius.Memorare(LogTextus.MachinaCivisStatuumCorporis_MACHINACIVISSTATUUMCORPORIS_IDANIMATIONISINTRARE_DESINERE_INVALID);
                MutareTranseo(resFluida);
                return;
            }

            if (statusActualis.IdAnimationisIntrare == IDCivisAnimationis.Nihil) {
                MutareTranseo(resFluida);
                return;
            }
        }

        private void MutareTranseo(
            IResFluidaCivisLegibile resFluida
        ) {
            _phasisActualis = PhasisMachinaCivisStatusCorporis.Transeo;

            IStatusCivisCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            statusActualis.Transere(_idCivis, resFluida);

            // Transere は以下のように扱う。
            // Nihil     : フェーズを即スキップして Exiens
            // Desinere : 停止維持フェーズへ
            // それ以外  : Transeo のままアニメーション監視
            if (statusActualis.IdAnimationisTransere == IDCivisAnimationis.Nihil) {
                MutareExiens(resFluida);
                return;
            }

            if (statusActualis.IdAnimationisTransere == IDCivisAnimationis.Desinere) {
                MutareTranseoDesinere(resFluida);
                return;
            }
        }

        private void MutareTranseoDesinere(
            IResFluidaCivisLegibile resFluida
        ) {
            _phasisActualis = PhasisMachinaCivisStatusCorporis.TranseoDesinere;

            IStatusCivisCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            statusActualis.Transere(_idCivis, resFluida);

            if (statusActualis.IdAnimationisTransere == IDCivisAnimationis.Nihil) {
                MutareExiens(resFluida);
                return;
            }

            if (statusActualis.IdAnimationisTransere != IDCivisAnimationis.Desinere) {
                MutareTranseo(resFluida);
                return;
            }
        }

        private void MutareExiens(
            IResFluidaCivisLegibile resFluida
        ) {
            _phasisActualis = PhasisMachinaCivisStatusCorporis.Exiens;

            IStatusCivisCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            statusActualis.Exire(_idCivis, resFluida);

            if (statusActualis.IdAnimationisExire == IDCivisAnimationis.Desinere) {
                Notarius.Memorare(LogTextus.MachinaCivisStatuumCorporis_MACHINACIVISSTATUUMCORPORIS_IDANIMATIONISEXIRE_DESINERE_INVALID);
                MutareIncipalis(resFluida);
                return;
            }

            if (statusActualis.IdAnimationisExire == IDCivisAnimationis.Nihil) {
                MutareIncipalis(resFluida);
                return;
            }
        }

        private void MutareIncipalis(
            IResFluidaCivisLegibile resFluida
        ) {
            _phasisActualis = PhasisMachinaCivisStatusCorporis.Incipalis;
        }

        private void MutareIncipalisCumPurgere() {
            _idStatusActualis = IDCivisStatusCorporis.Nihil;
            _idStatusProximus = IDCivisStatusCorporis.Nihil;
            _phasisActualis = PhasisMachinaCivisStatusCorporis.Incipalis;
        }

        public void Mutare(IResFluidaCivisLegibile resFluida) {
            // 予約済みなら上書きしない。
            if (_idStatusProximus != IDCivisStatusCorporis.Nihil) {
                return;
            }

            _idStatusProximus = _resolutorRamorumCorporis.Resolvere(
                _idStatusActualis,
                _idCivis,
                resFluida
            );
        }

        public void ConfirmareMutare(IResFluidaCivisLegibile resFluida) {
            if (_phasisActualis == PhasisMachinaCivisStatusCorporis.Incipalis) {
                Incipere(resFluida);
                return;
            }
            if (_phasisActualis == PhasisMachinaCivisStatusCorporis.Intrans) {
                Intrare(resFluida);
                return;
            }
            if (_phasisActualis == PhasisMachinaCivisStatusCorporis.Transeo) {
                Transere(resFluida);
                return;
            }
            if (_phasisActualis == PhasisMachinaCivisStatusCorporis.TranseoDesinere) {
                TransereDesinere(resFluida);
                return;
            }
            if (_phasisActualis == PhasisMachinaCivisStatusCorporis.Exiens) {
                Exiens(resFluida);
                return;
            }
        }

        public void Ordinare(IResFluidaCivisLegibile resFluida) {
            IStatusCivisCorporis statusActualis = LegereStatusActualis();
            if (statusActualis == null) {
                return;
            }

            statusActualis.Ordinare(_idCivis, resFluida);
        }
    }
}
