using System;

namespace Yulinti.Dux.Exercitus {
    internal enum SpeciesOrdinatioCivis {
        Nihil,
        ActioMotus,
        ActioNavmesh,
        ActioAnimationis,
        VeletudinisCustodiae,
        VeletudinisMortis,
        VeletudinisValoris
    }

    internal interface IOrdinatioCivis {
        int IdCivis { get; }
        bool EstApplicandum { get; }
        void Initare();
        void Liberare();
        SpeciesOrdinatioCivis Species { get; }
        void Purgere();
    }
}