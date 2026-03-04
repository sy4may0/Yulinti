namespace Yulinti.Exercitus.Contractus {
    // セーブ手順
    // p = turrisPhantasmaPuellaePersonae.Legere()
    // p.Normare()
    // turrisSalsamenti.Servare(p)
    // turrisPhantasmaPuellaePersonae.Initare(turrisSalsamentiLegibile.Actualis())
    public interface ITurrisPhantasmaPuellaePersonae {
        void Initare(IOstiumSalsamentiPuellae ostiumSalsamentiPuellae);
        void AddeAnimamGradus(IDGradusPuellaePersonae idGradusPuellaePersonae, int anima);
        void AddeAnimamSensus(IDSensusPuellaePersonae idSensusPuellaePersonae, int anima);
        IPhantasmaPuellaePersonae Legere();
    }
}