using Yulinti.Nucleus.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.Officia.Velum {
    internal interface IVelum {
        void Activare();
        void Deactivare();
    }

    internal interface IVelumElementi {
        void Activare();
        void Deactivare();
    }

    internal interface IVelumPars {
        void Incipere(VisualElement parens);
        void Activare();
        void Deactivare();
        void PonoPermissiones(bool permissio);
    }

    internal interface IVelumIncipabilis : IIncipabilis {
    }

    internal interface IVelumLiberabilis : ILiberabilis {
    }

    // DontDestroyOnLoadのTick
    internal interface IVelumIncipabilisRadicis : IIncipabilis {
    }

    internal interface IVelumLiberabilisRadicis : ILiberabilis {
    }
}