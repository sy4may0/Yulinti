namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumPortus {
        // タイトルUIを表示
        void DemitterePortus();
        // タイトルUIを非表示
        void TollerePortus();

        void ActivareUsus(UsusPortus usus);
        void DeactivareUsus(UsusPortus usus);
    }
}
