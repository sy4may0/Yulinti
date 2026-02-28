using Cysharp.Threading.Tasks;

namespace Yulinti.Unity.Contractus {
    public interface IPhantasma {
        UniTask Manifestatio();
        void Deleto();
        bool ValidareManifestatio();
        void Incarnare();
        void Spirituare();
        bool EstEns { get; } 
        bool EstActivum { get; }
    }
}
