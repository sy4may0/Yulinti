using Yulinti.Dux.ContractusDucis;
using UnityEngine;
using System;
using System.IO;

namespace Yulinti.Deus {
    internal sealed class DatumServatum {
        private readonly int _idDatumServatum;
        private readonly SalsamentumDTO _salsamentumDTO;
        private readonly IOstiumSalsamenti _ostiumSalsamenti;
        private readonly string _jsonPath;
        private readonly string _tmpPath;
        // 更新フラグ。
        private bool _estServatum;
        // 削除フラグ。
        private bool _estLiberare;

        public DatumServatum(
            int idDatumServatum,
            string jsonPath,
            string tmpPath,
            SalsamentumDTO salsamentumDTO
        ) {
            _idDatumServatum = idDatumServatum;
            _salsamentumDTO = salsamentumDTO;
            _ostiumSalsamenti = new OstiumSalsamenti(_salsamentumDTO);
            _jsonPath = jsonPath;
            _tmpPath = tmpPath;
            _estServatum = false;
            _estLiberare = false;
        }

        public int IdDatumServatum => _idDatumServatum;
        public SalsamentumDTO SalsamentumDTO => _salsamentumDTO;
        public IOstiumSalsamenti OstiumSalsamenti => _ostiumSalsamenti;
        public string JsonPath => _jsonPath;
        public string TmpPath => _tmpPath;
        public bool EstServatum => _estServatum;
        public bool EstLiberare => _estLiberare;

        // 初期作成時とか。更新フラグを操作する際に使う。
        public void Renovere() {
            _estServatum = true;
        }

        // Turrisから実行。DTOの値を更新する。
        public void RenoverePuellaePersonae(IResFluidaPuellaePersonaeLegibile resFluida) {
            _salsamentumDTO.PuellaePersonae.Renovere(resFluida);
            Renovere();
        }

        // Turrisから実行。削除フラグを立てる。
        public void Liberare() {
            _estLiberare = true;
        }
 

        // セーブ時にArcessitorから実行。各パラメータを更新してJSON化。
        public string ParatioServandi(
            int versio,
            long revisio,
            string dies
        ) {
            if (!_estServatum) return null;

            _salsamentumDTO.Versio = versio;
            _salsamentumDTO.Revisio = revisio;
            _salsamentumDTO.Dies = dies;

            _estServatum = false;
            return JsonUtility.ToJson(_salsamentumDTO);
        }
    }

    internal sealed class ThesaurusSalsamenti {
        private static readonly string _DirPath = Path.Combine(Application.persistentDataPath, ConstansDeus.DirPathSalsamentum);
        private readonly DatumServatum[] _dataServata;
        private long _revisio;

        public ThesaurusSalsamenti() {
            _dataServata = new DatumServatum[ConstansDeus.MaximusNumerusDatumServatum];
            _revisio = 0;
        }

        public int Longitudo => _dataServata.Length;
        public long Revisio => _revisio;

        private int LegereIDVacantem() {
            for (int i = 0; i < ConstansDeus.MaximusNumerusDatumServatum; i++) {
                if (_dataServata[i] == null) return i;
            }
            return -1;
        }

        private bool VaridareID(int idDatumServatum) {
            if ((uint)idDatumServatum >= (uint)ConstansDeus.MaximusNumerusDatumServatum) return false;
            return true;
        }

        // Turrisから実行。新規データを作成。
        // すべてAddoし終わる前に呼ぶと上書きされるので注意。Arcessitorはコンストラクタで必ず全部Addoするように。
        public bool Creare() {
            // 空きIDを探す。
            int idDatumServatum = LegereIDVacantem();
            if (idDatumServatum == -1) return false;

            string jsonPath = Path.Combine(_DirPath, $"{idDatumServatum}.json");
            string tmpPath = Path.Combine(_DirPath, $"{idDatumServatum}.tmp");

            _revisio++;

            SalsamentumDTO salsamentum = new SalsamentumDTO(
                idDatumServatum, ConstansDeus.VersioSalsamentum, _revisio, DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            );

            _dataServata[idDatumServatum] = new DatumServatum(
                idDatumServatum, jsonPath, tmpPath, salsamentum
            );
            _dataServata[idDatumServatum].Renovere();

            return true;
        }

        // Arcessitorから実行。データを追加。
        public bool Addo(
            string json,
            string jsonPath
        ) {
            try {
                SalsamentumDTO salsamentumDTO = JsonUtility.FromJson<SalsamentumDTO>(json);
                string tmpPath = Path.Combine(_DirPath, $"{salsamentumDTO.IdDatumServatum}.tmp");

                // JSONファイル名とIdDatumServatumが一致するかチェック
                string s = Path.GetFileNameWithoutExtension(jsonPath);
                if (!int.TryParse(s, out int idDatumServatum)) return false;
                if (idDatumServatum != salsamentumDTO.IdDatumServatum) return false;

                // 不正ID
                if (!VaridareID(idDatumServatum)) return false;

                if (!salsamentumDTO.Validare()) return false;

                _dataServata[idDatumServatum] = new DatumServatum(
                    idDatumServatum, jsonPath, tmpPath, salsamentumDTO
                );

                // _revisioが大きいものが追加された場合、_revisioを更新。
                if (_revisio < salsamentumDTO.Revisio) {
                    _revisio = salsamentumDTO.Revisio;
                }
                return true;
            } catch {
                return false;
            }
        }

        private string ParatioServandi(
            int idDatumServatum
        ) {
            int versio = ConstansDeus.VersioSalsamentum;
            long revisio = _revisio + 1;
            string dies = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

            string json = _dataServata[idDatumServatum].ParatioServandi(versio, revisio, dies);
            if (json == null) return null;
            _revisio = revisio;

            return json;
        }

        private (string, string) ParatioLiberandi(int idDatumServatum) {
            string jsonPath = _dataServata[idDatumServatum].JsonPath;
            string tmpPath = _dataServata[idDatumServatum].TmpPath;
            _dataServata[idDatumServatum] = null;
            return (jsonPath, tmpPath);
        }

        // Arcessitorから実行する。
        // salva(json, jsonPath, tmpPath) でセーブ。
        // dele(jsonPath, tmpPath) で削除。
        // Asyncに包まないようにやれ。
        public void ResolvereServandi(
            Action<string, string, string> salva,
            Action<string, string> dele
        ) {
            for (int i = 0; i < Longitudo; i++) {
                var d = _dataServata[i];
                if (d == null) continue;

                if (d.EstLiberare) {
                    (string jsonPath, string tmpPath) = ParatioLiberandi(i);
                    dele.Invoke(jsonPath, tmpPath);
                    continue;
                }
                if (d.EstServatum) {
                    string json = ParatioServandi(i);
                    if (json == null) continue;
                    salva.Invoke(json, d.JsonPath, d.TmpPath);
                    continue;
                }
            }
        }

        // Turrisから実行。指定IDのOstiumSalsamentiを取得。
        public IOstiumSalsamenti Lego(int idDatumServatum) {
            if (!VaridareID(idDatumServatum)) return null;
            if (_dataServata[idDatumServatum] == null) return null;
            return _dataServata[idDatumServatum].OstiumSalsamenti;
        }

        // Turrisから実行。SalsamentumPuellaePersonaeを更新。
        public void RenoverePuellaePersonae(int idDatumServatum, IResFluidaPuellaePersonaeLegibile resFluida) {
            if (!VaridareID(idDatumServatum)) return;
            if (_dataServata[idDatumServatum] == null) return;
            _dataServata[idDatumServatum].RenoverePuellaePersonae(resFluida);
        }
    }
}