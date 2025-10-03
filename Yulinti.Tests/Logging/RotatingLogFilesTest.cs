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
    }
}