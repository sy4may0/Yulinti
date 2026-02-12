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
}