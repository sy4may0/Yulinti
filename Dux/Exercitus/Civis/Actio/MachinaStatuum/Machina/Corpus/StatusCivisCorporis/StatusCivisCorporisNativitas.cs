using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    // 初回セットする特殊ステート。何もしない。
    // 遷移テーブルで即時MigrareAditoriumに遷移する。
    // なんか初期化処理とかやるならここ。
    internal sealed class StatusCivisCorporisNativitas : IStatusCivisCorporis {
        public IDCivisStatusCorporis Id => IDCivisStatusCorporis.Nativitas;
        public IDCivisAnimationisContinuata IdAnimationisIntrare => IDCivisAnimationisContinuata.None;
        public IDCivisAnimationisContinuata IdAnimationisExire => IDCivisAnimationisContinuata.None;

        public OrdinatioCivisAnimationis Intrare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adInitium
        ) {
            return new OrdinatioCivisAnimationis(
                idCivis, false, IdAnimationisIntrare, null, null
            );
        }

        public OrdinatioCivisAnimationis Exire(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adFinem
        ) {
            return new OrdinatioCivisAnimationis(
                idCivis, false, IdAnimationisExire, null, null
            );
        }

        public OrdinatioCivisActionis OrdinareActionis(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            return OrdinatioCivisActionis.Nihil(idCivis);
        }

        public OrdinatioCivisVeletudinis OrdinareVeletudinis(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida
        ) {
            return new OrdinatioCivisVeletudinis(idCivis, 0f);
        }
    }
}