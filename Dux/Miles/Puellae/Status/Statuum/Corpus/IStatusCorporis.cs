using Yulinti.Dux.ContructusDucis;
using Yulinti.Dux.Miles.Puellae.Interna;

namespace Yulinti.Dux.Miles.Puellae.Status {
    public interface IStatusCorporis {
        public IDStatus Id { get; }
        public void Intrare(IResFuluidaMotusLegibile resFuluidaMotus);
        public void Exire(IResFuluidaMotusLegibile resFuluidaMotus);
        public OrdinatioMotus Ordinare(IResFuluidaMotusLegibile resFuluidaMotus);
        public IDStatus MutareStatum(IResFuluidaMotusLegibile resFuluidaMotus);
    }
}
