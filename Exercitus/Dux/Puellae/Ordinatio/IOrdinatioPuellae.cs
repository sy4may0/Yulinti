using System;

namespace Yulinti.Exercitus.Dux {
    internal enum SpeciesOrdinatioPuellae {
        Nihil,
        ActioMotus,
        ActioNavmesh,
        ActioAnimationis,
        Veletudinis,
        FiguraGenus,
        FiguraPelvis,
        Apparatus,
        VeletudinisNudi,
        Personae
    }
    internal interface IOrdinatioPuellae {
        bool EstApplicandum { get; }
        void Initare();
        void Liberare();
        SpeciesOrdinatioPuellae Species { get; }
        void Purgere();
    }
}