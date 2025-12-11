using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    public interface ICenturio {
    }

    public interface ICenturioPulsabilis : IPulsabilis {
    }

    public interface ICenturioPulsabilisPrimum : IPulsabilisPrimum {
    }

    public interface ICenturioPulsabilisPostRationem {
        void PulsusPostRationem();
    }

    public interface ICenturioPulsabilisFixus : IPulsabilisFixus {
    }

    public interface ICenturioPulsabilisFixusPrimum : IPulsabilisFixusPrimum {
    }

    public interface ICenturioPulsabilisFixusPostRationem {
        void PulsusFixusPostRationem();
    }

    public interface ICenturioPulsabilisTardus : IPulsabilisTardus {
    }

    public interface ICenturioPulsabilisTardusPrimum : IPulsabilisTardusPrimum {
    }

    public interface ICenturioPulsabilisTardusPostRationem {
        void PulsusTardusPostRationem();
    }
}