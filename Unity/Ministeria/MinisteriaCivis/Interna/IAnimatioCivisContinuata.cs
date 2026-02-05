using System;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal interface IAnimatioCivisContinuata {
        VasculumAnimationis[] Animationes { get; }
        void PonoAdInitium(Action adInitium);
        void PonoAdFinem(Action adFinem);
        IDCivisAnimationisStratum Stratum { get; }
        IDCivisAnimationisContinuata Id { get; }
    }
}