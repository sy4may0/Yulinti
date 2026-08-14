namespace Yulinti.Officia.Contractus {
    public interface ILacusAnchorarumCivisLegibile {
        int Longitudo { get; }
        bool ConareLego(int idCivis, out IAnchoraCivis anchora);
        bool EstEns(int idCivis);
        bool EstActivum(int idCivis);
    }
}