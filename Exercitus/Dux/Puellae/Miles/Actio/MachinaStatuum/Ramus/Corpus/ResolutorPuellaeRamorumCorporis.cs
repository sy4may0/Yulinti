using Yulinti.Exercitus.Contractus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Exercitus.Dux {
    internal sealed class ResolutorPuellaeRamorumCorporis { 
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly IRamusPuellaeCorporis[] _rami;
        // キー: IDPuellaeStatusCorporisActualis
        // 値: ジャグ配列[Prioritas順のインデックス][同一Prioritasを持つRamus配列]
        private readonly Dictionary<IDPuellaeStatusCorporis, IRamusPuellaeCorporis[][]> _tabula;
        private readonly Random _random;

        // !!!!!! LINQを使ってぁ !!!!!!!!!!
        // Updateループでは呼ぶな
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
                if (status == IDPuellaeStatusCorporis.Nihil) continue;
                
                // 該当するStatusActualisのRamusを抽出しPrioritasでグループ化
                var ramiPG = _rami
                    .Where(r => r.IdStatusActualis == status)
                    .GroupBy(r => r.Prioritas)
                    .OrderBy(g => g.Key)  // Prioritas順
                    .Select(g => g.ToArray())  // ループを配列に変換
                    .ToArray();
                
                if (ramiPG.Length > 0) {
                    _tabula[status] =ramiPG;
                }
            }
        }

        // 次の状態を決定する
        // IDPuellaeStatusCorporisActualisに対応するRamusからPrioritas順の条件をチェックし最初にマッチしたものを返す
        // マッチしない場合はNihilを返す
        public IDPuellaeStatusCorporis Resolvere(
            IDPuellaeStatusCorporis idStatusActualis,
            IResFluidaPuellaeLegibile resFluida
        ) {
            // 該当するStatusActualisのテーブルが存在しない場合はNihilを返す
            if (!_tabula.ContainsKey(idStatusActualis)) {
                return IDPuellaeStatusCorporis.Nihil;
            }

            // Prioritas順の外側のループ（同一Prioritas内のループ）条件をチェック
            foreach (var ramiPG in _tabula[idStatusActualis]) {
                IDPuellaeStatusCorporis idStatusProximus = selegereCaecus(
                    ramiPG,
                    resFluida
                );
                if (idStatusProximus != IDPuellaeStatusCorporis.Nihil) {
                    return idStatusProximus;
                }
            }

            return IDPuellaeStatusCorporis.Nihil;
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
                return IDPuellaeStatusCorporis.Nihil;
            }
            return selecta.IdStatusProximus;
        }
    }
}
