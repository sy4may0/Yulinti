using Yulinti.ImperiumDelegatum.Contractus;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using Yulinti.Thesaurus;
using UnityEngine;
using System;


namespace Yulinti.Officia.Turris {
    internal sealed class TurrisSalsamenti : ITurrisSalsamenti, ITurrisSalsamentiLegibile {
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

        public async Task<int> LongitudoManualis(CancellationToken ct = default) {
            return await _luditorDataServanda.LongitudoManualis(ct);
        }

        public int LongitudoManualisMaxima { get; } = ConstansTurris.LongitudoDataServanda;

        public async Task<int> LongitudoAutomaticus(CancellationToken ct = default) {
            return await _luditorDataServanda.LongitudoAutomaticus(ct);
        }

        public int LongitudoAutomaticusMaxima { get; } = ConstansTurris.LongitudoDataServandaAutomaticus;

        public async Task<bool> EstNovissimus(CancellationToken ct = default) {
            return await _luditorDataServanda.EstNovissimus(ct);
        }

        // P1 Notitiaの全取得
        public async Task<IReadOnlyList<IOstiumSalsamentiNotitiae>> ArcessereNotitiamManualem(CancellationToken ct = default) {
            PurgareNotitiaManualis();

            IReadOnlyList<Guid> idManualis = await _luditorDataServanda.TabulaManualis(ct);
            int i = 0;
            foreach (Guid id in idManualis) {
                // 最大数以上はロードしない。
                if (i >= LongitudoManualisMaxima) break;
                IDataNotitia<SalsamentumNotitiaeDto> notitia = await _luditorDataServanda.ArcessereNotitiam(id, ct);
                if (notitia == null) continue;
                // Renovareはキャストが必要。
                if (i >= _notitiaManualis.Count) _notitiaManualis.Add(new OstiumSalsamentiNotitiae());
                ((OstiumSalsamentiNotitiae)_notitiaManualis[i]).Renovare(id, notitia.Timestamp, notitia.Notitia);
                i++;
            }

            // 削除分を処理する。
            if (_notitiaManualis.Count > i) {
                _notitiaManualis.RemoveRange(i, _notitiaManualis.Count - i);
            }

            return _notitiaManualis;
        }

        // P1 Notitiaの全取得(Automaticus)
        public async Task<IReadOnlyList<IOstiumSalsamentiNotitiae>> ArcessereNotitiamAutomaticam(CancellationToken ct = default) {
            PurgareNotitiaAutomaticus();

            IReadOnlyList<Guid> idAutomaticus = await _luditorDataServanda.TabulaAutomaticus(ct);
            int i = 0;
            foreach (Guid id in idAutomaticus) {
                // 最大数以上はロードしない。
                if (i >= LongitudoAutomaticusMaxima) break;
                IDataNotitia<SalsamentumNotitiaeDto> notitia = await _luditorDataServanda.ArcessereNotitiam(id, ct);
                if (notitia == null) continue;
                // Renovareはキャストが必要。
                if (i >= _notitiaAutomaticus.Count) _notitiaAutomaticus.Add(new OstiumSalsamentiNotitiae());
                ((OstiumSalsamentiNotitiae)_notitiaAutomaticus[i]).Renovare(id, notitia.Timestamp, notitia.Notitia);
                i++;
            }

            // 削除分を処理する。
            if (_notitiaAutomaticus.Count > i) {
                _notitiaAutomaticus.RemoveRange(i, _notitiaAutomaticus.Count - i);
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
        public async Task<Guid> ArcessereNovissimus(CancellationToken ct = default) {
            Guid? id = await _luditorDataServanda.LegoNovissimus(ct);
            if (id == null) throw new Exception("No Save Data");
            await Arcessere(id.Value, ct);
            return id.Value;
        }

        // P5 セーブデータをセーブ。
        public async Task<Guid> Servare(
            Guid id,
            IPhantasmaPuellaePersonae phantasmaPuellaePersonae,
            CancellationToken ct = default
        ) {
            _ostiumSalsamentiActualis.Renovare(id, phantasmaPuellaePersonae);
            _ostiumSalsamentiNotitiaeActualis.Renovare(id, phantasmaPuellaePersonae);
            Guid idServanda = await _luditorDataServanda.Servare(
                id,
                _ostiumSalsamentiNotitiaeActualis.SalsamentumNotitiaeDto,
                _ostiumSalsamentiActualis.SalsamentumDto,
                ct
            );

            return idServanda;
        }

        // P5-ex オートセーブデータをセーブ。
        public async Task<Guid> ServareAutomaticus(
            IPhantasmaPuellaePersonae phantasmaPuellaePersonae,
            CancellationToken ct = default
        ) {
            // この時点でidは取れていない。
            _ostiumSalsamentiActualis.Renovare(_ostiumSalsamentiActualis.Id, phantasmaPuellaePersonae);
            _ostiumSalsamentiNotitiaeActualis.Renovare(_ostiumSalsamentiNotitiaeActualis.Id, phantasmaPuellaePersonae);
            Guid idServanda = await _luditorDataServanda.CreareAutomaticus(
                _ostiumSalsamentiNotitiaeActualis.SalsamentumNotitiaeDto,
                _ostiumSalsamentiActualis.SalsamentumDto,
                ct
            );
            // この時点でidは取れている。
            _ostiumSalsamentiActualis.Renovare(idServanda, phantasmaPuellaePersonae);
            _ostiumSalsamentiNotitiaeActualis.Renovare(idServanda, phantasmaPuellaePersonae);

            return idServanda;
        }

        public IOstiumSalsamenti Actualis => _ostiumSalsamentiActualis;

        /// <summary> セーブデータが存在するかどうかを確認する。 </summary>
        /// <param name="actualis">セーブデータ</param>
        /// <returns>セーブデータが存在するかどうか</returns>
        /// <remarks>セーブデータが存在しない場合はデフォルトセーブデータを返す。</remarks>
        public bool ConareActualis(out IOstiumSalsamenti actualis) {
            if (_ostiumSalsamentiActualis.EstActivum) {
                actualis = _ostiumSalsamentiActualis;
                return true;
            }
            actualis = _ostiumSalsamentiActualis;
            return false;
        }
    }
}
