namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumCivisLegibile {
        int ID { get; }
        bool EstActivum { get; }
        IOstiumCivisLociLegibile Loci { get; }
    }
}