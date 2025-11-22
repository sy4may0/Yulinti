using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface ILuditorAnimationis {
        int IndexusLuditoris { get; }
        IStructuraAnimationis AnimatioCurrens { get; }
        void Postulare(
            IStructuraAnimationis animatio,
            Action fInvocanda,
            bool obsignare
        );
        void Cogere(
            IStructuraAnimationis animatio,
            Action fInvocanda,
            bool obsignare
        );
        void CogereDesinentiam();
        void InjicereVelocitatem(float vel);
        float LegoTempusSimultaneum();
        void PonoTempusSimultaneum(float tempus);
        bool EstImpeditivus { get; }
    }
}