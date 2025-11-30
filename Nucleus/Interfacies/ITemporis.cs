namespace Yulinti.Nucleus {
    public interface IPulsabilis {
        void Pulsus();
    }

    // Ministeria蟆ら畑 / DeltaTime譖ｴ譁ｰ縺ｨ縺九・
    public interface IPulsabilisPrimum {
        void PulsusPrimum();
    }

    // Dux蟆ら畑
    public interface IPulsabilisPostRationem {
        void PulsusPostRationem();
    }

    public interface IPulsabilisFixus {
        void PulsusFixus();
    }

    // Ministeria蟆ら畑 / FixedDeltaTime譖ｴ譁ｰ縺ｨ縺九・
    public interface IPulsabilisFixusPrimum {
        void PulsusFixusPrimum();
    }

    public interface IPulsabilisTardus {
        void PulsusTardus();
    }
}
