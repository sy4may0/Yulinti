using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal enum SpeciesOrdinatioPuellae {
        Nihil,
        ActioMotus,
        ActioNavmesh,
        ActioNavmeshInitii,
        ActioAnimationis,
        Veletudinis,
        FiguraGenus,
        FiguraPelvis,
        Apparatus,
        VeletudinisNudi,
        Personae,
        PersonaeInitii
    }
    internal interface IOrdinatioPuellae {
        bool EstApplicandum { get; }
        void Initare();
        void Liberare();
        SpeciesOrdinatioPuellae Species { get; }
        void Purgere();
    }
}