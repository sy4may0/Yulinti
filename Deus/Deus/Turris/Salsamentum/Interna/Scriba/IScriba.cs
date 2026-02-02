using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Deus {
    internal interface IScriba {
        void Scribere(
            string json,
            string jsonPath,
            string tmpPath
        );

        Task ScribereAsync(
            string json,
            string jsonPath,
            string tmpPath,
            CancellationToken ct
        );

        string Legere(
            string jsonPath
        );

        void Delere(
            string jsonPath,
            string tmpPath
        );

        void Deplace(
            string srcPath,
            string dstPath
        );
    }
}