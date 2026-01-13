using System;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal enum SpeciesOrdinationisPuellae {
        Nihil, // このEnumの先頭をNihilから変更するな。
        Motus,
        Navmesh
    }
    internal readonly struct OrdinatioPuellaeActionis {
        public SpeciesOrdinationisPuellae Species { get; }
        private readonly OrdinatioPuellaeMotus _motus;
        private readonly OrdinatioPuellaeNavmesh _navmesh;

        private OrdinatioPuellaeActionis(in OrdinatioPuellaeMotus motus) {
            Species = SpeciesOrdinationisPuellae.Motus;
            _motus = motus;
            _navmesh = default;
        }

        private OrdinatioPuellaeActionis(in OrdinatioPuellaeNavmesh navmesh) {
            Species = SpeciesOrdinationisPuellae.Navmesh;
            _navmesh = navmesh;
            _motus = default;
        }

        public bool EstApplicandum {
            get {
                return Species != SpeciesOrdinationisPuellae.Nihil;
            }
        }

        public static OrdinatioPuellaeActionis FromMotus(in OrdinatioPuellaeMotus motus) {
            return new(motus);
        } 
        public static OrdinatioPuellaeActionis FromNavmesh(in OrdinatioPuellaeNavmesh navmesh) {
            return new(navmesh);
        }
        public static OrdinatioPuellaeActionis Nihil() {
            return default;
        }

        public OrdinatioPuellaeMotus Motus {
            get {
                if (Species == SpeciesOrdinationisPuellae.Motus) {
                    return _motus;
                }
                Memorator.MemorareErrorum(IDErrorum.ORDINATIOPUELLAEACTIONIS_GET_MISSMATCH_SPECIES);
                return default;
            }
        }
        public OrdinatioPuellaeNavmesh Navmesh {
            get {
                if (Species == SpeciesOrdinationisPuellae.Navmesh) {
                    return _navmesh;
                }
                Memorator.MemorareErrorum(IDErrorum.ORDINATIOPUELLAEACTIONIS_GET_MISSMATCH_SPECIES);
                return default;
            }
        }

        public void Match(
            Action<OrdinatioPuellaeMotus> motus,
            Action<OrdinatioPuellaeNavmesh> navmesh
        ) {
            switch (Species) {
                case SpeciesOrdinationisPuellae.Motus:
                    motus(Motus);
                    return;
                case SpeciesOrdinationisPuellae.Navmesh:
                    navmesh(Navmesh);
                    return;
                default:
                    Memorator.MemorareErrorum(IDErrorum.ORDINATIOPUELLAEACTIONIS_INVALID_SPECIES);
                    return;
            }
        }
    }
}
