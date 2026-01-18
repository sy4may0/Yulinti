using System.Numerics;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeResVisaeLegibile {
        bool EstActivumCapitis();
        bool EstActivumPectoris();
        bool EstActivumNatium();
        bool EstActivumNudusAnterior();
        bool EstActivumNudusPosterior();
        bool ConareLegoCapitis(IDPuellaeResVisaeCapitis idCapitis, out Vector3 positionem);
        bool ConareLegoPectoris(IDPuellaeResVisaePectoris idPectoris, out Vector3 positionem);
        bool ConareLegoNatium(IDPuellaeResVisaeNatium idNatium, out Vector3 positionem);
        bool ConareLegoNudusAnterior(IDPuellaeResNudusAnterior idNudusAnterior, out Vector3 positionem);
        bool ConareLegoNudusPosterior(IDPuellaeResNudusPosterior idNudusPosterior, out Vector3 positionem);
        bool ConareLegoNudusAnteriorDirectio(IDPuellaeResNudusAnterior idNudusAnterior, out Vector3 directio);
        bool ConareLegoNudusPosteriorDirectio(IDPuellaeResNudusPosterior idNudusPosterior, out Vector3 directio);
        Vector3 LegoPositionemRadix();
    }
}

