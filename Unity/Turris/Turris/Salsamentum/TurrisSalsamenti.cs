using Yulinti.Exercitus.Contractus;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using Yulinti.Thesaurus;
using UnityEngine;
using System;


namespace Yulinti.Unity.Turris {
    internal sealed class TurrisSalsamenti : ITurrisSalsamenti {
        private readonly ILuditorDataServanda<SalsamentumNotitiaeDto, SalsamentumDto> _luditorDataServanda;
        private readonly OstiumSalsamenti _ostiumSalsamentiActualis;
        private readonly OstiumSalsamentiNotitiae _ostiumSalsamentiNotitiaeActualis;

        // キャッシュ。
        private List<IOstiumSalsamentiNotitiae> _notitiaManualis = new List<IOstiumSalsamentiNotitiae>();
        private List<IOstiumSalsamentiNotitiae> _notitiaAutomaticus = new List<IOstiumSalsamentiNotitiae>();

        public TurrisSalsamenti() {
            _ostiumSalsamentiActualis = new OstiumSalsamenti();
            _ostiumSalsamentiNotitiaeActualis = new OstiumSalsamentiNotitiae();

            string dirPath = Path.Combine(Application.persistentDataPath, ConstansTurris.DirPathSalsamentum);
            _luditorDataServanda = FabricaLuditorDataServanda.Creare<SalsamentumNotitiaeDto, SalsamentumDto>(
                dirPath,
                ConstansTurris.LongitudoDataServandaAutomaticus,
                ConstansTurris.TempusPraeteriitSec
            );

            // キャッシュを構成。
            _notitiaManualis = new List<IOstiumSalsamentiNotitiae>(ConstansTurris.LongitudoDataServanda);
            _notitiaAutomaticus = new List<IOstiumSalsamentiNotitiae>(ConstansTurris.LongitudoDataServandaAutomaticus);
        }

        private void PurgareNotitiaManualis() {
            foreach (IOstiumSalsamentiNotitiae notitia in _notitiaManualis) {
                // Purgareはキャストが必要。
                ((OstiumSalsamentiNotitiae)notitia).Purgare();
            }
        }

        private void PurgareNotitiaAutomaticus() {
            foreach (IOstiumSalsamentiNotitiae notitia in _notitiaAutomaticus) {
                // Purgareはキャストが必要。
                ((OstiumSalsamentiNotitiae)notitia).Purgare();
            }
        }

        // P1 Notitiaの全取得
        public async Task<IReadOnlyList<IOstiumSalsamentiNotitiae>> ArcessereNotitiamManualem(CancellationToken ct = default) {
            PurgareNotitiaManualis();

            IReadOnlyList<Guid> idManudalis = await _luditorDataServanda.TabulaManualis(ct);
            int i = 0;
            foreach (Guid id in idManudalis) {
                IDataNotitia<SalsamentumNotitiaeDto> notitia = await _luditorDataServanda.ArcessereNotitiam(id, ct);
                if (notitia == null) continue;
                // Renovareはキャストが必要。
                ((OstiumSalsamentiNotitiae)_notitiaManualis[i]).Renovare(id, notitia.Timestamp, notitia.Notitia);
                i++;
            }

            return _notitiaManualis;
        }

        // P1 Notitiaの全取得(Automaticus)
        public async Task<IReadOnlyList<IOstiumSalsamentiNotitiae>> ArcessereNotitiamAutomaticam(CancellationToken ct = default) {
            PurgareNotitiaAutomaticus();

            IReadOnlyList<Guid> idAutomaticus = await _luditorDataServanda.TabulaAutomaticus(ct);
            int i = 0;
            foreach (Guid id in idAutomaticus) {
                IDataNotitia<SalsamentumNotitiaeDto> notitia = await _luditorDataServanda.ArcessereNotitiam(id, ct);
                if (notitia == null) continue;
                // Renovareはキャストが必要。
                ((OstiumSalsamentiNotitiae)_notitiaAutomaticus[i]).Renovare(id, notitia.Timestamp, notitia.Notitia);
                i++;
            }
            return _notitiaAutomaticus;
        }

        // P2 Load セーブデータを取得してキャッシュ。
        public async Task Arcessere(Guid id, CancellationToken ct = default) {
            IDataNotitia<SalsamentumNotitiaeDto> notitia = await _luditorDataServanda.ArcessereNotitiam(id, ct);
            IDataServanda<SalsamentumDto> servanda = await _luditorDataServanda.Arcessere(id, ct);
            if (notitia == null) throw new Exception("No Notitia");
            if (servanda == null) throw new Exception("No Servanda");
            // Renovareはキャストが必要。
            ((OstiumSalsamentiNotitiae)_ostiumSalsamentiNotitiaeActualis).Renovare(id, notitia.Timestamp, notitia.Notitia);
            ((OstiumSalsamenti)_ostiumSalsamentiActualis).Renovare(id, servanda.Timestamp, servanda.Data);
        }

        /// <summary> P3 削除したらリロードしないとNotitiaは更新されないよ。 </summary>
        public async Task Deleto(Guid id, CancellationToken ct = default) {
            await _luditorDataServanda.Deleto(id, ct);
        }

        /// <summary> P2-Ex1 これを実行した時点で新セーブデータがロードされるよ。 </summary>
        public async Task<Guid> Creare(CancellationToken ct = default) {
            OstiumSalsamentiNotitiae notitia = new OstiumSalsamentiNotitiae();
            OstiumSalsamenti salsamenti = new OstiumSalsamenti();

            Guid id = await _luditorDataServanda.CreareManualis(
                notitia.SalsamentumNotitiaeDto,
                salsamenti.SalsamentumDto,
                ct
            );

            await Arcessere(id, ct);
            return id;
        }

        // P2-Ex2 最新セーブデータをロード
        public async Task ArcessereNovissimus(CancellationToken ct = default) {
            Guid? id = await _luditorDataServanda.LegoNovissimus(ct);
            if (id == null) throw new Exception("No Save Data");
            await Arcessere(id.Value, ct);
        }

        // Thesaurusに以下の改修を入れよう。
        // Longitudoを返すメソッド。
        // Novissimusがあるか返すメソッド。
    }
}