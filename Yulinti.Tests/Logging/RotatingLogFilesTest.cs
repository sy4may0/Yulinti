using System;
using System.IO;
using Yulinti.Logging;

namespace sy4may0.Yulinti.Tests.LoggingTests
{
    public class RotatingLogFilesTests : IDisposable
    {
        private string _testDirectory = Path.Combine(Path.GetTempPath(), "RotatingLogFilesTests");

        public RotatingLogFilesTests()
        {
            // xUnitのコンストラクタは[TestInitialize]の代わり
        }

        public void Dispose()
        {
            // xUnitのDisposeは[TestCleanup]の代わり
            // テスト用ディレクトリをクリーンアップ
            if (Directory.Exists(_testDirectory))
            {
                Directory.Delete(_testDirectory, true);
            }

            if (Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Logs")))
            {
                Directory.Delete(Path.Combine(Environment.CurrentDirectory, "Logs"), true);
            }
        }

        [Fact]
        public void Test_Constructor_ShouldCreateLogFile()
        {
            using var rotatingLog = new RotatingLogFiles(
                logDirectory: _testDirectory,
                sessionId: "test.session",
                buildVersion: "test.version",
                platform: "test.platform"
            );

            // dir/*_test.session_test.version_test.platform.logを探し、ヒットしたらAssert.True
            Assert.True(
                Directory.GetFiles(_testDirectory, "*_test.session_test.version_test.platform.log").Length == 1
            );
        }

        [Fact]
        public void Test_Constructor_ShouldCreateLogFileWithNullDirectory()
        {
            using var rotatingLog = new RotatingLogFiles(
                #pragma warning disable
                logDirectory: null,
                sessionId: "test.session",
                buildVersion: "test.version",
                platform: "test.platform"
            );

            Assert.True(
                Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "Logs"), "*_test.session_test.version_test.platform.log").Length == 1
            );
        }

        [Fact]
        public void Test_Constructor_ShouldCreateLogFileWithNullParameters()
        {
            using var rotatingLog = new RotatingLogFiles(
                logDirectory: _testDirectory,
                sessionId: null,
                buildVersion: null,
                platform: null
            );

            Assert.True(
                Directory.GetFiles(_testDirectory, "*_NA_NA_NA.log").Length == 1
            );
        }

        [Fact]
        public void Test_Log_ShouldWriteLogFile()
        {
            using (var rotatingLog = new RotatingLogFiles(
                logDirectory: _testDirectory,
                sessionId: "test.session",
                buildVersion: "test.version",
                platform: "test.platform"
            ))
            {
                rotatingLog.Log("test message");
                rotatingLog.Flush(); // バッファをフラッシュしてファイルに書き込み

                Assert.True(
                    Directory.GetFiles(_testDirectory, "*_test.session_test.version_test.platform.log").Length == 1
                );

                var logFile = Directory.GetFiles(_testDirectory, "*_test.session_test.version_test.platform.log")[0];
                using FileStream fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using StreamReader sr = new StreamReader(fs);
                string line = sr.ReadLine();
                Assert.True(line == "test message");
            }
        }

        [Fact]
        public void Test_Log_ShouldWriteLogFileWithBufferFullFlush() 
        {
            using (var rotatingLog = new RotatingLogFiles(
                logDirectory: _testDirectory,
                sessionId: "test.session",
                buildVersion: "test.version",
                platform: "test.platform"
            ))

            {
                // 4096kb lines
                for (int i = 0; i < RotatingLogFiles.LOG_FILE_BUFFER_SIZE; i++) {
                    rotatingLog.Log("test message");
                }
                // no flush

                Assert.True(
                    Directory.GetFiles(_testDirectory, "*_test.session_test.version_test.platform.log").Length == 1
                );

                var logFile = Directory.GetFiles(_testDirectory, "*_test.session_test.version_test.platform.log")[0];
                using FileStream fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using StreamReader sr = new StreamReader(fs);
                string line = sr.ReadLine();
                Assert.True(line == "test message");
            }
        }
    }
}