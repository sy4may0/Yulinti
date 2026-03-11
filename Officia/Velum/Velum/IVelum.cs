using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Velum {
    internal interface IVelum {
        void Activare();
        void Deactivare();
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