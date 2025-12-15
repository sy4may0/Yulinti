using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    public interface IMilesPuellaeActionis {
        void Opero();
        void RenovareFluidaMotus();
        IDStatusCorporis StatusCorporisActualis { get; }
    }
}