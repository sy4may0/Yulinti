using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class CenturioCivis : ICenturio, ICenturioPulsabilis, ICenturioPulsabilisTardus {
        private readonly MilesCivisVeletudinis _milesCivisVeletudinis;
        private readonly MilesCivisActionis _milesCivisActionis;

        // ResFluida実体
        private readonly ResFluidaCivisMotus _resFluidaMotus;
        private readonly ResFluidaCivisVeletudinis _resFluidaVeletudinis;

        // ResFluidaファサード
        private readonly IResFluidaCivisLegibile _resFluidaLegibile;

        // VContainer注入
        public CenturioCivis(
            MilesCivisVeletudinis milesCivisVeletudinis,
            MilesCivisActionis milesCivisActionis,
            ResFluidaCivisMotus resFluidaMotus,
            ResFluidaCivisVeletudinis resFluidaVeletudinis,
            IResFluidaCivisLegibile resFluidaLegibile
        ) {
            _milesCivisVeletudinis = milesCivisVeletudinis;
            _resFluidaMotus = resFluidaMotus;
            _resFluidaVeletudinis = resFluidaVeletudinis;
            _resFluidaLegibile = resFluidaLegibile;
        }

        public void Pulsus() {
            // Veletudoキャッシュを初期化
            _milesCivisVeletudinis.InitarePhantasma(_resFluidaVeletudinis);
            // Dominate
            _milesCivisVeletudinis.RenovereDomina(_resFluidaVeletudinis);
        }

        public void PulsusTardus() {
            // VeletudoキャッシュをResFluidaに反映
            _milesCivisVeletudinis.Applicare(_resFluidaVeletudinis);
        }
    }
}