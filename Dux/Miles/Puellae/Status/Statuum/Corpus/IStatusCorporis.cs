using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.Miles;

namespace Yulinti.Dux.Miles {
    internal interface IStatusCorporis {
        public IDStatus Id { get; }
        public IDPuellaeAnimationisCorporis IdAnimationis { get; }
        public void Intrare(IResFuluidaMotusLegibile resFuluidaMotus);
        public void Exire(IResFuluidaMotusLegibile resFuluidaMotus);
        public OrdinatioMotus Ordinare(IResFuluidaMotusLegibile resFuluidaMotus);
        public IDStatus MutareStatum(IResFuluidaMotusLegibile resFuluidaMotus);
    }
}
