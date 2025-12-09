using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    public sealed class CenturioPuellae : ICenturio, ICenturioPulsabilis, ICenturioPulsabilisTardus {
        private readonly IMilesPuellaeActionis _milesPuellaeActionis;
        private readonly IMilesPuellaeActionisSecundarius _milesPuellaeActionisSecundarius;
        private readonly IMilesPuellaeFigurae _milesPuellaeFigurae;
        private readonly IMilesPuellaeCrinis _milesPuellaeCrinis;

        // VContainer注入
        public CenturioPuellae(
            IMilesPuellaeActionis milesPuellaeActionis,
            IMilesPuellaeActionisSecundarius milesPuellaeActionisSecundarius,
            IMilesPuellaeFigurae milesPuellaeFigurae,
            IMilesPuellaeCrinis milesPuellaeCrinis
        ) {
            _milesPuellaeActionis = milesPuellaeActionis;
            _milesPuellaeActionisSecundarius = milesPuellaeActionisSecundarius;
            _milesPuellaeFigurae = milesPuellaeFigurae;
            _milesPuellaeCrinis = milesPuellaeCrinis;
        }

        public void Pulsus() {
            // ステート更新/アクション実行
            _milesPuellaeActionis.Opero();
            // Runtime更新/Animation速度流し込み
            _milesPuellaeActionis.RenovareFluidaMotus();
        }

        public void PulsusTardus() {
            // 強制地面補正(root移動)
            _milesPuellaeActionisSecundarius.ElevoPelvimSequensTerra();
            // BlendShape適用
            _milesPuellaeFigurae.ApplicareFiguram();
        }

    }
}
