using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Velum {
    internal interface IVelum {
        void Initare();
        void Activare();
        void Deactivare();
    }

    internal interface IVelumIncipabilis : IIncipabilis {
    }

    internal interface IVelumPalsabilis : IPulsabilis {
    }

    internal interface IVelumPalsabilisFixus : IPulsabilisFixus {
    }

    internal interface IVelumPalsabilisTardus : IPulsabilisTardus {
    }

    internal interface IVelumLiberabilis : ILiberabilis {
    }

    // DontDestroyOnLoadのTick
    internal interface IVelumIncipabilisRadicis : IIncipabilis {
    }

    internal interface IVelumPulsabilisRadicis : IPulsabilis {
    }

    internal interface IVelumPulsabilisFixusRadicis : IPulsabilisFixus {
    }
    
    internal interface IVelumPulsabilisTardusRadicis : IPulsabilisTardus {
    }

    internal interface IVelumLiberabilisRadicis : ILiberabilis {
    }
}