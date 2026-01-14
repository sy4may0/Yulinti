using System;

namespace Yulinti.Dux.Exercitus {
    internal enum SpeciesOrdinatioPuellae {
        Nihil,
        ActioMotus,
        ActioNavmesh,
        ActioAnimationis,
        Veletudinis,
        Figura,
        Apparatus
    }
    internal interface IOrdinatioPuellae {
        bool EstApplicandum { get; }
        SpeciesOrdinatioPuellae Species { get; }
        void Purgere();
    }
}