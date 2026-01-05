using System.Numerics;

namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiumPuellaeResVisaeLegibile {
        bool EstActivumCapitis();
        bool EstActivumPectoris();
        bool EstActivumNatium();
        bool ConareLegoCapitis(IDPuellaeResVisaeCapitis idCapitis, out Vector3 positionem);
        bool ConareLegoPectoris(IDPuellaeResVisaePectoris idPectoris, out Vector3 positionem);
        bool ConareLegoNatium(IDPuellaeResVisaeNatium idNatium, out Vector3 positionem);
        Vector3 LegoPositionemRadix();
    }
}

