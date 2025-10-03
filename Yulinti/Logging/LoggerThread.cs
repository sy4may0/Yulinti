using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;

namespace Yulinti.Logging {
    public enum LogQueueMessageType {
        LogEntry,
        Initialize,
        Kill,
        Nothing
    }

    public abstract class LogQueueMessage {
        public LogQueueMessageType Type { get; set; } = LogQueueMessageType.Nothing;
    }

    public class LogEntry : LogQueueMessage {
        private readonly string Message;
        private readonly List<string> Attributes;
        private readonly LogLevel Level;

        public LogEntry(string message, List<string> attributes, LogLevel level) {
            Message = message;
            Attributes = attributes ?? new List<string>();
            Level = level;
            Type = LogQueueMessageType.LogEntry;
        }

        private string FormatMessage() {
            try {
                return String.Format(Message, Attributes.ToArray());
            } catch (FormatException) {
                return Message + " : Cannot format. params=" + String.Join(",", Attributes.ToArray());
            }
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            string formatmsg = FormatMessage();
            sb.Append(DateTime.UtcNow.ToString("O"));
            sb.Append(": ");
            sb.Append(Level.ToString());
            sb.Append(": ");
            sb.Append(formatmsg);
            return sb.ToString();
        }

        public bool IsLoggable(LogLevel threshold) {
            return Level >= threshold;
        }

        public bool IsImportant() {
            return Level >= LogLevel.ERROR;
        }
    }

    public class Initialize : LogQueueMessage {
        public string LogDirectory { get; }
        public string SessionId { get; }
        public string BuildVersion { get; }
        public string Platform { get; }
        public Initialize(string logDirectory, string sessionId, string buildVersion, string platform) {
            LogDirectory = logDirectory;
            SessionId = sessionId;
            BuildVersion = buildVersion;
            Platform = platform;
            Type = LogQueueMessageType.Initialize;
        }
    }

    public class Kill : LogQueueMessage {
        public Kill() {
            Type = LogQueueMessageType.Kill;
        }
    }

    public class LoggerThread : IDisposable {
        public const int QUEUE_TIMEOUT_MS = 5;
        public const int QUEUE_SIZE = 1024;

        private readonly Thread _thread;
        private readonly BlockingCollection<LogQueueMessage> _logQueue;
        private readonly LogLevel _loggingThreshold = LogLevel.INFO;
        // コンストラクタではなくスレッド内で初期化するため、null許可/RW許可。
        private RotatingLogFiles? _logFiles;
        private bool _disposed = true;

        public LoggerThread(LogLevel loggingThreshold) {
            _logQueue = new BlockingCollection<LogQueueMessage>(QUEUE_SIZE);
            _thread = new Thread(LogWorker) { Name = "YulintiLogger", IsBackground = false };
            _loggingThreshold = loggingThreshold;
            _thread.Start();
            _disposed = false;
        }

        public void EnqueueLog(LogLevel level, string message, params object?[] args) {
            // newはコストだからLogEntry生成前にreturn
            if (level < _loggingThreshold) return;
            if (_logQueue.IsAddingCompleted) return;

            List<string> attributes = args?.Select(arg => arg?.ToString() ?? "null").ToList() ?? new List<string>();

            LogEntry logEntry = new LogEntry(message, attributes, level);
            if (_logQueue.TryAdd(logEntry, 0)) return;

            if (logEntry.IsImportant()) {
                _logQueue.TryAdd(logEntry, QUEUE_TIMEOUT_MS);
            }
        }

        public void EnqueueInitialize(string logDirectory, string sessionId, string buildVersion, string platform) {
            if (_logQueue.IsAddingCompleted) return;
            _logQueue.TryAdd(new Initialize(logDirectory, sessionId, buildVersion, platform), QUEUE_TIMEOUT_MS);
        }

        public void EnqueueKill() {
            if (_logQueue.IsAddingCompleted) return;
            _logQueue.TryAdd(new Kill(), QUEUE_TIMEOUT_MS);
        }

        private void HandleInitialize(Initialize initialize) {
            _logFiles = new RotatingLogFiles(initialize.LogDirectory, initialize.SessionId, initialize.BuildVersion, initialize.Platform);
        }

        private void HandleKill() {
            if (_logFiles == null) return;

            _logFiles.FlushAndClose();
            _logFiles.Dispose();
            _logFiles = null;
        }

        private void HandleLogEntry(LogEntry logEntry) {
            if (_logFiles == null) return;

            if (logEntry.IsLoggable(_loggingThreshold)) {
                _logFiles.Log(logEntry.ToString());
                // Warning以上は即flush
                if (logEntry.IsImportant()) {
                    _logFiles.Flush();
                }
            }
        }

        private void LogWorker() {
            foreach (LogQueueMessage message in _logQueue.GetConsumingEnumerable()) {
                switch (message.Type) {
                    case LogQueueMessageType.LogEntry:
                        if (message is LogEntry logEntry) {
                            HandleLogEntry(logEntry);
                        }
                        break;
                    case LogQueueMessageType.Initialize:
                        if (message is Initialize initialize) {
                            HandleInitialize(initialize);
                        }
                        break;
                    case LogQueueMessageType.Kill:
                        HandleKill();
                        return;
                }
            }

            HandleKill();
        }

        public void Dispose() {
            if (_disposed) return;

            _logQueue.TryAdd(new Kill(), QUEUE_TIMEOUT_MS);
            _logQueue.CompleteAdding();
            _thread.Join();
            _disposed = true;
        }
    }
}