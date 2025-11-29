using Cysharp.Threading.Tasks;

namespace Yulinti.MinisteriaUnity.Anchora {
    public interface IPhantasma {
        UniTask Manifestatio();
        void Deleto();
        bool ValidareManifestatio();
        bool EstEns { get; } 
    }
}