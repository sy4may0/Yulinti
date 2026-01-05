using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioCivisGenerator : IConfiguratioCivisGenerator {
        [SerializeField] private int _populatioMaxima = 20;
        [SerializeField] private int _populatioInitialis = 5;
        [SerializeField] private int _intervallumMaximus = 120;
        [SerializeField] private int _intervallumMinimus = 10;

        public int PopulatioMaxima => _populatioMaxima;
        public int PopulatioInitialis => _populatioInitialis;
        public int IntervallumMaximus => _intervallumMaximus;
        public int IntervallumMinimus => _intervallumMinimus;
    }
}