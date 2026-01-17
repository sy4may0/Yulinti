using Yulinti.Dux.ContractusDucis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorPuellaeRamorumCorporis { 
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly IRamusPuellaeCorporis[] _rami;
        // キー: IDPuellaeStatusCorporisActualis
        // 値: ジャグ配列 [Prioritas順のインデックス][同一Prioritasを持つRamus配列]
        private readonly Dictionary<IDPuellaeStatusCorporis, IRamusPuellaeCorporis[][]> _tabula;
        private readonly Random _random;

        public ResolutorPuellaeRamorumCorporis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _contextusOstiorum = contextusOstiorum;
            _random = new Random();

            _rami = new IRamusPuellaeCorporis[] {
                new RamusPuellaeCorporisAmbulatioAdCursus(),
                new RamusPuellaeCorporisAmbulatioAdIncumboAmbulationem(),
                new RamusPuellaeCorporisAmbulatioAdQuies(),
                new RamusPuellaeCorporisCursusAdAmbulatio(),
                new RamusPuellaeCorporisIncumboAdIncumboAmbulationem(),
                new RamusPuellaeCorporisIncumboAdQuies(),
                new RamusPuellaeCorporisIncumboAmbulationemAdAmbulatio(),
                new RamusPuellaeCorporisIncumboAmbulationemAdIncumbo(),
                new RamusPuellaeCorporisQuiesAdAmbulatio(),
                new RamusPuellaeCorporisQuiesAdIncumbo(),
            };

            _tabula = new Dictionary<IDPuellaeStatusCorporis, IRamusPuellaeCorporis[][]>();
            
            // 各StatusCorporisごとにRamusをグループ化
            foreach (IDPuellaeStatusCorporis status in Enum.GetValues(typeof(IDPuellaeStatusCorporis))) {
                if (status == IDPuellaeStatusCorporis.None) continue;
                
                // 該当するStatusActualisのRamusを抽出し、Prioritasでグループ化
                var ramiPG = _rami
                    .Where(r => r.IdStatusActualis == status)
                    .GroupBy(r => r.Prioritas)
                    .OrderBy(g => g.Key)  // Prioritas昇順
                    .Select(g => g.ToArray())  // 各グループを配列に変換
                    .ToArray();
                
                if (ramiPG.Length > 0) {
                    _tabula[status] =ramiPG;
                }
            }
        }

        // 次の状態を決定する
        // IDPuellaeStatusCorporisActualisに対応するRamusから、Prioritas順に条件をチェックし、最初にマッチしたものを返す
        // マッチしない場合はNoneを返す
        public IDPuellaeStatusCorporis Resolvere(
            IDPuellaeStatusCorporis idStatusActualis,
            IResFluidaPuellaeLegibile resFluida
        ) {
            // 該当するStatusActualisのテーブルが存在しない場合はNoneを返す
            if (!_tabula.ContainsKey(idStatusActualis)) {
                return IDPuellaeStatusCorporis.None;
            }

            // Prioritas順（外側のループ）→同一Prioritas内（内側のループ）の順で条件をチェック
            foreach (var ramiPG in _tabula[idStatusActualis]) {
                IDPuellaeStatusCorporis idStatusProximus = selegereCaecus(
                    ramiPG,
                    resFluida
                );
                if (idStatusProximus != IDPuellaeStatusCorporis.None) {
                    return idStatusProximus;
                }
            }

            return IDPuellaeStatusCorporis.None;
        }

        // ランダムにRamusを選択する
        private IDPuellaeStatusCorporis selegereCaecus(
            IRamusPuellaeCorporis[] rami,
            IResFluidaPuellaeLegibile resFluida
        ) {
            IRamusPuellaeCorporis selecta = null;
            int summa = 0;

            foreach (var ramus in rami) {
                if (!ramus.Condicio(_contextusOstiorum, resFluida)) {
                    continue;
                }

                summa++;

                if (_random.Next(0, summa) == 0) {
                    selecta = ramus;
                }
            }
            if (selecta == null) {
                return IDPuellaeStatusCorporis.None;
            }
            return selecta.IdStatusProximus;
        }
    }
}