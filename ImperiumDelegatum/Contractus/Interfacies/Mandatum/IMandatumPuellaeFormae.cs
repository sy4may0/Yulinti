namespace Yulinti.ImperiumDelegatum.Contractus {
    // SenatusからExercitusのOrdinatioを発行するためのポート
    public interface IMandatumPuellaeFormae {
        void PostulareFormae(
            IDPuellaeFormae idFormae,
            float ratioDesiderata
        );
    }
}