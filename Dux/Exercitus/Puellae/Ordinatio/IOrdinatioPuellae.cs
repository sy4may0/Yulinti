using System;

namespace Yulinti.Dux.Exercitus {
    internal enum SpeciesOrdinatioPuellae {
        Nihil,
        ActioMotus,
        ActioNavmesh,
        ActioAnimationis,
        Veletudinis,
        FiguraGenus,
        FiguraPelvis,
        Apparatus,
        VeletudinisNudi
    }
    internal interface IOrdinatioPuellae {
        bool EstApplicandum { get; }
        void Initare();
        void Liberare();
        SpeciesOrdinatioPuellae Species { get; }
        void Purgere();
    }
}