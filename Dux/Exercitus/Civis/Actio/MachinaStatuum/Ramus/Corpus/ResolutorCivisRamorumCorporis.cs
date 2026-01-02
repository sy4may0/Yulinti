using Yulinti.Dux.ContractusDucis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorCivisRamorumCorporis {
        private readonly ContextusCivisOstiorumLegibile _contextusOstiorum;
        private readonly IRamusCivisCorporis[] _rami;
        // キー: IDCivisStatusCorporisActualis
        // 値: ジャグ配列 [Prioritas順のインデックス][同一Prioritasを持つRamus配列]
        private readonly Dictionary<IDCivisStatusCorporis, IRamusCivisCorporis[][]> _tabula;
        private readonly Random _random;

        public ResolutorCivisRamorumCorporis(
            ContextusCivisOstiorumLegibile contextusOstiorum
        ) {
            _contextusOstiorum = contextusOstiorum;
            _random = new Random();

            _rami = new IRamusCivisCorporis[] {
                new RamusCivisCorporisNativitasAdMigrareAditorium(),
                new RamusCivisCorporisMigrareAditoriumAdMigrareAditorium(),
                new RamusCivisCorporisMigrareAditoriumAdMigrareCrematorium(),
                new RamusCivisCorporisMigrareCrematoriumAdSuicidium(),
            };

            _tabula = new Dictionary<IDCivisStatusCorporis, IRamusCivisCorporis[][]>();

            // 各StatusCorporisごとにRamusをグループ化
            foreach (IDCivisStatusCorporis status in Enum.GetValues(typeof(IDCivisStatusCorporis))) {
                if (status == IDCivisStatusCorporis.None) continue;

                // 該当するStatusActualisのRamusを抽出し、Prioritasでグループ化
                var ramiPG = _rami
                    .Where(r => r.IdStatusActualis == status)
                    .GroupBy(r => r.Prioritas)
                    .OrderBy(g => g.Key)  // Prioritas昇順
                    .Select(g => g.ToArray())  // 各グループを配列に変換
                    .ToArray();

                if (ramiPG.Length > 0) {
                    _tabula[status] = ramiPG;
                }
            }
        }

        // 次の状態を決定する
        // IDCivisStatusCorporisActualisに対応するRamusから、Prioritas順に条件をチェックし、最初にマッチしたものを返す
        // マッチしない場合はNoneを返す
        public IDCivisStatusCorporis Resolvere(
            IDCivisStatusCorporis idStatusActualis,
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            // 該当するStatusActualisのテーブルが存在しない場合はNoneを返す
            if (!_tabula.ContainsKey(idStatusActualis)) {
                return IDCivisStatusCorporis.None;
            }

            // Prioritas順（外側のループ）→同一Prioritas内（内側のループ）の順で条件をチェック
            foreach (var ramiPG in _tabula[idStatusActualis]) {
                IDCivisStatusCorporis idStatusProximus = selegereCaecus(
                    ramiPG,
                    idCivis,
                    resFluida
                );
                if (idStatusProximus != IDCivisStatusCorporis.None) {
                    return idStatusProximus;
                }
            }

            return IDCivisStatusCorporis.None;
        }

        // ランダムにRamusを選択する
        private IDCivisStatusCorporis selegereCaecus(
            IRamusCivisCorporis[] rami,
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            IRamusCivisCorporis selecta = null;
            int summa = 0;

            foreach (var ramus in rami) {
                if (!ramus.Condicio(idCivis, _contextusOstiorum, resFluida)) {
                    continue;
                }

                summa++;

                if (_random.Next(0, summa) == 0) {
                    selecta = ramus;
                }
            }
            if (selecta == null) {
                return IDCivisStatusCorporis.None;
            }
            return selecta.IdStatusProximus;
        }
    }
}
