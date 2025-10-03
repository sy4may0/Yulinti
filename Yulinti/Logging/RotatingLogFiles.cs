using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yulinti.Logging
{
    public enum LogLevel
    {
        DEBUG,
        INFO,
        WARNING,
        ERROR,
        CRITICAL
    }

    public sealed class RotatingLogFiles : IDisposable
    {
        // だるいから絶対変更するな。← フォーマット内に .log が含まれる前提で、二重付与はしない
        public const string LOG_FILE_FORMAT = "{datetime}_{session}_{version}_{platform}.log";
        public const long LOG_FILE_SIZE_LIMIT = 1024L * 1024L * 100L; // 100 MB
        public const int LOG_FILE_COUNT_LIMIT = 3;

        private sealed class LogFile : IDisposable
        {
            private readonly string _path;
            private FileStream? _fs;
            private StreamWriter? _sw;

            public LogFile(string path)
            {
                _path = path;
                // 先にファイルを作って即閉じる（存在しないときのみ）
                if (!File.Exists(_path))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
                    using var _ = File.Create(_path);
                }
            }

            public string PathString => _path;

            public void Open()
            {
                Close(); // 冪等
                _fs = new FileStream(_path, FileMode.Append, FileAccess.Write, FileShare.Read);
                _sw = new StreamWriter(_fs, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false))
                {
                    AutoFlush = false
                };
            }

            public void Flush() {
                _sw?.Flush();
                if (_fs != null) _fs.Flush(true);
            }

            public void Close()
            {
                try { _sw?.Flush(); } catch { /* best-effort */ }
                _sw?.Dispose();
                _sw = null;
                _fs?.Dispose();
                _fs = null;
            }

            public bool IsOpen => _fs != null && _sw != null;

            public void WriteLine(string message)
            {
                if (_sw == null) throw new InvalidOperationException("Log file is not open.");
                _sw.WriteLine(message);
            }

            public long GetSizeBytes()
            {
                if (_fs != null) return _fs.Length; // 開いている場合はストリーム長が最も正確
                return new FileInfo(_path).Length;
            }

            public DateTime GetOrderKeyUtc()
            {
                // 作成時刻は不安定な環境があるため「最終更新時刻のUTC」を採用
                return File.Exists(_path) ? File.GetLastWriteTimeUtc(_path) : DateTime.MinValue;
            }

            public void Delete()
            {
                Close();
                try {
                    if (File.Exists(_path)) File.Delete(_path);
                } catch {
                    // best-effort
                }
            }

            public void Dispose() => Close();
        }

        private readonly object _lock = new();
        private readonly List<LogFile> _files = new();

        private readonly string _logDirectory;
        private readonly string _sessionId;
        private readonly string _buildVersion;
        private readonly string _platform;

        public RotatingLogFiles(
            string logDirectory,
            string sessionId,
            string buildVersion,
            string platform)
        {
            _logDirectory  = string.IsNullOrWhiteSpace(logDirectory) ? Path.Combine(Environment.CurrentDirectory, "Logs") : logDirectory;
            _sessionId     = string.IsNullOrWhiteSpace(sessionId) ? "NA" : sessionId;
            _buildVersion  = string.IsNullOrWhiteSpace(buildVersion) ? "NA" : buildVersion;
            _platform      = string.IsNullOrWhiteSpace(platform) ? "NA" : platform;

            Directory.CreateDirectory(_logDirectory);
            LoadLogFilesInternal();
            EnsureAtLeastOneFile();
            // 現在ファイルを開いておく
            GetCurrentUnsafe().Open();
        }

        private string BuildLogFilePath(DateTime dt)
        {
            var fileName = LOG_FILE_FORMAT
                .Replace("{datetime}", dt.ToString("yyyyMMdd_HHmmssfff"))
                .Replace("{session}", _sessionId)
                .Replace("{version}", _buildVersion)
                .Replace("{platform}", _platform);

            return Path.Combine(_logDirectory, fileName); // ここで .log を追加しない
        }

        private void LoadLogFilesInternal()
        {
            _files.Clear();
            var paths = Directory.GetFiles(_logDirectory, "*.log");
            foreach (var p in paths)
            {
                _files.Add(new LogFile(p));
            }
            SortByTime();
        }

        private void SortByTime()
        {
            _files.Sort((a, b) => a.GetOrderKeyUtc().CompareTo(b.GetOrderKeyUtc()));
        }

        private void EnsureAtLeastOneFile()
        {
            if (_files.Count == 0)
            {
                var lf = new LogFile(BuildLogFilePath(DateTime.UtcNow));
                _files.Add(lf);
            }
        }

        private LogFile GetCurrentUnsafe()
        {
            if (_files.Count == 0) throw new InvalidOperationException("No log files loaded.");
            return _files[^1];
        }

        private void CreateNewLogFileAndOpen()
        {
            var lf = new LogFile(BuildLogFilePath(DateTime.UtcNow));
            _files.Add(lf);
            SortByTime();
            lf.Open();
        }

        private void CleanupRotation()
        {
            while (_files.Count > LOG_FILE_COUNT_LIMIT)
            {
                var first = _files[0];
                first.Delete(); // Close含む
                _files.RemoveAt(0);
            }
        }

        public void Log(string message)
        {

            lock (_lock)
            {
                var current = GetCurrentUnsafe();
                if (!current.IsOpen) current.Open();

                current.WriteLine(message);

                if (current.GetSizeBytes() >= LOG_FILE_SIZE_LIMIT)
                {
                    // いったん閉じて新規を開く
                    current.Close();
                    CreateNewLogFileAndOpen();
                    CleanupRotation();
                }
            }
        }

        public void Flush()
        {
            lock (_lock)
            {
                var current = GetCurrentUnsafe();
                if (current.IsOpen) current.Flush();
            }
        }

        public void FlushAndClose()
        {
            lock (_lock)
            {
                foreach (var f in _files)
                {
                    if (f.IsOpen) f.Close();
                }
            }
        }

        public void Dispose()
        {
            FlushAndClose();
            foreach (var f in _files) f.Dispose();
        }
    }
}

