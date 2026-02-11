using System.Threading;
using System.Threading.Tasks;
using System;
using System.IO;
using UnityEngine;

namespace Yulinti.Unity.Turris {
    internal sealed class Arcessitor {
        private static readonly string _DirPath = Path.Combine(Application.persistentDataPath, ConstansTurris.DirPathSalsamentum);
        private static readonly string _DirPathInvalid = Path.Combine(Application.persistentDataPath, ConstansTurris.DirPathSalsamentumInvalid);
        private readonly IScriba _scriba;
        private readonly ThesaurusSalsamenti _thesaurusSalsamenti;

        private readonly (string json, string path, string tmp)[] _bufServata;
        private readonly (string path, string tmp)[] _bufLiberata;

        private int _indexusSalva;
        private int _indexusDele;

        private Action<string, string, string> _adSalva;
        private Action<string, string> _adDele;

        public Arcessitor(IScriba scriba, ThesaurusSalsamenti thesaurusSalsamenti) {
            _scriba = scriba;
            _thesaurusSalsamenti = thesaurusSalsamenti;
            _bufServata = new (string json, string path, string tmp)[ConstansTurris.MaximusNumerusDatumServatum];
            _bufLiberata = new (string path, string tmp)[ConstansTurris.MaximusNumerusDatumServatum];
            _adSalva = AdSalva;
            _adDele = AdDele;

            if (!Directory.Exists(_DirPath)) {
                Directory.CreateDirectory(_DirPath);
            }
            if (!Directory.Exists(_DirPathInvalid)) {
                Directory.CreateDirectory(_DirPathInvalid);
            }

            Arcessere();
        }

        // 全セーブデータをロードする。
        // 不正なファイルはInvalidに移動する。
        public void Arcessere() {
            // ディレクトリ内のファイルを取得
            string[] files = Directory.GetFiles(_DirPath, "*.json");
            foreach (string file in files) {
                try {
                    string json = _scriba.Legere(file);
                    string jsonPath = Path.Combine(_DirPath, Path.GetFileName(file));
                    if (!_thesaurusSalsamenti.Addo(json, jsonPath)) {
                        _scriba.Deplace(file, Path.Combine(_DirPathInvalid, Path.GetFileName(file)));
                    }
                } catch {
                    _scriba.Deplace(file, Path.Combine(_DirPathInvalid, Path.GetFileName(file)));
                }
            }
        }

        // これはメインスレッドから呼び出すこと。
        // メインスレッド外から呼ぶとJSONスナップショットの保障が消える。
        public async Task ServareAsync(CancellationToken ct) {
            _indexusSalva = 0;
            _indexusDele = 0;
            _thesaurusSalsamenti.ResolvereServandi(_adSalva, _adDele);
            // ここまでMainThread

            for (int i = 0; i < _indexusDele; i++) {
                _scriba.Delere(_bufLiberata[i].path, _bufLiberata[i].tmp);
            }
            for (int i = 0; i < _indexusSalva; i++) {
                await _scriba.ScribereAsync(_bufServata[i].json, _bufServata[i].path, _bufServata[i].tmp, ct);
            }
            _indexusSalva = 0;
            _indexusDele = 0;
            // ここでしかbufを使わないなら、空にする必要はない気がする。
        }

        private void AdSalva(string json, string path, string tmp) {
            if (_indexusSalva >= ConstansTurris.MaximusNumerusDatumServatum) {
                throw new InvalidOperationException("IndexusSalva is out of range");
            }
            _bufServata[_indexusSalva] = (json, path, tmp);
            _indexusSalva++;
        }

        private void AdDele(string path, string tmp) {
            if (_indexusDele >= ConstansTurris.MaximusNumerusDatumServatum) {
                throw new InvalidOperationException("IndexusDele is out of range");
            }
            _bufLiberata[_indexusDele] = (path, tmp);
            _indexusDele++;
        }
    }
}