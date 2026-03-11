using Yulinti.ImperiumDelegatum.Contractus;

// SpectaculumのIDから次のStatusCorporisIDを決定する。
namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal static class CondicioPuellaeSpectaculi {
        public static IDPuellaeStatusCorporis ResolvereSpectaculum(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            // 一応安全のため、Quietesをデフォルトとする。
            // Nihilが返るとSpectaculumIncipalisから帰ってこれなくなる。
            if (resFluida.Spectaculum.IdSpectaculiCorporis == IDPuellaeSpectaculiCorporis.Nihil) {
                return IDPuellaeStatusCorporis.Quies;
            }

            if (resFluida.Spectaculum.IdSpectaculiCorporis == IDPuellaeSpectaculiCorporis.Formosa01) {
                return IDPuellaeStatusCorporis.SpectaculumFormosa01;
            }

            return IDPuellaeStatusCorporis.Quies;
        }

        public static bool EstSpectaculumCorporis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            // 選択されたSpectaculumがあるかどうか。
            return resFluida.Spectaculum.IdSpectaculiCorporis != IDPuellaeSpectaculiCorporis.Nihil;
        }
    }
}