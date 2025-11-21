namespace Yulinti.Nucleus {
    public interface IPulsabilis {
        void Pulsus();
    }

    // Ministeria専用 / DeltaTime更新とか。
    public interface IPulsabilisPrimum {
        void PulsusPrimum();
    }

    // Dux専用
    public interface IPulsabilisPostRationem {
        void PulsusPostRationem();
    }

    public interface IPulsabilisFixus {
        void PulsusFixus();
    }

    // Ministeria専用 / FixedDeltaTime更新とか。
    public interface IPulsabilisFixusPrimum {
        void PulsusFixusPrimum();
    }

    public interface IPulsabilisTardus {
        void PulsusTardus();
    }
}
