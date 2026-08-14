namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOperatioCivisGenerationis {
        void ExecutareManifestatio(int idCivis, IDCivisPersonae idCivisPersonae);
        void ExecutareIncarnare(int idCivis);
        void ExecutareSpirituare(int idCivis);
        void ExecutareDeleto(int idCivis);
    }
}