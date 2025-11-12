using UnityEngine;
using Animancer;
using System;


namespace Yulinti.MinisteriaUnity.Interna.InstulmentaAnimancer {
    public interface ILuditorAnimationis : IPulsabilis {
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
        void InjectaVelocitatem(float speed);
        void Pulsus(float deltaTime);
        float LegoTempusSimultaneum { get; }
        void PonoTempusSimultaneum(float tempus);
        bool EstImpeditivus { get; }
    }
}