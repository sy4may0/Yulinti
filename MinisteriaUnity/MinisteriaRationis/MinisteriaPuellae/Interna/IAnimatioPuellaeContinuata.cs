using System;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface IAnimatioPuellaeContinuata {
        VasculumAnimationis[] Animationes { get; }
        void PonoAdInitium(Action adInitium);
        void PonoAdFinem(Action adFinem);
        IDPuellaeAnimationisStratum Stratum { get; }
        IDPuellaeAnimationisContinuata Id { get; }
    }
}