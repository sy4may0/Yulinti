using System;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface IAnimatioCivisContinuata {
        VasculumAnimationis[] Animationes { get; }
        void PonoAdInitium(Action adInitium);
        void PonoAdFinem(Action adFinem);
        IDCivisAnimationisStratum Stratum { get; }
        IDCivisAnimationisContinuata Id { get; }
    }
}