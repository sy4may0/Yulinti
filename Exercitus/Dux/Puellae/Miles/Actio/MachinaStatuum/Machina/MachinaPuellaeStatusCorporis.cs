using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

// フレームのお話。
// Mutare系を呼ぶと現在ステートのIntrare/ExireおよびIntrare終了時のアニメーション遷移が呼ばれる。
// このフレームではAnimancerの再生リクエストが飛ぶ。ExecutorはMilesの後に処理されるから、
// ExcercitusフェーズTickではアニメーションが開始状態にならない。
// 次のMutareではアニメーション開始状態になる。
// ここが要注意ポイントで、Intrareとか1段目で遷移を呼んだら、そのあと次の1段目を再実行しない。
// そんでもってMutareXXXの二段目では、LusorAnimationisの状態を見ない。
// Ordinare自体は遷移後に呼んでいいと思う。多分。

namespace Yulinti.Exercitus.Dux {
    internal enum PhasisMachinaPuellaeStatusCorporis {
        // 初期位置
        Incipalis,
        // 開始アニメーション再生中
        Intrans,
        // アニメーション再生中
        Transeo,
        // 無アニメーション再生中(これはLusorがアニメーション無しを返すため少し状態が違う
        TranseoDesinere,
        // 終了アニメーション再生中
        Exiens
    }

    internal sealed class MachinaPuellaeStatusCorporis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly TabulaPuellaeStatuum _tabulaPuellaeStatuum;
        private readonly IConfiguratioPuellaeStatuum _configuratioStatuum;

        private PhasisMachinaPuellaeStatusCorporis _phasisActualis;

        private IDPuellaeStatusCorporis _idStatusActualis;
        private IDPuellaeStatusCorporis _idStatusProximus;

