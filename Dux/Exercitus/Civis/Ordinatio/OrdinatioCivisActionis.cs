using System;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal enum SpeciesOrdinationisCivis {
        Nihil, // このEnumの先頭をNihilから変更するな。
        Motus,
        Navmesh,
        InitareNavmesh
    }

    internal readonly struct OrdinatioCivisActionis {
        public SpeciesOrdinationisCivis Species { get; }
        private readonly OrdinatioCivisMotus _motus;
        private readonly OrdinatioCivisNavmesh _navmesh;
        private readonly OrdinatioCivisInitareNavmesh _initareNavmesh;
        private readonly int _idCivis;
        private readonly bool _estError;

        private OrdinatioCivisActionis(int idCivis, OrdinatioCivisMotus motus) {
            Species = SpeciesOrdinationisCivis.Motus;
            _motus = motus;
            _navmesh = default;
            _initareNavmesh = default;
            _idCivis = idCivis;
            _estError = false;
        }

        private OrdinatioCivisActionis(int idCivis, OrdinatioCivisNavmesh navmesh) {
            Species = SpeciesOrdinationisCivis.Navmesh;
            _navmesh = navmesh;
            _motus = default;
            _initareNavmesh = default;
            _idCivis = idCivis;
            _estError = false;
        }

        private OrdinatioCivisActionis(int idCivis, OrdinatioCivisInitareNavmesh initareNavmesh) {
            Species = SpeciesOrdinationisCivis.InitareNavmesh;
            _initareNavmesh = initareNavmesh;
            _motus = default;
            _navmesh = default;
            _idCivis = idCivis;
            _estError = false;
        }

        // Nihil生成
        private OrdinatioCivisActionis(int idCivis) {
            Species = SpeciesOrdinationisCivis.Nihil;
            _motus = default;
            _navmesh = default;
            _initareNavmesh = default;
            _idCivis = idCivis;
            _estError = false;
        }
        // Error生成
        private OrdinatioCivisActionis(int idCivis, bool estError) {
            Species = SpeciesOrdinationisCivis.Nihil;
            _motus = default;
            _navmesh = default;
            _initareNavmesh = default;
            _idCivis = idCivis;
            _estError = true;
        }

        public bool EstApplicandum {
            get {
                return Species != SpeciesOrdinationisCivis.Nihil;
            }
        }
        public bool EstError {
            get {
                return _estError;
            }
        }

        public static OrdinatioCivisActionis FromMotus(int idCivis, OrdinatioCivisMotus motus) {
            return new(idCivis, motus);
        }
        public static OrdinatioCivisActionis FromNavmesh(int idCivis, OrdinatioCivisNavmesh navmesh) {
            return new(idCivis, navmesh);
        }
        public static OrdinatioCivisActionis FromInitareNavmesh(int idCivis, OrdinatioCivisInitareNavmesh initareNavmesh) {
            return new(idCivis, initareNavmesh);
        }
        public static OrdinatioCivisActionis Nihil(int idCivis) {
            return new(idCivis);
        }
        public static OrdinatioCivisActionis Error(int idCivis) {
            return new(idCivis, true);
        }

        public int IdCivis {
            get {
                return _idCivis;
            }
        }

        public OrdinatioCivisMotus Motus {
            get {
                if (Species == SpeciesOrdinationisCivis.Motus) {
                    return _motus;
                }
                Memorator.MemorareErrorum(IDErrorum.ORDINATIOCIVISACTIONIS_GET_MISSMATCH_SPECIES);
                return default;
            }
        }
        public OrdinatioCivisNavmesh Navmesh {
            get {
                if (Species == SpeciesOrdinationisCivis.Navmesh) {
                    return _navmesh;
                }
                Memorator.MemorareErrorum(IDErrorum.ORDINATIOCIVISACTIONIS_GET_MISSMATCH_SPECIES);
                return default;
            }
        }
        public OrdinatioCivisInitareNavmesh InitareNavmesh {
            get {
                if (Species == SpeciesOrdinationisCivis.InitareNavmesh) {
                    return _initareNavmesh;
                }
                Memorator.MemorareErrorum(IDErrorum.ORDINATIOCIVISACTIONIS_GET_MISSMATCH_SPECIES);
                return default;
            }
        }

        public void Match(
            Action<OrdinatioCivisMotus> motus,
            Action<OrdinatioCivisNavmesh> navmesh,
            Action<OrdinatioCivisInitareNavmesh> initareNavmesh
        ) {
            switch (Species) {
                case SpeciesOrdinationisCivis.Motus:
                    motus(Motus);
                    return;
                case SpeciesOrdinationisCivis.Navmesh:
                    navmesh(Navmesh);
                    return;
                case SpeciesOrdinationisCivis.InitareNavmesh:
                    initareNavmesh(InitareNavmesh);
                    return;
                case SpeciesOrdinationisCivis.Nihil:
                    return;
                default:
                    Memorator.MemorareErrorum(IDErrorum.ORDINATIOCIVISACTIONIS_INVALID_SPECIES);
                    return;
            }
        }
    }
}
