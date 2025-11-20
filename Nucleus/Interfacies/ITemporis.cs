namespace Yulinti.Nucleus.Interfacies {
    public interface IPulsabilis {
        void Pulsus();
    }

    // Dux専用
    public interface IPulsabilisPostRationem : IPulsabilis {
        void PulsusPostRationem();
    }

    public interface IPulsabilisFixus {
        void PulsusFixus();
    }

    public interface IPulsabilisTardus {
        void PulsusTardus();
    }
}