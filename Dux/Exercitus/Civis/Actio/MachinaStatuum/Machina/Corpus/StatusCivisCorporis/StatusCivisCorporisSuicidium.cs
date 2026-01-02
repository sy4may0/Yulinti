using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class StatusCivisCorporisSuicidium : IStatusCivisCorporis {
        public IDCivisStatusCorporis Id => IDCivisStatusCorporis.Suicidium;
        public IDCivisAnimationisContinuata IdAnimationisIntrare => IDCivisAnimationisContinuata.NihilCorporis;
        public IDCivisAnimationisContinuata IdAnimationisExire => IDCivisAnimationisContinuata.NihilCorporis;

        public OrdinatioCivisAnimationis Intrare(
            int idCivis,
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IResFluidaCivisLegibile resFluida,
            Action adInitium
        ) {
            // NihilCorporisでアニメーションを初期化。
            return new OrdinatioCivisAnimationis(
                idCivis, true, IdAnimationisIntrare, null, null
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
            // 削除フラグを立ててVeletudo要請
            return new OrdinatioCivisVeletudinis(idCivis, 0f, estSpirituare: true);
        }
    }
}