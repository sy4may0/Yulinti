namespace Yulinti.Dux.Exercitus {
    internal enum SpeciesOrdinationisCivisMortis {
        Nihil,
        Spirituare,
        Incarnare,
    }
    internal interface IOrdinatioCivisMortis : IOrdinatioCivis {
        SpeciesOrdinationisCivisMortis SpeciesMortis { get; }
    }
}