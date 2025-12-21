using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    public interface IMilesPuellaeActionis {
        void Opero();
        void RenovareFluidaMotus();
        IDPuellaeStatusCorporis StatusCorporisActualis { get; }
    }
}