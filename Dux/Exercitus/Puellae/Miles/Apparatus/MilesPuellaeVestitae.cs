using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeVestitae {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;

        public MilesPuellaeVestitae(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _contextusOstiorum = contextusOstiorum;
        }

        public void Initare() {
            // 何もしない。
            _contextusOstiorum.Carrus.PostulareVeletudinisNudi(
                false,
                false
            );
        }

        public void Ordinare(IResFluidaPuellaeLegibile resFluida) {
            // ここで服装に伴うVeletudinisを適用する。
            // - Claritas
            // - EstNudusAnterior
            // - EstNudusPosterior

            // 服装システムは未作成のため、現状はClalitas+0.25, 前面露出状態とする。
            _contextusOstiorum.Carrus.PostulareVeletudinisNudi(
                estNudusAnterior: true,
                estNudusPosterior: false
            );
            _contextusOstiorum.Carrus.PostulareVeletudinis(
                dtClaritas: 0.25f
            );
        }
    }
}