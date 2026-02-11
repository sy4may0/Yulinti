namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumSalsamenti {
        int IdDatumServatum { get; }
        int Versio { get; }
        long Revisio { get; }
        string Dies { get; }
        IOstiumSalsamentiPuellaePersonae PuellaePersonae { get; }
    }
}