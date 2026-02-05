using System;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal interface IAnimatioPuellaeContinuata {
        VasculumAnimationis[] Animationes { get; }
        void PonoAdInitium(Action adInitium);
        void PonoAdFinem(Action adFinem);
        IDPuellaeAnimationisStratum Stratum { get; }
        IDPuellaeAnimationisContinuata Id { get; }
    }
}