        public MachinaPuellaeStatusCorporis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IConfiguratioPuellaeStatuum configuratioStatuum
        ) {
            _contextusOstiorum = contextusOstiorum;
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Incipalis;
            _idStatusActualis = IDPuellaeStatusCorporis.Nihil;
            _idStatusProximus = IDPuellaeStatusCorporis.Nihil;

            _configuratioStatuum = configuratioStatuum;
            _tabulaPuellaeStatuum = new TabulaPuellaeStatuum(_configuratioStatuum);
        }

        private void Incipere(
            IResFluidaPuellaeLegibile resFluida
        ) {
            // 次ステートがある場合、それにMutareIntrans。
            if (_idStatusProximus != IDPuellaeStatusCorporis.Nihil) {
                MutareIntrans(resFluida);
            }

            // 次ステートが無く、現在ステートがある場合、現在ステートがある場合、
            // 次ステートを現在ステートのProximusAutomaticusに設定してMutareIntrans。
            else if (_idStatusActualis != IDPuellaeStatusCorporis.Nihil) {
                IStatusPuellaeCorporis sa = _tabulaPuellaeStatuum.Legere(_idStatusActualis);
                // ステート未定義時は設定の初期ステートに遷移する。
                if (sa == null) {
                    Notarius.Memorare(LogTextus.MachinaPuellaeStatusCorporis_MACHINAPUELLAESTATUSCORPORIS_STATUS_NOT_FOUND);
                    _idStatusProximus = _configuratioStatuum.IDStatusCorporisIncipalis;
                } else {
                    _idStatusProximus = sa.IdStatusProximusAutomaticus;
                }
                MutareIntrans(resFluida);
            }

            // 次ステートも現在ステートもない(起動直後)は設定の初期ステートに遷移する。
            else {
                _idStatusProximus = _configuratioStatuum.IDStatusCorporisIncipalis;
                MutareIntrans(resFluida);
            }
        }

        // Intrans フェーズで毎フレーム（またはアニメーションイベント時）に評価する想定。
        // 判定には「アニメーション再生中か終了か」が必要（要: Contextus/Lusor 等からの取得）。
        private void Intrare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            // ステート遷移条件（Interdicta は現在ステート _idStatusActualis のもの）
            //
            // 1. _idStatusProximus が Nihil + アニメーション再生中
            //    -> 遷移なし
            //
            // 2. _idStatusProximus が Nihil ではない + アニメーション再生中
            //   [EstInterdictaIntrare:False + EstInterdictaTransere:False + EstInterdictaExire:False]
            //   -> 即時 Incipalis に移動し Incipere を呼ぶ（状態切り替え）。
            //   [EstInterdictaIntrare:False + EstInterdictaTransere:True]
            //   -> 即時 Transeo に移動（_idStatusProximus は保持、後で Incipalis 戻り時に Incipere で処理）。
            //   [EstInterdictaIntrare:False + EstInterdictaExire:True]
            //   -> 即時 Exiens に移動（同様に statusProximus は後で処理）。
            //   [EstInterdictaIntrare:True]
            //   -> 遷移しない。
            //   ※ Transere と Exire が両方 True の場合は優先度を決める（例: Transere 優先）。
            //
            // 3. アニメーション再生終了 + _idStatusProximus が Nihil ではない
            //   [EstInterdictaTransere:False + EstInterdictaExire:False]
            //   -> 即時 Incipalis に移動し Incipere を呼ぶ。
            //   [EstInterdictaTransere:True]
            //   -> 即時 Transeo に移動。
            //   [EstInterdictaExire:True]
            //   -> 即時 Exiens に移動。
            //   ※ 同上、両方 True のときの優先度を定義すること。
            //
            // 4. アニメーション再生終了 + _idStatusProximus が Nihil
            //    -> Transeo に移動（IdAnimationisTransere に応じて MutareTranseo / MutareTranseoDesinere のいずれか）
        }

        // ステートを切り替えて、Intrareを実行する。
        // 重要: _idStatusActualisを変えれるのはここだけな。
        private void MutareIntrans(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _idStatusActualis = _idStatusProximus;
            _idStatusProximus = IDPuellaeStatusCorporis.Nihil;
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Intrans;

            // ステートのIntrareを実行。
            IStatusPuellaeCorporis sa = _tabulaPuellaeStatuum.Legere(_idStatusActualis);
            // ステートが無い場合は全部初期化してIncipalisに戻す。
            if (sa == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            sa.Intrare(_contextusOstiorum, resFluida);

            // AnimationisIntrareがNihilなら、即時MutareTranseo。
            // それ以外ならIntransフェーズに入る。
            if (sa.IdAnimationisIntrare == IDPuellaeAnimationis.Nihil ||
                sa.IdAnimationisIntrare == IDPuellaeAnimationis.Desinere
            ) {
                if (sa.IdAnimationisIntrare == IDPuellaeAnimationis.Desinere) {
                    MutareTranseoDesinere(resFluida);
                } else {
                    MutareTranseo(resFluida);
                }
            } 
        }

        private void MutareTranseo(
            IResFluidaPuellaeLegibile resFluida
        ) {
            //　ここでステートは変化しない。
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Transeo;

            // ステートのTransereを実行。
            IStatusPuellaeCorporis sa = _tabulaPuellaeStatuum.Legere(_idStatusActualis);
            // ステートが無い場合は全部初期化してIncipalisに戻す。
            if (sa == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            sa.Transere(_contextusOstiorum, resFluida);

            // AnimationisTransereがNihilなら、即時MutareExiens。
            // それ以外ならTranseoフェーズに入る。
            if (sa.IdAnimationisTransere == IDPuellaeAnimationis.Nihil ||
                sa.IdAnimationisTransere == IDPuellaeAnimationis.Desinere
            ) {
                if (sa.IdAnimationisTransere == IDPuellaeAnimationis.Desinere) {
                    MutareExiens(resFluida);
                }
            }
        }

        private void MutareTranseoDesinere(
            IResFluidaPuellaeLegibile resFluida
        ) {
            // ここでステートは変化しない。
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.TranseoDesinere;

            // ステートのTransereを実行。
            IStatusPuellaeCorporis sa = _tabulaPuellaeStatuum.Legere(_idStatusActualis);
            // ステートが無い場合は全部初期化してIncipalisに戻す。
            if (sa == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            sa.Transere(_contextusOstiorum, resFluida);

            // AnimationisTransereがNihilなら、即時MutareExiens。
            // TransereDsinereはDesinereループ可能。
            // それ以外ならTranseoフェーズに入る。
            if (sa.IdAnimationisTransere == IDPuellaeAnimationis.Nihil) {
                MutareExiens(resFluida);
            }
        }

        private void MutareExiens(
            IResFluidaPuellaeLegibile resFluida
        ) {
            // ここでステートは変化しない。
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Exiens;

            // ステートのExireを実行。
            IStatusPuellaeCorporis sa = _tabulaPuellaeStatuum.Legere(_idStatusActualis);
            // ステートが無い場合は全部初期化してIncipalisに戻す。
            if (sa == null) {
                MutareIncipalisCumPurgere();
                return;
            }

            sa.Exire(_contextusOstiorum, resFluida);

            // AnimationisExireがNihilなら、即時MutareIncipalis。
            // それ以外ならExiensフェーズに入る。
            if (sa.IdAnimationisExire == IDPuellaeAnimationis.Nihil ||
                sa.IdAnimationisExire == IDPuellaeAnimationis.Desinere
            ) {
                MutareIncipalis(resFluida);
            }
        }

        private void MutareIncipalis(
            IResFluidaPuellaeLegibile resFluida
        ) {
            // ここは何も考えずIncipalisに移動する。
            // この時点でアニメーション再生はない。
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Incipalis;
        }

        // エラー起きた時とかに使う。全部初期化して戻す。
        private void MutareIncipalisCumPurgere() {
            _idStatusActualis = IDPuellaeStatusCorporis.Nihil;
            _idStatusProximus = IDPuellaeStatusCorporis.Nihil;
            _phasisActualis = PhasisMachinaPuellaeStatusCorporis.Incipalis;
        }

    }
}
