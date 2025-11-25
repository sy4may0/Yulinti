namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface IResolvorPunctumViae {
        ErrorAut<IPunctumViae> Resolvo(
            IPunctumViae pAntecedens,
            IPunctumViae[] pConsequens
        );
    }
}