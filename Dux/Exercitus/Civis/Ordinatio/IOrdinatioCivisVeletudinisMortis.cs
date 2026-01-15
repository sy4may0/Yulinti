namespace Yulinti.Dux.Exercitus {
    internal enum SpeciesOrdinationisCivisMortis {
        Nihil,
        Spirituare,
        Incarnare,
    }
    internal interface IOrdinatioCivisVeletudinisMortis : IOrdinatioCivis {
        SpeciesOrdinationisCivisMortis SpeciesMortis { get; }
    }
}